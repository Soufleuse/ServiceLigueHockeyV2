using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceLigueHockeyV2.Migrations
{
    /// <inheritdoc />
    public partial class AjoutDivisionConference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Equipe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Conference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomConference = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnneeDebut = table.Column<int>(type: "int", nullable: false),
                    AnneeFin = table.Column<int>(type: "int", nullable: true),
                    EstDevenueConference = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conference", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomDivision = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnneeDebut = table.Column<int>(type: "int", nullable: false),
                    AnneeFin = table.Column<int>(type: "int", nullable: true),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Division_Conference_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Conference",
                columns: new[] { "Id", "AnneeDebut", "AnneeFin", "EstDevenueConference", "NomConference" },
                values: new object[,]
                {
                    { 1, 1994, null, null, "Est" },
                    { 2, 1994, null, null, "Ouest" }
                });

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 1,
                column: "DivisionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 2,
                column: "DivisionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 3,
                column: "DivisionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 4,
                column: "DivisionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 5,
                column: "DivisionId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Equipe",
                keyColumn: "Id",
                keyValue: 6,
                column: "DivisionId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Division",
                columns: new[] { "Id", "AnneeDebut", "AnneeFin", "ConferenceId", "NomDivision" },
                values: new object[,]
                {
                    { 1, 1994, null, 1, "Atlantique" },
                    { 2, 1994, null, 1, "Métropolitaine" },
                    { 3, 1994, null, 2, "Centrale" },
                    { 4, 1994, null, 2, "Pacifique" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_DivisionId",
                table: "Equipe",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Conference_NomConference_AnneeDebut",
                table: "Conference",
                columns: new[] { "NomConference", "AnneeDebut" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Division_ConferenceId",
                table: "Division",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_NomDivision_AnneeDebut",
                table: "Division",
                columns: new[] { "NomDivision", "AnneeDebut" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Division_DivisionId",
                table: "Equipe",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Division_DivisionId",
                table: "Equipe");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Conference");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_DivisionId",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Equipe");
        }
    }
}
