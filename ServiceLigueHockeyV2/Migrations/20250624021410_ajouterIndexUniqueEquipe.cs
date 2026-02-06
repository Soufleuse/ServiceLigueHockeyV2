using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class ajouterIndexUniqueEquipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Equipe_NomEquipe_Ville",
                table: "Equipe",
                columns: new[] { "NomEquipe", "Ville" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipe_NomEquipe_Ville",
                table: "Equipe");
        }
    }
}
