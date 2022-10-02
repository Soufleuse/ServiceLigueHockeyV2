using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Models.Migrations
{
    public partial class AjoutDonnees2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Joueur",
                columns: new[] { "Id", "DateNaissance", "Nom", "PaysOrigine", "Prenom", "VilleNaissance" },
                values: new object[,]
                {
                    { 1, new DateTime(1988, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tremblay", "Canada", "Jack", "Lévis" },
                    { 2, new DateTime(1996, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lajeunesse", "Canada", "Simon", "St-Stanislas" },
                    { 3, new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grandpré", "Canada", "Mathieu", "Val d'or" },
                    { 4, new DateTime(1991, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Callahan", "Canada", "Ryan", "London" },
                    { 5, new DateTime(1992, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "McCain", "États-Unis", "Drew", "Albany" },
                    { 6, new DateTime(2000, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harris", "États-Unis", "John", "Chico" },
                    { 7, new DateTime(1996, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodgers", "Canada", "Phil", "Calgary" },
                    { 8, new DateTime(1992, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguez", "Canada", "Ted", "Regina" },
                    { 9, new DateTime(1998, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemieux", "Canada", "Patrice", "Chibougamau" },
                    { 10, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Béliveau", "Canada", "Maurice", "Beauceville" },
                    { 11, new DateTime(1997, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cruz", "États-Unis", "Andrew", "Dallas" },
                    { 12, new DateTime(1991, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trout", "États-Unis", "Chris", "Eau Claire" },
                    { 13, new DateTime(1992, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Datzyuk", "États-Unis", "Sergei", "Eau Claire" }
                });

            migrationBuilder.InsertData(
                table: "EquipeJoueur",
                columns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId", "DateFinAvecEquipe", "NoDossard" },
                values: new object[,]
                {
                    { new DateTime(2008, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, (short)23 },
                    { new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null, (short)24 },
                    { new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, null, (short)25 },
                    { new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, null, (short)26 },
                    { new DateTime(2014, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, null, (short)27 },
                    { new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, null, (short)28 },
                    { new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, null, (short)29 },
                    { new DateTime(2010, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, null, (short)30 },
                    { new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, null, (short)31 },
                    { new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, null, (short)32 },
                    { new DateTime(2018, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, null, (short)33 },
                    { new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12, null, (short)34 },
                    { new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 13, null, (short)35 }
                });

            migrationBuilder.InsertData(
                table: "StatsJoueur",
                columns: new[] { "AnneeStats", "EquipeId", "JoueurId", "ButsAlloues", "Defaites", "DefaitesEnProlongation", "MinutesJouees", "NbButs", "NbMinutesPenalites", "NbPartiesJouees", "NbPasses", "NbPoints", "Nulles", "PlusseMoins", "TirsAlloues", "Victoires" },
                values: new object[,]
                {
                    { (short)2018, 1, 1, 0, (short)0, (short)0, 500.0, (short)1810, (short)15, (short)65, (short)20, (short)1830, (short)0, (short)5, 0, (short)0 },
                    { (short)2019, 1, 1, 0, (short)0, (short)0, 500.0, (short)1910, (short)15, (short)82, (short)20, (short)1930, (short)0, (short)5, 0, (short)0 },
                    { (short)2020, 1, 1, 0, (short)0, (short)0, 500.0, (short)10, (short)15, (short)25, (short)20, (short)30, (short)0, (short)5, 0, (short)0 },
                    { (short)2018, 1, 2, 0, (short)0, (short)0, 500.0, (short)1815, (short)51, (short)65, (short)10, (short)1825, (short)0, (short)-2, 0, (short)0 },
                    { (short)2019, 1, 2, 0, (short)0, (short)0, 500.0, (short)1915, (short)51, (short)82, (short)10, (short)1925, (short)0, (short)-2, 0, (short)0 },
                    { (short)2020, 1, 2, 0, (short)0, (short)0, 500.0, (short)15, (short)51, (short)25, (short)10, (short)25, (short)0, (short)-2, 0, (short)0 },
                    { (short)2018, 1, 3, 0, (short)0, (short)0, 500.0, (short)1805, (short)35, (short)65, (short)24, (short)1829, (short)0, (short)25, 0, (short)0 },
                    { (short)2019, 1, 3, 0, (short)0, (short)0, 500.0, (short)1905, (short)35, (short)82, (short)24, (short)1929, (short)0, (short)25, 0, (short)0 },
                    { (short)2020, 1, 3, 0, (short)0, (short)0, 500.0, (short)5, (short)35, (short)25, (short)24, (short)29, (short)0, (short)25, 0, (short)0 },
                    { (short)2018, 1, 4, 53, (short)2, (short)6, 1500.0, (short)1800, (short)4, (short)65, (short)0, (short)1800, (short)0, (short)0, 564, (short)9 },
                    { (short)2019, 1, 4, 53, (short)2, (short)6, 1500.0, (short)1900, (short)4, (short)82, (short)0, (short)1900, (short)0, (short)0, 564, (short)9 },
                    { (short)2020, 1, 4, 53, (short)2, (short)6, 1500.0, (short)0, (short)4, (short)25, (short)0, (short)0, (short)0, (short)0, 564, (short)9 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2008, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2016, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2013, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2014, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2010, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2018, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2018, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2011, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 12 });

            migrationBuilder.DeleteData(
                table: "EquipeJoueur",
                keyColumns: new[] { "DateDebutAvecEquipe", "EquipeId", "JoueurId" },
                keyValues: new object[] { new DateTime(2012, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 13 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2018, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2019, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2020, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2018, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2019, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2020, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2018, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2019, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2020, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2018, 1, 4 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2019, 1, 4 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2020, 1, 4 });

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Joueur",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
