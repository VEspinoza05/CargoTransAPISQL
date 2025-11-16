using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTransAPISQL.Migrations
{
    /// <inheritdoc />
    public partial class DriverRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Conductor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
