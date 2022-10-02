using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Models.Migrations
{
    public partial class AjoutDonneesEquipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipe",
                columns: new[] { "Id", "AnneeDebut", "AnneeFin", "EstDevenueEquipe", "NomEquipe", "Ville" },
                values: new object[,]
                {
                    { 1, 1989, null, null, "Canadiensssss", "Mourial" },
                    { 2, 1984, null, null, "Bruns", "Albany" },
                    { 3, 1976, null, null, "Harfangs", "Hartford" },
                    { 4, 1999, null, null, "Boulettes", "Victoriaville" },
                    { 5, 2001, null, null, "Rocher", "Percé" },
                    { 6, 1986, null, null, "Pierre", "Rochester" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
