using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Migrations
{
    public partial class AjoutDonnees15h24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatsJoueur",
                table: "StatsJoueur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeJoueur",
                table: "EquipeJoueur");

            migrationBuilder.DropIndex(
                name: "IX_EquipeJoueur_equipeBdEquipeId",
                table: "EquipeJoueur");

            migrationBuilder.DropColumn(
                name: "JoueurFK",
                table: "StatsJoueur");

            migrationBuilder.DropColumn(
                name: "EquipeFK",
                table: "EquipeJoueur");

            migrationBuilder.DropColumn(
                name: "JoueurFK",
                table: "EquipeJoueur");

            migrationBuilder.RenameColumn(
                name: "equipeBdEquipeId",
                table: "StatsJoueur",
                newName: "EquipeId");

            migrationBuilder.RenameColumn(
                name: "EquipeFK",
                table: "StatsJoueur",
                newName: "JoueurId");

            migrationBuilder.RenameIndex(
                name: "IX_StatsJoueur_equipeBdEquipeId",
                table: "StatsJoueur",
                newName: "IX_StatsJoueur_EquipeId");

            migrationBuilder.RenameColumn(
                name: "JoueurId",
                table: "Joueur",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "joueurBdJoueurId",
                table: "EquipeJoueur",
                newName: "JoueurId");

            migrationBuilder.RenameColumn(
                name: "equipeBdEquipeId",
                table: "EquipeJoueur",
                newName: "EquipeId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_joueurBdJoueurId",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_JoueurId");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "Equipe",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatsJoueur",
                table: "StatsJoueur",
                columns: new[] { "JoueurId", "EquipeId", "AnneeStats" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeJoueur",
                table: "EquipeJoueur",
                columns: new[] { "EquipeId", "JoueurId", "DateDebutAvecEquipe" });

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Equipe_EquipeId",
                table: "EquipeJoueur",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeJoueur_Joueur_JoueurId",
                table: "EquipeJoueur",
                column: "JoueurId",
                principalTable: "Joueur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Equipe_EquipeId",
                table: "StatsJoueur",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatsJoueur_Joueur_JoueurId",
                table: "StatsJoueur",
                column: "JoueurId",
                principalTable: "Joueur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Equipe_EquipeId",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeJoueur_Joueur_JoueurId",
                table: "EquipeJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Equipe_EquipeId",
                table: "StatsJoueur");

            migrationBuilder.DropForeignKey(
                name: "FK_StatsJoueur_Joueur_JoueurId",
                table: "StatsJoueur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatsJoueur",
                table: "StatsJoueur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeJoueur",
                table: "EquipeJoueur");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "StatsJoueur",
                newName: "equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "JoueurId",
                table: "StatsJoueur",
                newName: "EquipeFK");

            migrationBuilder.RenameIndex(
                name: "IX_StatsJoueur_EquipeId",
                table: "StatsJoueur",
                newName: "IX_StatsJoueur_equipeBdEquipeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Joueur",
                newName: "JoueurId");

            migrationBuilder.RenameColumn(
                name: "JoueurId",
                table: "EquipeJoueur",
                newName: "joueurBdJoueurId");

            migrationBuilder.RenameColumn(
                name: "EquipeId",
                table: "EquipeJoueur",
                newName: "equipeBdEquipeId");

            migrationBuilder.RenameIndex(
                name: "IX_EquipeJoueur_JoueurId",
                table: "EquipeJoueur",
                newName: "IX_EquipeJoueur_joueurBdJoueurId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Equipe",
                newName: "EquipeId");

            migrationBuilder.AddColumn<int>(
                name: "JoueurFK",
                table: "StatsJoueur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipeFK",
                table: "EquipeJoueur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JoueurFK",
                table: "EquipeJoueur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatsJoueur",
                table: "StatsJoueur",
                columns: new[] { "JoueurFK", "EquipeFK", "AnneeStats" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeJoueur",
                table: "EquipeJoueur",
                columns: new[] { "EquipeFK", "JoueurFK", "DateDebutAvecEquipe" });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_equipeBdEquipeId",
                table: "EquipeJoueur",
                column: "equipeBdEquipeId");

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
    }
}
