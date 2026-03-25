using System.Text.Json;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using ServiceLigueHockey.Data;

namespace ServiceLigueHockeyV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            MergeJsonFiles();

            // Maintenant, utiliser le fichier fusionné
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

            string monAllowSpecificOrigin = "monAllowSpecificOrigin";

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Début décommenter pour déployer sur Ubuntu Server
            // Laisser commenté pour tester en debug
            /*builder.WebHost.ConfigureKestrel(serverOption =>
            {
                serverOption.Listen(IPAddress.Parse("10.0.0.5"), 5000);
                serverOption.Listen(IPAddress.Parse("127.0.0.1"), 5000);
            });*/
            // Fin décommenter pour déployer sur Ubuntu Server

            builder.Services.AddDbContext<ServiceLigueHockeyContext>(options => {
                var connectionString =  builder.Configuration.GetConnectionString("mysqlConnection");
                //var connectionString = builder.Configuration.GetConnectionString("sqlServerConnection");
                //var connectionString = builder.Configuration.GetConnectionString("winServer2022Connection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new System.Exception("La chaine de connexion est vide.");
                }

                options.UseMySql(
                    builder.Configuration.GetConnectionString("mysqlConnection"),
                    new MySqlServerVersion(new Version(8, 0, 0)),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                );

                //options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
                //options.UseSqlServer(connectionString);
            });

            builder.Services.AddCors(options => {
                options.AddPolicy(name: monAllowSpecificOrigin,
                    builder => {
                        /*builder.WithOrigins("http://localhost:4900", "https://localhost:4900", "http://127.0.0.1:4900", "https://127.0.0.1:4900")
                            .WithHeaders("Content-Type")
                            .WithMethods("POST","GET","PUT","OPTIONS");*/
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            builder.Services.AddHttpClient();

            var app = builder.Build();
            app.UseCors(monAllowSpecificOrigin);

            try
            {
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ServiceLigueHockeyContext>();
                    db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                var logger = app.Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Erreur lors des migrations - app démarre quand même");
            }

            // Utilise le port Azure si disponible, sinon 5298 en local
            var port = Environment.GetEnvironmentVariable("PORT") ?? "5298";
            builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    Console.WriteLine("dev");
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ligue Hockey API V1");
                    c.RoutePrefix = string.Empty; // ← Swagger accessible à la racine "/"
                });
            //}
            //else
            //{
            //    Console.WriteLine("prod");
                //app.UseHttpsRedirection();
            //}

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        static void MergeJsonFiles()
        {
            try
            {
                // Chemins des fichiers
                string appSettingsTemplatePath = "appsettings.template.json";
                string appSettingsPath = "appsettings.json";
                string secretsPath = "messecrets.json";

                // Vérifier si les fichiers existent
                if (!File.Exists(appSettingsTemplatePath))
                {
                    Console.WriteLine("Fichier appsettings.appSettingsTemplatePath.json introuvable");
                    return;
                }

                if (!File.Exists(secretsPath))
                {
                    Console.WriteLine("Fichier messecrets.json introuvable - utilisation du appsettings.json original");
                    if (!File.Exists(appSettingsPath))
                    {
                        File.Copy(appSettingsTemplatePath, appSettingsPath);
                    }
                    return;
                }

                // Lire les contenus
                string appSettingsTemplateContent = File.ReadAllText(appSettingsTemplatePath);
                string secretsContent = File.ReadAllText(secretsPath);

                // Parser les JSON
                var appSettingsJson = JsonDocument.Parse(appSettingsTemplateContent);
                var secretsJson = JsonDocument.Parse(secretsContent);

                // Créer un nouveau dictionnaire pour la fusion
                var mergedConfig = new Dictionary<string, object?>();

                // Ajouter d'abord les paramètres de base
                AddJsonToDictionary(appSettingsJson.RootElement, mergedConfig);

                // Ensuite, ajouter/écraser avec les secrets (priorité plus élevée)
                AddJsonToDictionary(secretsJson.RootElement, mergedConfig);

                // Sérialiser le résultat fusionné
                string mergedJson = JsonSerializer.Serialize(mergedConfig, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                // Écrire le fichier fusionné
                File.WriteAllText(appSettingsPath, mergedJson);

                Console.WriteLine("Fichiers JSON fusionnés avec succès");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la fusion des fichiers JSON : {ex.Message}");
            }
        }

        static void AddJsonToDictionary(JsonElement element, Dictionary<string, object?> dictionary)
        {
            foreach (var property in element.EnumerateObject())
            {
                string key = property.Name;
                JsonElement value = property.Value;
                
                switch (value.ValueKind)
                {
                    case JsonValueKind.Object:
                        var nestedDict = new Dictionary<string, object?>();
                        AddJsonToDictionary(value, nestedDict);
                        dictionary[key] = nestedDict;
                        break;
                    case JsonValueKind.Array:
                        var array = new List<object?>();
                        foreach (var item in value.EnumerateArray())
                        {
                            array.Add(GetJsonValue(item));
                        }
                        dictionary[key] = array;
                        break;
                    default:
                        dictionary[key] = GetJsonValue(value);
                        break;
                }
            }
        }

        static object? GetJsonValue(JsonElement element)
        {
            return element.ValueKind switch
            {
                JsonValueKind.String => element.GetString(),
                JsonValueKind.Number => element.TryGetInt32(out int i) ? i : element.GetDouble(),
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.Null => null,
                _ => element.ToString()
            };
        }
    }
}