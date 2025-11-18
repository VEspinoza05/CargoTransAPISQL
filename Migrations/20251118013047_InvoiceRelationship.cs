using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoTransAPISQL.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PricePerPound = table.Column<double>(type: "float", nullable: false),
                    Pounds = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    BillingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_InvoiceId",
                table: "Packages",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Invoices_InvoiceId",
                table: "Packages",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Invoices_InvoiceId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Packages_InvoiceId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Packages");
        }
    }
}
