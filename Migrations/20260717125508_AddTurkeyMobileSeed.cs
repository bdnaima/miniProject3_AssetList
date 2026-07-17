using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asset_Tracking_System.Migrations
{
    /// <inheritdoc />
    public partial class AddTurkeyMobileSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1001,
                column: "Type",
                value: "Computer");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1002,
                column: "Type",
                value: "Computer");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1003,
                column: "Type",
                value: "Mobile");

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetType", "AssignedEmployee", "Brand", "Currency", "Model", "Office", "PriceUSD", "PurchaseDate", "SerialNumber", "Type", "WarrantyExpirationDate" },
                values: new object[] { 1004, "MobilePhone", "Ahmet", "Apple", "TRY", "iPhone 15", "Turkey", 1200.0, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "APPLE002", "Mobile", new DateTime(2028, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1004);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1001,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1002,
                column: "Type",
                value: "");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "AssetId",
                keyValue: 1003,
                column: "Type",
                value: "");
        }
    }
}
