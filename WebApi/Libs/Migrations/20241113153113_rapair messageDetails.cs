using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class rapairmessageDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cb9eb01-e72e-43c7-a39c-c1d4b8aeaf21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91cf7211-0cc3-4943-9fe0-9c7d9eed35c6");

            migrationBuilder.DropColumn(
                name: "MessageOfCustomerId",
                table: "messageOfCustomers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "messageOfCustomers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44b5f26e-bd82-444f-9cb5-11c9006bdfc3", null, "User", "USER" },
                    { "74a3ba9b-f994-4db4-b3ad-865e0914c7dc", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b5f26e-bd82-444f-9cb5-11c9006bdfc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a3ba9b-f994-4db4-b3ad-865e0914c7dc");

            migrationBuilder.AddColumn<Guid>(
                name: "MessageOfCustomerId",
                table: "messageOfCustomers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "messageOfCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cb9eb01-e72e-43c7-a39c-c1d4b8aeaf21", null, "User", "USER" },
                    { "91cf7211-0cc3-4943-9fe0-9c7d9eed35c6", null, "Admin", "ADMIN" }
                });
        }
    }
}
