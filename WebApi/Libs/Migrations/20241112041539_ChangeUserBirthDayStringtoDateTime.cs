using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserBirthDayStringtoDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224c9da3-ddaf-4760-a638-cf4ba6324d2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "732ab23e-5545-4021-9a35-975d2f80814b");

            migrationBuilder.AlterColumn<DateTime>(
                name: "birthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cb9eb01-e72e-43c7-a39c-c1d4b8aeaf21", null, "User", "USER" },
                    { "91cf7211-0cc3-4943-9fe0-9c7d9eed35c6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cb9eb01-e72e-43c7-a39c-c1d4b8aeaf21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91cf7211-0cc3-4943-9fe0-9c7d9eed35c6");

            migrationBuilder.AlterColumn<string>(
                name: "birthDay",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "224c9da3-ddaf-4760-a638-cf4ba6324d2b", null, "User", "USER" },
                    { "732ab23e-5545-4021-9a35-975d2f80814b", null, "Admin", "ADMIN" }
                });
        }
    }
}
