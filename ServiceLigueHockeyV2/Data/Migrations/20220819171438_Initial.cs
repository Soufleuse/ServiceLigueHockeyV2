using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceLigueHockeyV2.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    No_Equipe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom_Equipe = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Annee_debut = table.Column<int>(type: "int", nullable: false),
                    Annee_fin = table.Column<int>(type: "int", nullable: true),
                    Est_Devenue_Equipe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.No_Equipe);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    No_Joueur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date_Naissance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Ville_naissance = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pays_origine = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.No_Joueur);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EquipeJoueur",
                columns: table => new
                {
                    No_Equipe = table.Column<int>(type: "int", nullable: false),
                    No_Joueur = table.Column<int>(type: "int", nullable: false),
                    date_debut_avec_equipe = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    equipeBdNo_Equipe = table.Column<int>(type: "int", nullable: false),
                    joueurBdNo_Joueur = table.Column<int>(type: "int", nullable: false),
                    date_fin_avec_equipe = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    no_dossard = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeJoueur", x => new { x.No_Equipe, x.No_Joueur, x.date_debut_avec_equipe });
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Equipe_equipeBdNo_Equipe",
                        column: x => x.equipeBdNo_Equipe,
                        principalTable: "Equipe",
                        principalColumn: "No_Equipe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Joueur_joueurBdNo_Joueur",
                        column: x => x.joueurBdNo_Joueur,
                        principalTable: "Joueur",
                        principalColumn: "No_Joueur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StatsJoueur",
                columns: table => new
                {
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    No_Joueur = table.Column<int>(type: "int", nullable: false),
                    No_Equipe = table.Column<int>(type: "int", nullable: false),
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
                    MinutesJouees = table.Column<double>(type: "double", nullable: false),
                    equipeBdNo_Equipe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsJoueur", x => new { x.No_Joueur, x.No_Equipe, x.AnneeStats });
                    table.ForeignKey(
                        name: "FK_StatsJoueur_Equipe_equipeBdNo_Equipe",
                        column: x => x.equipeBdNo_Equipe,
                        principalTable: "Equipe",
                        principalColumn: "No_Equipe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatsJoueur_Joueur_No_Joueur",
                        column: x => x.No_Joueur,
                        principalTable: "Joueur",
                        principalColumn: "No_Joueur",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_equipeBdNo_Equipe",
                table: "EquipeJoueur",
                column: "equipeBdNo_Equipe");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_joueurBdNo_Joueur",
                table: "EquipeJoueur",
                column: "joueurBdNo_Joueur");

            migrationBuilder.CreateIndex(
                name: "IX_StatsJoueur_equipeBdNo_Equipe",
                table: "StatsJoueur",
                column: "equipeBdNo_Equipe");
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
