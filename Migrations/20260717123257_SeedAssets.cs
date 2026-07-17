using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asset_Tracking_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetType", "AssignedEmployee", "Brand", "Currency", "Model", "Office", "PriceUSD", "PurchaseDate", "SerialNumber", "Type", "WarrantyExpirationDate" },
                values: new object[,]
                {
                    { 1001, "Computer", "Anna", "Dell", "SEK", "Latitude 5440", "Sweden", 1200.0, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "DELL001", "", new DateTime(2027, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "Computer", "John", "Apple", "USD", "MacBook Pro M3", "USA", 2500.0, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "APPLE001", "", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1003, "MobilePhone", "Maria", "Samsung", "EUR", "Galaxy S24", "Germany", 900.0, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SAM001", "", new DateTime(2027, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1003);
        }
    }
}
