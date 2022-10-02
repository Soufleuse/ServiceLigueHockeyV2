using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Models.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEquipe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnneeDebut = table.Column<int>(type: "int", nullable: false),
                    AnneeFin = table.Column<int>(type: "int", nullable: true),
                    EstDevenueEquipe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VilleNaissance = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaysOrigine = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipeJoueur",
                columns: table => new
                {
                    JoueurId = table.Column<int>(type: "int", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    DateDebutAvecEquipe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinAvecEquipe = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoDossard = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeJoueur", x => new { x.EquipeId, x.JoueurId, x.DateDebutAvecEquipe });
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Joueur_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatsJoueur",
                columns: table => new
                {
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    JoueurId = table.Column<int>(type: "int", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    NbPartiesJouees = table.Column<short>(type: "smallint", nullable: false),
                    NbButs = table.Column<short>(type: "smallint", nullable: false),
                    NbPasses = table.Column<short>(type: "smallint", nullable: false),
                    NbPoints = table.Column<short>(type: "smallint", nullable: false),
                    NbMinutesPenalites = table.Column<short>(type: "smallint", nullable: false),
                    PlusseMoins = table.Column<short>(type: "smallint", nullable: false),
                    Victoires = table.Column<short>(type: "smallint", nullable: false),
                    Defaites = table.Column<short>(type: "smallint", nullable: false),
                    Nulles = table.Column<short>(type: "smallint", nullable: false),
                    DefaitesEnProlongation = table.Column<short>(type: "smallint", nullable: false),
                    ButsAlloues = table.Column<int>(type: "int", nullable: false),
                    TirsAlloues = table.Column<int>(type: "int", nullable: false),
                    MinutesJouees = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsJoueur", x => new { x.JoueurId, x.EquipeId, x.AnneeStats });
                    table.ForeignKey(
                        name: "FK_StatsJoueur_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatsJoueur_Joueur_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_JoueurId",
                table: "EquipeJoueur",
                column: "JoueurId");

            migrationBuilder.CreateIndex(
                name: "IX_StatsJoueur_EquipeId",
                table: "StatsJoueur",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeJoueur");

            migrationBuilder.DropTable(
                name: "StatsJoueur");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Joueur");
        }
    }
}
