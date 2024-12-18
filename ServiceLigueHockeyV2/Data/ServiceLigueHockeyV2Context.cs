using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServiceLigueHockey.Data.Models;
using Pomelo.EntityFrameworkCore.MySql.Extensions;

namespace ServiceLigueHockey.Data
{
    public class ServiceLigueHockeyContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ServiceLigueHockeyContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public DbSet<EquipeBd> equipe { get; set; } = default!;

        public DbSet<JoueurBd> joueur { get; set; } = default!;

        public DbSet<EquipeJoueurBd> equipeJoueur { get; set; } = default!;

        public DbSet<StatsJoueurBd> statsJoueurBd { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = this.Configuration.GetConnectionString("mysqlConnection");
                //var connectionString = this.Configuration.GetConnectionString("winServer2022Connection");
                if(string.IsNullOrEmpty(connectionString))
                    throw new System.Exception("La chaine de connexion est vide.");

                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 30)));
                //optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Création des tables
            modelBuilder.Entity<EquipeBd>().ToTable("Equipe");
            modelBuilder.Entity<EquipeBd>().HasKey(c => c.Id);
            modelBuilder.Entity<EquipeBd>().Property(x => x.Id).IsRequired();
            modelBuilder.Entity<EquipeBd>().Property(x => x.NomEquipe).HasMaxLength(50);
            modelBuilder.Entity<EquipeBd>().Property(x => x.Ville).HasMaxLength(50);
            modelBuilder.Entity<EquipeBd>().HasMany("listeEquipeJoueur").WithOne("Equipe");

            modelBuilder.Entity<JoueurBd>().ToTable("Joueur");
            modelBuilder.Entity<JoueurBd>().HasKey(c => c.Id);
            modelBuilder.Entity<JoueurBd>().Property(c => c.Id).IsRequired();
            modelBuilder.Entity<JoueurBd>().Property(c => c.Prenom).HasMaxLength(50);
            modelBuilder.Entity<JoueurBd>().Property(c => c.Nom).HasMaxLength(50);
            modelBuilder.Entity<JoueurBd>().Property(c => c.VilleNaissance).HasMaxLength(50);
            modelBuilder.Entity<JoueurBd>().Property(c => c.PaysOrigine).HasMaxLength(50);
            modelBuilder.Entity<JoueurBd>().HasMany("listeEquipeJoueur").WithOne("Joueur");

            modelBuilder.Entity<EquipeJoueurBd>().ToTable("EquipeJoueur");
            modelBuilder.Entity<EquipeJoueurBd>()
                .HasKey(o => new { o.EquipeId, o.JoueurId, o.DateDebutAvecEquipe });
            modelBuilder.Entity<EquipeJoueurBd>()
                .HasOne(p => p.Joueur)
                .WithMany(p => p.listeEquipeJoueur)
                .HasForeignKey(p => p.JoueurId );
            modelBuilder.Entity<EquipeJoueurBd>()
                .HasOne("Equipe")
                .WithMany("listeEquipeJoueur")
                .HasForeignKey("EquipeId");

            modelBuilder.Entity<StatsJoueurBd>().ToTable("StatsJoueur");
            modelBuilder.Entity<StatsJoueurBd>()
                .HasKey(o => new { o.JoueurId, o.EquipeId, o.AnneeStats });
            modelBuilder.Entity<StatsJoueurBd>().Property(c => c.AnneeStats).IsRequired();
            modelBuilder.Entity<StatsJoueurBd>()
                .HasOne("Joueur")
                .WithMany("listeStatsJoueur")
                .HasForeignKey("JoueurId");
            
            modelBuilder.Entity<StatsEquipeBd>().ToTable("StatsEquipe");
            modelBuilder.Entity<StatsEquipeBd>().
                HasKey(o => new {o.EquipeId, o.AnneeStats});
            modelBuilder.Entity<StatsEquipeBd>().Property(c => c.AnneeStats).IsRequired();
            modelBuilder.Entity<StatsEquipeBd>()
                .HasOne("Equipe")
                .WithMany("listeStatsEquipe")
                .HasForeignKey("EquipeId");

            // Ajout de données
            modelBuilder.Entity<EquipeBd>()
                .HasData(
                new EquipeBd { Id = 1, NomEquipe = "Canadiensssss", Ville = "Mourial", AnneeDebut = 1989 },
                new EquipeBd { Id = 2, NomEquipe = "Bruns", Ville = "Albany", AnneeDebut = 1984 },
                new EquipeBd { Id = 3, NomEquipe = "Harfangs", Ville = "Hartford", AnneeDebut = 1976 },
                new EquipeBd { Id = 4, NomEquipe = "Boulettes", Ville = "Victoriaville", AnneeDebut = 1999 },
                new EquipeBd { Id = 5, NomEquipe = "Rocher", Ville = "Percé", AnneeDebut = 2001 },
                new EquipeBd { Id = 6, NomEquipe = "Pierre", Ville = "Rochester", AnneeDebut = 1986 }
                );

            modelBuilder.Entity<JoueurBd>()
                .HasData(
                new JoueurBd { Id = 1, Prenom = "Jack", Nom = "Tremblay", DateNaissance = new DateTime(1988, 10, 20), VilleNaissance = "Lévis", PaysOrigine = "Canada" },
                new JoueurBd { Id = 2, Prenom = "Simon", Nom = "Lajeunesse", DateNaissance = new DateTime(1996, 1, 25), VilleNaissance = "St-Stanislas", PaysOrigine = "Canada" },
                new JoueurBd { Id = 3, Prenom = "Mathieu", Nom = "Grandpré", DateNaissance = new DateTime(1995, 3, 5), VilleNaissance = "Val d\'or", PaysOrigine = "Canada" },
                new JoueurBd { Id = 4, Prenom = "Ryan", Nom = "Callahan", DateNaissance = new DateTime(1991, 3, 15), VilleNaissance = "London", PaysOrigine = "Canada" },
                new JoueurBd { Id = 5, Prenom = "Drew", Nom = "McCain", DateNaissance = new DateTime(1992, 6, 18), VilleNaissance = "Albany", PaysOrigine = "États-Unis" },
                new JoueurBd { Id = 6, Prenom = "John", Nom = "Harris", DateNaissance = new DateTime(2000, 9, 10), VilleNaissance = "Chico", PaysOrigine = "États-Unis" },
                new JoueurBd { Id = 7, Prenom = "Phil", Nom = "Rodgers", DateNaissance = new DateTime(1996, 12, 21), VilleNaissance = "Calgary", PaysOrigine = "Canada" },
                new JoueurBd { Id = 8, Prenom = "Ted", Nom = "Rodriguez", DateNaissance = new DateTime(1992, 10, 21), VilleNaissance = "Regina", PaysOrigine = "Canada" },
                new JoueurBd { Id = 9, Prenom = "Patrice", Nom = "Lemieux", DateNaissance = new DateTime(1998, 4, 21), VilleNaissance = "Chibougamau", PaysOrigine = "Canada" },
                new JoueurBd { Id = 10, Prenom = "Maurice", Nom = "Béliveau", DateNaissance = new DateTime(1997, 6, 1), VilleNaissance = "Beauceville", PaysOrigine = "Canada" },
                new JoueurBd { Id = 11, Prenom = "Andrew", Nom = "Cruz", DateNaissance = new DateTime(1997, 7, 30), VilleNaissance = "Dallas", PaysOrigine = "États-Unis" },
                new JoueurBd { Id = 12, Prenom = "Chris", Nom = "Trout", DateNaissance = new DateTime(1991, 8, 20), VilleNaissance = "Eau Claire", PaysOrigine = "États-Unis" },
                new JoueurBd { Id = 13, Prenom = "Sergei", Nom = "Datzyuk", DateNaissance = new DateTime(1992, 9, 6), VilleNaissance = "Eau Claire", PaysOrigine = "États-Unis" }
                );

            modelBuilder.Entity<EquipeJoueurBd>()
                .HasData(
                new EquipeJoueurBd { EquipeId = 1, JoueurId = 1, NoDossard = 23, DateDebutAvecEquipe = new DateTime(2008, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 1, JoueurId = 2, NoDossard = 24, DateDebutAvecEquipe = new DateTime(2016, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 1, JoueurId = 3, NoDossard = 25, DateDebutAvecEquipe = new DateTime(2017, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 1, JoueurId = 4, NoDossard = 26, DateDebutAvecEquipe = new DateTime(2013, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 2, JoueurId = 5, NoDossard = 27, DateDebutAvecEquipe = new DateTime(2014, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 2, JoueurId = 6, NoDossard = 28, DateDebutAvecEquipe = new DateTime(2020, 11, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 2, JoueurId = 7, NoDossard = 29, DateDebutAvecEquipe = new DateTime(2018, 1, 15), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 2, JoueurId = 8, NoDossard = 30, DateDebutAvecEquipe = new DateTime(2010, 9, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 3, JoueurId = 9, NoDossard = 31, DateDebutAvecEquipe = new DateTime(2018, 4, 20), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 3, JoueurId = 10, NoDossard = 32, DateDebutAvecEquipe = new DateTime(2018, 2, 13), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 3, JoueurId = 11, NoDossard = 33, DateDebutAvecEquipe = new DateTime(2018, 10, 30), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 4, JoueurId = 12, NoDossard = 34, DateDebutAvecEquipe = new DateTime(2011, 9, 10), DateFinAvecEquipe = null },
                new EquipeJoueurBd { EquipeId = 4, JoueurId = 13, NoDossard = 35, DateDebutAvecEquipe = new DateTime(2012, 8, 20), DateFinAvecEquipe = null }
                );

            modelBuilder.Entity<StatsJoueurBd>()
                .HasData(
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2023, NbButs = 10, NbPasses = 20, NbPoints = 30, NbPartiesJouees = 25, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2023, NbButs = 15, NbPasses = 10, NbPoints = 25, NbPartiesJouees = 25, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2023, NbButs = 5, NbPasses = 24, NbPoints = 29, NbPartiesJouees = 25, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2023, NbButs = 0, NbPasses = 0, NbPoints = 0, NbPartiesJouees = 25, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2022, NbButs = 10, NbPasses = 20, NbPoints = 30, NbPartiesJouees = 25, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2022, NbButs = 15, NbPasses = 10, NbPoints = 25, NbPartiesJouees = 25, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2022, NbButs = 5, NbPasses = 24, NbPoints = 29, NbPartiesJouees = 25, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2022, NbButs = 0, NbPasses = 0, NbPoints = 0, NbPartiesJouees = 25, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2021, NbButs = 10, NbPasses = 20, NbPoints = 30, NbPartiesJouees = 25, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2021, NbButs = 15, NbPasses = 10, NbPoints = 25, NbPartiesJouees = 25, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2021, NbButs = 5, NbPasses = 24, NbPoints = 29, NbPartiesJouees = 25, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2021, NbButs = 0, NbPasses = 0, NbPoints = 0, NbPartiesJouees = 25, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2020, NbButs = 10, NbPasses = 20, NbPoints = 30, NbPartiesJouees = 25, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2020, NbButs = 15, NbPasses = 10, NbPoints = 25, NbPartiesJouees = 25, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2020, NbButs = 5, NbPasses = 24, NbPoints = 29, NbPartiesJouees = 25, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2020, NbButs = 0, NbPasses = 0, NbPoints = 0, NbPartiesJouees = 25, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2019, NbButs = 1910, NbPasses = 20, NbPoints = 1930, NbPartiesJouees = 82, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2019, NbButs = 1915, NbPasses = 10, NbPoints = 1925, NbPartiesJouees = 82, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2019, NbButs = 1905, NbPasses = 24, NbPoints = 1929, NbPartiesJouees = 82, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2019, NbButs = 1900, NbPasses = 0, NbPoints = 1900, NbPartiesJouees = 82, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 1, AnneeStats = 2018, NbButs = 1810, NbPasses = 20, NbPoints = 1830, NbPartiesJouees = 65, NbMinutesPenalites = 15, PlusseMoins = 5, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 2, AnneeStats = 2018, NbButs = 1815, NbPasses = 10, NbPoints = 1825, NbPartiesJouees = 65, NbMinutesPenalites = 51, PlusseMoins = -2, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 3, AnneeStats = 2018, NbButs = 1805, NbPasses = 24, NbPoints = 1829, NbPartiesJouees = 65, NbMinutesPenalites = 35, PlusseMoins = 25, ButsAlloues = 0, TirsAlloues = 0, Victoires = 0, Defaites = 0, DefaitesEnProlongation = 0, Nulles = 0, MinutesJouees = 500 },
                    new StatsJoueurBd { EquipeId = 1, JoueurId = 4, AnneeStats = 2018, NbButs = 1800, NbPasses = 0, NbPoints = 1800, NbPartiesJouees = 65, NbMinutesPenalites = 4, PlusseMoins = 0, ButsAlloues = 53, TirsAlloues = 564, Victoires = 9, Defaites = 2, DefaitesEnProlongation = 6, Nulles = 0, MinutesJouees = 1500 }
                );
            
            modelBuilder.Entity<StatsEquipeBd>()
                .HasData(
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2023, NbPartiesJouees = 82, NbVictoires = 50, NbDefaites = 20, NbDefProlo = 12, NbButsPour = 380, NbButsContre = 267 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2023, NbPartiesJouees = 82, NbVictoires = 45, NbDefaites = 26, NbDefProlo = 11, NbButsPour = 315, NbButsContre = 287 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2023, NbPartiesJouees = 82, NbVictoires = 44, NbDefaites = 30, NbDefProlo = 8, NbButsPour = 300, NbButsContre = 307 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2023, NbPartiesJouees = 82, NbVictoires = 34, NbDefaites = 40, NbDefProlo = 8, NbButsPour = 280, NbButsContre = 337 },
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2022, NbPartiesJouees = 82, NbVictoires = 50, NbDefaites = 20, NbDefProlo = 12, NbButsPour = 380, NbButsContre = 267 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2022, NbPartiesJouees = 82, NbVictoires = 45, NbDefaites = 26, NbDefProlo = 11, NbButsPour = 315, NbButsContre = 287 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2022, NbPartiesJouees = 82, NbVictoires = 44, NbDefaites = 30, NbDefProlo = 8, NbButsPour = 300, NbButsContre = 307 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2022, NbPartiesJouees = 82, NbVictoires = 34, NbDefaites = 40, NbDefProlo = 8, NbButsPour = 280, NbButsContre = 337 },
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2021, NbPartiesJouees = 82, NbVictoires = 50, NbDefaites = 20, NbDefProlo = 12, NbButsPour = 380, NbButsContre = 267 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2021, NbPartiesJouees = 82, NbVictoires = 45, NbDefaites = 26, NbDefProlo = 11, NbButsPour = 315, NbButsContre = 287 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2021, NbPartiesJouees = 82, NbVictoires = 44, NbDefaites = 30, NbDefProlo = 8, NbButsPour = 300, NbButsContre = 307 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2021, NbPartiesJouees = 82, NbVictoires = 34, NbDefaites = 40, NbDefProlo = 8, NbButsPour = 280, NbButsContre = 337 },
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2020, NbPartiesJouees = 82, NbVictoires = 50, NbDefaites = 20, NbDefProlo = 12, NbButsPour = 380, NbButsContre = 267 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2020, NbPartiesJouees = 82, NbVictoires = 45, NbDefaites = 26, NbDefProlo = 11, NbButsPour = 315, NbButsContre = 287 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2020, NbPartiesJouees = 82, NbVictoires = 44, NbDefaites = 30, NbDefProlo = 8, NbButsPour = 300, NbButsContre = 307 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2020, NbPartiesJouees = 82, NbVictoires = 34, NbDefaites = 40, NbDefProlo = 8, NbButsPour = 280, NbButsContre = 337 },
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2019, NbPartiesJouees = 82, NbVictoires = 43, NbDefaites = 29, NbDefProlo = 10, NbButsPour = 330, NbButsContre = 290 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2019, NbPartiesJouees = 82, NbVictoires = 48, NbDefaites = 21, NbDefProlo = 13, NbButsPour = 345, NbButsContre = 255 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2019, NbPartiesJouees = 82, NbVictoires = 46, NbDefaites = 26, NbDefProlo = 10, NbButsPour = 320, NbButsContre = 295 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2019, NbPartiesJouees = 82, NbVictoires = 38, NbDefaites = 33, NbDefProlo = 11, NbButsPour = 311, NbButsContre = 307 },
                    new StatsEquipeBd { EquipeId = 1, AnneeStats = 2018, NbPartiesJouees = 82, NbVictoires = 33, NbDefaites = 34, NbDefProlo = 15, NbButsPour = 310, NbButsContre = 312 },
                    new StatsEquipeBd { EquipeId = 2, AnneeStats = 2018, NbPartiesJouees = 82, NbVictoires = 45, NbDefaites = 23, NbDefProlo = 14, NbButsPour = 340, NbButsContre = 275 },
                    new StatsEquipeBd { EquipeId = 3, AnneeStats = 2018, NbPartiesJouees = 82, NbVictoires = 47, NbDefaites = 26, NbDefProlo = 9, NbButsPour = 340, NbButsContre = 298 },
                    new StatsEquipeBd { EquipeId = 4, AnneeStats = 2018, NbPartiesJouees = 82, NbVictoires = 41, NbDefaites = 31, NbDefProlo = 10, NbButsPour = 341, NbButsContre = 280 }
                );
        }
    }
}
