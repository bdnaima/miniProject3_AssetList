using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asset_Tracking_System.Migrations
{
    /// <inheritdoc />
    public partial class AddAssetProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedEmployee",
                table: "Assets",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Assets",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyExpirationDate",
                table: "Assets",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedEmployee",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "WarrantyExpirationDate",
                table: "Assets");
        }
    }
}
