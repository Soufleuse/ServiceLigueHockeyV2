using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class ModifierNomTableCalendrier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendrier_AnneeStats_AnneeStats",
                table: "Calendrier");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendrier_Equipe_IdEquipeHote",
                table: "Calendrier");

            migrationBuilder.DropForeignKey(
                name: "FK_Calendrier_Equipe_IdEquipeVisiteuse",
                table: "Calendrier");

            migrationBuilder.DropForeignKey(
                name: "FK_FeuillePointage_Calendrier_IdPartie",
                table: "FeuillePointage");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Calendrier_IdPartie",
                table: "Penalites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calendrier",
                table: "Calendrier");

            migrationBuilder.RenameTable(
                name: "Calendrier",
                newName: "Partie");

            migrationBuilder.RenameIndex(
                name: "IX_Calendrier_IdEquipeVisiteuse",
                table: "Partie",
                newName: "IX_Partie_IdEquipeVisiteuse");

            migrationBuilder.RenameIndex(
                name: "IX_Calendrier_IdEquipeHote_IdEquipeVisiteuse_DatePartieJouee",
                table: "Partie",
                newName: "IX_Partie_IdEquipeHote_IdEquipeVisiteuse_DatePartieJouee");

            migrationBuilder.RenameIndex(
                name: "IX_Calendrier_AnneeStats",
                table: "Partie",
                newName: "IX_Partie_AnneeStats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partie",
                table: "Partie",
                column: "IdPartie");

            migrationBuilder.AddForeignKey(
                name: "FK_FeuillePointage_Partie_IdPartie",
                table: "FeuillePointage",
                column: "IdPartie",
                principalTable: "Partie",
                principalColumn: "IdPartie");

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_AnneeStats_AnneeStats",
                table: "Partie",
                column: "AnneeStats",
                principalTable: "AnneeStats",
                principalColumn: "AnneeStats");

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_Equipe_IdEquipeHote",
                table: "Partie",
                column: "IdEquipeHote",
                principalTable: "Equipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partie_Equipe_IdEquipeVisiteuse",
                table: "Partie",
                column: "IdEquipeVisiteuse",
                principalTable: "Equipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalites_Partie_IdPartie",
                table: "Penalites",
                column: "IdPartie",
                principalTable: "Partie",
                principalColumn: "IdPartie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeuillePointage_Partie_IdPartie",
                table: "FeuillePointage");

            migrationBuilder.DropForeignKey(
                name: "FK_Partie_AnneeStats_AnneeStats",
                table: "Partie");

            migrationBuilder.DropForeignKey(
                name: "FK_Partie_Equipe_IdEquipeHote",
                table: "Partie");

            migrationBuilder.DropForeignKey(
                name: "FK_Partie_Equipe_IdEquipeVisiteuse",
                table: "Partie");

            migrationBuilder.DropForeignKey(
                name: "FK_Penalites_Partie_IdPartie",
                table: "Penalites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partie",
                table: "Partie");

            migrationBuilder.RenameTable(
                name: "Partie",
                newName: "Calendrier");

            migrationBuilder.RenameIndex(
                name: "IX_Partie_IdEquipeVisiteuse",
                table: "Calendrier",
                newName: "IX_Calendrier_IdEquipeVisiteuse");

            migrationBuilder.RenameIndex(
                name: "IX_Partie_IdEquipeHote_IdEquipeVisiteuse_DatePartieJouee",
                table: "Calendrier",
                newName: "IX_Calendrier_IdEquipeHote_IdEquipeVisiteuse_DatePartieJouee");

            migrationBuilder.RenameIndex(
                name: "IX_Partie_AnneeStats",
                table: "Calendrier",
                newName: "IX_Calendrier_AnneeStats");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calendrier",
                table: "Calendrier",
                column: "IdPartie");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendrier_AnneeStats_AnneeStats",
                table: "Calendrier",
                column: "AnneeStats",
                principalTable: "AnneeStats",
                principalColumn: "AnneeStats");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendrier_Equipe_IdEquipeHote",
                table: "Calendrier",
                column: "IdEquipeHote",
                principalTable: "Equipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendrier_Equipe_IdEquipeVisiteuse",
                table: "Calendrier",
                column: "IdEquipeVisiteuse",
                principalTable: "Equipe",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeuillePointage_Calendrier_IdPartie",
                table: "FeuillePointage",
                column: "IdPartie",
                principalTable: "Calendrier",
                principalColumn: "IdPartie");

            migrationBuilder.AddForeignKey(
                name: "FK_Penalites_Calendrier_IdPartie",
                table: "Penalites",
                column: "IdPartie",
                principalTable: "Calendrier",
                principalColumn: "IdPartie");
        }
    }
}
