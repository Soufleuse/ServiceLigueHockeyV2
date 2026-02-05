using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLigueHockey.Data;

namespace ServiceLigueHockeyTest;

public class AnneeTest
{
    private IConfigurationRoot _root;
    
    [SetUp]
    public void Setup()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddUserSecrets("d5237f51-6255-4231-9182-31ed412a74f8");
        _root = builder.Build();
    }

    [Test]
    public void LectureAnnee()
    {
        var connectionString = this._root.GetConnectionString("mysqlConnection");
        if(string.IsNullOrEmpty(connectionString))
            throw new System.Exception("La chaine de connexion est vide.");

        var options = new DbContextOptionsBuilder<ServiceLigueHockeyContext>()
            .UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
            
        Console.WriteLine("Salut le peuple!");
        //var controller = new AnneeStats();
        //var result = controller.Details(2) as ViewResult;
        //Assert.AreEqual("Details", result.ViewName);

        Assert.Pass();
    }
}