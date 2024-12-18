using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutStatsDonneesDiverses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StatsEquipe",
                columns: new[] { "AnneeStats", "EquipeId", "NbButsContre", "NbButsPour", "NbDefProlo", "NbDefaites", "NbPartiesJouees", "NbVictoires" },
                values: new object[,]
                {
                    { (short)2021, 1, 267, 380, (short)12, (short)20, (short)82, (short)50 },
                    { (short)2022, 1, 267, 380, (short)12, (short)20, (short)82, (short)50 },
                    { (short)2023, 1, 267, 380, (short)12, (short)20, (short)82, (short)50 },
                    { (short)2021, 2, 287, 315, (short)11, (short)26, (short)82, (short)45 },
                    { (short)2022, 2, 287, 315, (short)11, (short)26, (short)82, (short)45 },
                    { (short)2023, 2, 287, 315, (short)11, (short)26, (short)82, (short)45 },
                    { (short)2021, 3, 307, 300, (short)8, (short)30, (short)82, (short)44 },
                    { (short)2022, 3, 307, 300, (short)8, (short)30, (short)82, (short)44 },
                    { (short)2023, 3, 307, 300, (short)8, (short)30, (short)82, (short)44 },
                    { (short)2021, 4, 337, 280, (short)8, (short)40, (short)82, (short)34 },
                    { (short)2022, 4, 337, 280, (short)8, (short)40, (short)82, (short)34 },
                    { (short)2023, 4, 337, 280, (short)8, (short)40, (short)82, (short)34 }
                });

            migrationBuilder.InsertData(
                table: "StatsJoueur",
                columns: new[] { "AnneeStats", "EquipeId", "JoueurId", "ButsAlloues", "Defaites", "DefaitesEnProlongation", "MinutesJouees", "NbButs", "NbMinutesPenalites", "NbPartiesJouees", "NbPasses", "NbPoints", "Nulles", "PlusseMoins", "TirsAlloues", "Victoires" },
                values: new object[,]
                {
                    { (short)2021, 1, 1, 0, (short)0, (short)0, 500.0, (short)10, (short)15, (short)25, (short)20, (short)30, (short)0, (short)5, 0, (short)0 },
                    { (short)2022, 1, 1, 0, (short)0, (short)0, 500.0, (short)10, (short)15, (short)25, (short)20, (short)30, (short)0, (short)5, 0, (short)0 },
                    { (short)2023, 1, 1, 0, (short)0, (short)0, 500.0, (short)10, (short)15, (short)25, (short)20, (short)30, (short)0, (short)5, 0, (short)0 },
                    { (short)2021, 1, 2, 0, (short)0, (short)0, 500.0, (short)15, (short)51, (short)25, (short)10, (short)25, (short)0, (short)-2, 0, (short)0 },
                    { (short)2022, 1, 2, 0, (short)0, (short)0, 500.0, (short)15, (short)51, (short)25, (short)10, (short)25, (short)0, (short)-2, 0, (short)0 },
                    { (short)2023, 1, 2, 0, (short)0, (short)0, 500.0, (short)15, (short)51, (short)25, (short)10, (short)25, (short)0, (short)-2, 0, (short)0 },
                    { (short)2021, 1, 3, 0, (short)0, (short)0, 500.0, (short)5, (short)35, (short)25, (short)24, (short)29, (short)0, (short)25, 0, (short)0 },
                    { (short)2022, 1, 3, 0, (short)0, (short)0, 500.0, (short)5, (short)35, (short)25, (short)24, (short)29, (short)0, (short)25, 0, (short)0 },
                    { (short)2023, 1, 3, 0, (short)0, (short)0, 500.0, (short)5, (short)35, (short)25, (short)24, (short)29, (short)0, (short)25, 0, (short)0 },
                    { (short)2021, 1, 4, 53, (short)2, (short)6, 1500.0, (short)0, (short)4, (short)25, (short)0, (short)0, (short)0, (short)0, 564, (short)9 },
                    { (short)2022, 1, 4, 53, (short)2, (short)6, 1500.0, (short)0, (short)4, (short)25, (short)0, (short)0, (short)0, (short)0, 564, (short)9 },
                    { (short)2023, 1, 4, 53, (short)2, (short)6, 1500.0, (short)0, (short)4, (short)25, (short)0, (short)0, (short)0, (short)0, 564, (short)9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2021, 1 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2022, 1 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2023, 1 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2021, 2 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2022, 2 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2023, 2 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2021, 3 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2022, 3 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2023, 3 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2021, 4 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2022, 4 });

            migrationBuilder.DeleteData(
                table: "StatsEquipe",
                keyColumns: new[] { "AnneeStats", "EquipeId" },
                keyValues: new object[] { (short)2023, 4 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2021, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2022, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2023, 1, 1 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2021, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2022, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2023, 1, 2 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2021, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2022, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2023, 1, 3 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2021, 1, 4 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2022, 1, 4 });

            migrationBuilder.DeleteData(
                table: "StatsJoueur",
                keyColumns: new[] { "AnneeStats", "EquipeId", "JoueurId" },
                keyValues: new object[] { (short)2023, 1, 4 });
        }
    }
}
