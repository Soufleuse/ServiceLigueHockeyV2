using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutStatsEquipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Joueur",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Equipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateTable(
                name: "StatsEquipe",
                columns: table => new
                {
                    AnneeStats = table.Column<short>(type: "smallint", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    NbPartiesJouees = table.Column<short>(type: "smallint", nullable: false),
                    NbVictoires = table.Column<short>(type: "smallint", nullable: false),
                    NbDefaites = table.Column<short>(type: "smallint", nullable: false),
                    NbDefProlo = table.Column<short>(type: "smallint", nullable: true),
                    NbButsPour = table.Column<int>(type: "int", nullable: false),
                    NbButsContre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatsEquipe", x => new { x.EquipeId, x.AnneeStats });
                    table.ForeignKey(
                        name: "FK_StatsEquipe_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "StatsEquipe",
                columns: new[] { "AnneeStats", "EquipeId", "NbButsContre", "NbButsPour", "NbDefProlo", "NbDefaites", "NbPartiesJouees", "NbVictoires" },
                values: new object[,]
                {
                    { (short)2018, 1, 312, 310, (short)15, (short)34, (short)82, (short)33 },
                    { (short)2019, 1, 290, 330, (short)10, (short)29, (short)82, (short)43 },
                    { (short)2020, 1, 267, 380, (short)12, (short)20, (short)82, (short)50 },
                    { (short)2018, 2, 275, 340, (short)14, (short)23, (short)82, (short)45 },
                    { (short)2019, 2, 255, 345, (short)13, (short)21, (short)82, (short)48 },
                    { (short)2020, 2, 287, 315, (short)11, (short)26, (short)82, (short)45 },
                    { (short)2018, 3, 298, 340, (short)9, (short)26, (short)82, (short)47 },
                    { (short)2019, 3, 295, 320, (short)10, (short)26, (short)82, (short)46 },
                    { (short)2020, 3, 307, 300, (short)8, (short)30, (short)82, (short)44 },
                    { (short)2018, 4, 280, 341, (short)10, (short)31, (short)82, (short)41 },
                    { (short)2019, 4, 307, 311, (short)11, (short)33, (short)82, (short)38 },
                    { (short)2020, 4, 337, 280, (short)8, (short)40, (short)82, (short)34 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatsEquipe");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Joueur",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Equipe",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
