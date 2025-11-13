using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTransAPISQL.Migrations
{
    /// <inheritdoc />
    public partial class OneVehicleManyPackages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageVehicles");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_VehicleId",
                table: "Packages",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_VehicleId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Packages");

            migrationBuilder.CreateTable(
                name: "PackageVehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageVehicles", x => new { x.VehicleId, x.PackageId });
                    table.ForeignKey(
                        name: "FK_PackageVehicles_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageVehicles_PackageId",
                table: "PackageVehicles",
                column: "PackageId");
        }
    }
}
