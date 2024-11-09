using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karverket.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fylke",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Innmelding",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CaseManagerId",
                table: "Innmelding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Innmelding_CaseManagerId",
                table: "Innmelding",
                column: "CaseManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Innmelding_Users_CaseManagerId",
                table: "Innmelding",
                column: "CaseManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Innmelding_Users_CaseManagerId",
                table: "Innmelding");

            migrationBuilder.DropIndex(
                name: "IX_Innmelding_CaseManagerId",
                table: "Innmelding");

            migrationBuilder.DropColumn(
                name: "Fylke",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Innmelding");

            migrationBuilder.DropColumn(
                name: "CaseManagerId",
                table: "Innmelding");
        }
    }
}
