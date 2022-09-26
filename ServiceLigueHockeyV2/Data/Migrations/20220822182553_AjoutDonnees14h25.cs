using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Migrations
{
    public partial class AjoutDonnees14h25 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Equipe_equipeBdNo_Equipe",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Joueur_joueurBdNo_Joueur",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Equipe_equipeBdNo_Equipe",
                table: "StatsJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Joueur_No_Joueur",
                table: "StatsJoueur");

            migrationBuilder.RenameColumn(
                name: "equipeBdNo_Equipe",
                table: "StatsJoueur",
                newName: "equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "No_Equipe",
                table: "StatsJoueur",
                newName: "EquipeFK");

            migrationBuilder.RenameColumn(
                name: "No_Joueur",
                table: "StatsJoueur",
                newName: "JoueurFK");

            migrationBuilder.RenameIndex(
                name: "IX_StatsJoueur_equipeBdNo_Equipe",
                table: "StatsJoueur",
                newName: "IX_StatsJoueur_equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "Ville_naissance",
                table: "Joueur",
                newName: "VilleNaissance");

            migrationBuilder.RenameColumn(
                name: "Pays_origine",
                table: "Joueur",
                newName: "PaysOrigine");

            migrationBuilder.RenameColumn(
                name: "Date_Naissance",
                table: "Joueur",
                newName: "DateNaissance");

            migrationBuilder.RenameColumn(
                name: "No_Joueur",
                table: "Joueur",
                newName: "JoueurId");

            migrationBuilder.RenameColumn(
                name: "no_dossard",
                table: "EquipeJoueur",
                newName: "NoDossard");

            migrationBuilder.RenameColumn(
                name: "joueurBdNo_Joueur",
                table: "EquipeJoueur",
                newName: "joueurBdJoueurId");

            migrationBuilder.RenameColumn(
                name: "equipeBdNo_Equipe",
                table: "EquipeJoueur",
                newName: "equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "date_fin_avec_equipe",
                table: "EquipeJoueur",
                newName: "DateFinAvecEquipe");

            migrationBuilder.RenameColumn(
                name: "date_debut_avec_equipe",
                table: "EquipeJoueur",
                newName: "DateDebutAvecEquipe");

            migrationBuilder.RenameColumn(
                name: "No_Joueur",
                table: "EquipeJoueur",
                newName: "JoueurFK");

            migrationBuilder.RenameColumn(
                name: "No_Equipe",
                table: "EquipeJoueur",
                newName: "EquipeFK");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_joueurBdNo_Joueur",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_joueurBdJoueurId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_equipeBdNo_Equipe",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "Nom_Equipe",
                table: "Equipe",
                newName: "NomEquipe");

            migrationBuilder.RenameColumn(
                name: "Est_Devenue_Equipe",
                table: "Equipe",
                newName: "EstDevenueEquipe");

            migrationBuilder.RenameColumn(
                name: "Annee_fin",
                table: "Equipe",
                newName: "AnneeFin");

            migrationBuilder.RenameColumn(
                name: "Annee_debut",
                table: "Equipe",
                newName: "AnneeDebut");

            migrationBuilder.RenameColumn(
                name: "No_Equipe",
                table: "Equipe",
                newName: "EquipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Equipe_equipeBdEquipeId",
                table: "EquipeJoueur",
                column: "equipeBdEquipeId",
                principalTable: "Equipe",
                principalColumn: "EquipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Joueur_joueurBdJoueurId",
                table: "EquipeJoueur",
                column: "joueurBdJoueurId",
                principalTable: "Joueur",
                principalColumn: "JoueurId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Equipe_equipeBdEquipeId",
                table: "StatsJoueur",
                column: "equipeBdEquipeId",
                principalTable: "Equipe",
                principalColumn: "EquipeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Joueur_JoueurFK",
                table: "StatsJoueur",
                column: "JoueurFK",
                principalTable: "Joueur",
                principalColumn: "JoueurId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Equipe_equipeBdEquipeId",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Joueur_joueurBdJoueurId",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Equipe_equipeBdEquipeId",
                table: "StatsJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Joueur_JoueurFK",
                table: "StatsJoueur");

            migrationBuilder.RenameColumn(
                name: "equipeBdEquipeId",
                table: "StatsJoueur",
                newName: "equipeBdNo_Equipe");

            migrationBuilder.RenameColumn(
                name: "EquipeFK",
                table: "StatsJoueur",
                newName: "No_Equipe");

            migrationBuilder.RenameColumn(
                name: "JoueurFK",
                table: "StatsJoueur",
                newName: "No_Joueur");

            migrationBuilder.RenameIndex(
                name: "IX_StatsJoueur_equipeBdEquipeId",
                table: "StatsJoueur",
                newName: "IX_StatsJoueur_equipeBdNo_Equipe");

            migrationBuilder.RenameColumn(
                name: "VilleNaissance",
                table: "Joueur",
                newName: "Ville_naissance");

            migrationBuilder.RenameColumn(
                name: "PaysOrigine",
                table: "Joueur",
                newName: "Pays_origine");

            migrationBuilder.RenameColumn(
                name: "DateNaissance",
                table: "Joueur",
                newName: "Date_Naissance");

            migrationBuilder.RenameColumn(
                name: "JoueurId",
                table: "Joueur",
                newName: "No_Joueur");

            migrationBuilder.RenameColumn(
                name: "joueurBdJoueurId",
                table: "EquipeJoueur",
                newName: "joueurBdNo_Joueur");

            migrationBuilder.RenameColumn(
                name: "equipeBdEquipeId",
                table: "EquipeJoueur",
                newName: "equipeBdNo_Equipe");

            migrationBuilder.RenameColumn(
                name: "NoDossard",
                table: "EquipeJoueur",
                newName: "no_dossard");

            migrationBuilder.RenameColumn(
                name: "DateFinAvecEquipe",
                table: "EquipeJoueur",
                newName: "date_fin_avec_equipe");

            migrationBuilder.RenameColumn(
                name: "DateDebutAvecEquipe",
                table: "EquipeJoueur",
                newName: "date_debut_avec_equipe");

            migrationBuilder.RenameColumn(
                name: "JoueurFK",
                table: "EquipeJoueur",
                newName: "No_Joueur");

            migrationBuilder.RenameColumn(
                name: "EquipeFK",
                table: "EquipeJoueur",
                newName: "No_Equipe");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_joueurBdJoueurId",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_joueurBdNo_Joueur");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_equipeBdEquipeId",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_equipeBdNo_Equipe");

            migrationBuilder.RenameColumn(
                name: "NomEquipe",
                table: "Equipe",
                newName: "Nom_Equipe");

            migrationBuilder.RenameColumn(
                name: "EstDevenueEquipe",
                table: "Equipe",
                newName: "Est_Devenue_Equipe");

            migrationBuilder.RenameColumn(
                name: "AnneeFin",
                table: "Equipe",
                newName: "Annee_fin");

            migrationBuilder.RenameColumn(
                name: "AnneeDebut",
                table: "Equipe",
                newName: "Annee_debut");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "Equipe",
                newName: "No_Equipe");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Equipe_equipeBdNo_Equipe",
                table: "EquipeJoueur",
                column: "equipeBdNo_Equipe",
                principalTable: "Equipe",
                principalColumn: "No_Equipe",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Joueur_joueurBdNo_Joueur",
                table: "EquipeJoueur",
                column: "joueurBdNo_Joueur",
                principalTable: "Joueur",
                principalColumn: "No_Joueur",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Equipe_equipeBdNo_Equipe",
                table: "StatsJoueur",
                column: "equipeBdNo_Equipe",
                principalTable: "Equipe",
                principalColumn: "No_Equipe",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Joueur_No_Joueur",
                table: "StatsJoueur",
                column: "No_Joueur",
                principalTable: "Joueur",
                principalColumn: "No_Joueur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
