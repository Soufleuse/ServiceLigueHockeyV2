using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutCalendrier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnneeStats",
                columns: table => new
                {
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    DescnCourte = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescnLongue = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnneeStats", x => x.AnneeStats);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parametres",
                columns: table => new
                {
                    nom = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    valeur = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dateFin = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametres", x => new { x.nom, x.dateDebut });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TypePenalites",
                columns: table => new
                {
                    IdTypePenalite = table.Column<short>(type: "smallint", nullable: false),
                    NbreMinutesPenalitesPourCetteInfraction = table.Column<int>(type: "int", nullable: false),
                    DescriptionPenalite = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePenalites", x => x.IdTypePenalite);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Calendrier",
                columns: table => new
                {
                    IdPartie = table.Column<int>(type: "int", nullable: false),
                    DatePartieJouee = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    NbreButsComptesParHote = table.Column<short>(type: "smallint", nullable: true),
                    NbreButsComptesParVisiteur = table.Column<short>(type: "smallint", nullable: true),
                    AFiniEnProlongation = table.Column<string>(type: "varchar(1)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AFiniEnTirDeBarrage = table.Column<string>(type: "varchar(1)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstUnePartieDeSerie = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstUnePartiePresaison = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstUnePartieSaisonReguliere = table.Column<string>(type: "varchar(1)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SommairePartie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEquipeHote = table.Column<int>(type: "int", nullable: false),
                    IdEquipeVisiteuse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendrier", x => x.IdPartie);
                    table.ForeignKey(
                        name: "FK_Calendrier_AnneeStats_AnneeStats",
                        column: x => x.AnneeStats,
                        principalTable: "AnneeStats",
                        principalColumn: "AnneeStats");
                    table.ForeignKey(
                        name: "FK_Calendrier_Equipe_IdEquipeHote",
                        column: x => x.IdEquipeHote,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Calendrier_Equipe_IdEquipeVisiteuse",
                        column: x => x.IdEquipeVisiteuse,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeuillePointage",
                columns: table => new
                {
                    MomentDuButMarque = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    IdPartie = table.Column<int>(type: "int", nullable: false),
                    IdJoueurButMarque = table.Column<int>(type: "int", nullable: false),
                    IdJoueurPremiereAssistance = table.Column<int>(type: "int", nullable: true),
                    IdJoueurSecondeAssistance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeuillePointage", x => new { x.IdPartie, x.MomentDuButMarque });
                    table.ForeignKey(
                        name: "FK_FeuillePointage_Calendrier_IdPartie",
                        column: x => x.IdPartie,
                        principalTable: "Calendrier",
                        principalColumn: "IdPartie");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Penalites",
                columns: table => new
                {
                    MomentDelaPenalite = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    IdPartie = table.Column<int>(type: "int", nullable: false),
                    IdJoueurPenalise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalites", x => new { x.MomentDelaPenalite, x.IdPartie });
                    table.ForeignKey(
                        name: "FK_Penalites_Calendrier_IdPartie",
                        column: x => x.IdPartie,
                        principalTable: "Calendrier",
                        principalColumn: "IdPartie");
                    table.ForeignKey(
                        name: "FK_Penalites_Joueur_IdJoueurPenalise",
                        column: x => x.IdJoueurPenalise,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Penalite_TypePenalite",
                columns: table => new
                {
                    IdPenalite = table.Column<int>(type: "int", nullable: false),
                    IdTypePenalite = table.Column<short>(type: "smallint", nullable: false),
                    MomentDelaPenalite = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    IdJoueurPenalise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalite_TypePenalite", x => x.IdPenalite);
                    table.ForeignKey(
                        name: "FK_Penalite_TypePenalite_Penalites_MomentDelaPenalite_IdJoueurP~",
                        columns: x => new { x.MomentDelaPenalite, x.IdJoueurPenalise },
                        principalTable: "Penalites",
                        principalColumns: new[] { "MomentDelaPenalite", "IdPartie" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Penalite_TypePenalite_TypePenalites_IdTypePenalite",
                        column: x => x.IdTypePenalite,
                        principalTable: "TypePenalites",
                        principalColumn: "IdTypePenalite",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AnneeStats",
                columns: new[] { "AnneeStats", "DescnCourte", "DescnLongue" },
                values: new object[,]
                {
                    { (short)2017, "2017/2018", "Représente la saison 2017/2018" },
                    { (short)2018, "2018/2019", "Représente la saison 2018/2019" },
                    { (short)2019, "2019/2020", "Représente la saison 2019/2020" },
                    { (short)2020, "2020/2021", "Représente la saison 2020/2021" },
                    { (short)2021, "2021/2022", "Représente la saison 2021/2022" },
                    { (short)2022, "2022/2023", "Représente la saison 2022/2023" },
                    { (short)2023, "2023/2024", "Représente la saison 2023/2024" },
                    { (short)2024, "2024/2025", "Représente la saison 2024/2025" }
                });

            migrationBuilder.InsertData(
                table: "Parametres",
                columns: new[] { "dateDebut", "nom", "dateFin", "valeur" },
                values: new object[,]
                {
                    { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AjoutSteve", null, "ma valeur" },
                    { new DateTime(1995, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2004, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "82" },
                    { new DateTime(2004, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2005, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "0" },
                    { new DateTime(2005, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2012, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "82" },
                    { new DateTime(2012, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2013, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "48" },
                    { new DateTime(2013, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2019, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "82" },
                    { new DateTime(2019, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "71" },
                    { new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", new DateTime(2021, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "56" },
                    { new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "nombrePartiesJouees", null, "82" }
                });

            migrationBuilder.InsertData(
                table: "TypePenalites",
                columns: new[] { "IdTypePenalite", "DescriptionPenalite", "NbreMinutesPenalitesPourCetteInfraction" },
                values: new object[,]
                {
                    { (short)1, "Mineure", 2 },
                    { (short)2, "Majeure", 5 },
                    { (short)3, "Inconduite de partie", 10 }
                });

            migrationBuilder.InsertData(
                table: "Calendrier",
                columns: new[] { "IdPartie", "AFiniEnProlongation", "AFiniEnTirDeBarrage", "AnneeStats", "DatePartieJouee", "EstUnePartieDeSerie", "EstUnePartiePresaison", "EstUnePartieSaisonReguliere", "IdEquipeHote", "IdEquipeVisiteuse", "NbreButsComptesParHote", "NbreButsComptesParVisiteur", "SommairePartie" },
                values: new object[] { 1, null, null, (short)2024, new DateTime(2024, 10, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), "N", "N", "O", 1, 2, null, null, "" });

            migrationBuilder.CreateIndex(
                name: "IX_Calendrier_AnneeStats",
                table: "Calendrier",
                column: "AnneeStats");

            migrationBuilder.CreateIndex(
                name: "IX_Calendrier_IdEquipeHote_IdEquipeVisiteuse_DatePartieJouee",
                table: "Calendrier",
                columns: new[] { "IdEquipeHote", "IdEquipeVisiteuse", "DatePartieJouee" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calendrier_IdEquipeVisiteuse",
                table: "Calendrier",
                column: "IdEquipeVisiteuse");

            migrationBuilder.CreateIndex(
                name: "IX_Penalite_TypePenalite_IdTypePenalite",
                table: "Penalite_TypePenalite",
                column: "IdTypePenalite");

            migrationBuilder.CreateIndex(
                name: "IX_Penalite_TypePenalite_MomentDelaPenalite_IdJoueurPenalise",
                table: "Penalite_TypePenalite",
                columns: new[] { "MomentDelaPenalite", "IdJoueurPenalise" });

            migrationBuilder.CreateIndex(
                name: "IX_Penalites_IdJoueurPenalise",
                table: "Penalites",
                column: "IdJoueurPenalise");

            migrationBuilder.CreateIndex(
                name: "IX_Penalites_IdPartie",
                table: "Penalites",
                column: "IdPartie");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeuillePointage");

            migrationBuilder.DropTable(
                name: "Parametres");

            migrationBuilder.DropTable(
                name: "Penalite_TypePenalite");

            migrationBuilder.DropTable(
                name: "Penalites");

            migrationBuilder.DropTable(
                name: "TypePenalites");

            migrationBuilder.DropTable(
                name: "Calendrier");

            migrationBuilder.DropTable(
                name: "AnneeStats");
        }
    }
}
