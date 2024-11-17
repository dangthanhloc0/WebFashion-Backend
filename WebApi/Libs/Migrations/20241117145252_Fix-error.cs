using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class Fixerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44b5f26e-bd82-444f-9cb5-11c9006bdfc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74a3ba9b-f994-4db4-b3ad-865e0914c7dc");

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
                    { "4317035c-3503-4bda-8c06-cf9dc6453269", null, "Admin", "ADMIN" },
                    { "77bececc-db06-4879-8aff-3e9bb6b9287b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4317035c-3503-4bda-8c06-cf9dc6453269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77bececc-db06-4879-8aff-3e9bb6b9287b");

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
    }
}
