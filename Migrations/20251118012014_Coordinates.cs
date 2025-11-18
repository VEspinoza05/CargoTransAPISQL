using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTransAPISQL.Migrations
{
    /// <inheritdoc />
    public partial class Coordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Vehicles",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Vehicles",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Packages",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Packages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Packages",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<double>(
                name: "LatitudeDestination",
                table: "Packages",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LongitudeDestination",
                table: "Packages",
                type: "float",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "LatitudeDestination",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "LongitudeDestination",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "Weight",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "Packages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Vehicles_VehicleId",
                table: "Packages",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
