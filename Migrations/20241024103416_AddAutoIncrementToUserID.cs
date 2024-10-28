using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karverket.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoIncrementToUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoChanges",
                table: "GeoChanges");

            migrationBuilder.RenameTable(
                name: "GeoChanges",
                newName: "GeoChanges2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoChanges2",
                table: "GeoChanges2",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GeoChanges2",
                table: "GeoChanges2");

            migrationBuilder.RenameTable(
                name: "GeoChanges2",
                newName: "GeoChanges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeoChanges",
                table: "GeoChanges",
                column: "Id");
        }
    }
}
