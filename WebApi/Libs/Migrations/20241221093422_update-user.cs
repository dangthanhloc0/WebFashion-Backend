using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class updateuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b911ddf-db49-495a-9ffd-29efd60e3f7b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef29ee16-2665-4574-a40d-35ddcf78fdf4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51dd8703-8336-4826-91fe-6aa83fc71f1b", null, "Admin", "ADMIN" },
                    { "a21796c5-a0e2-41fa-92cf-98a6e10b3829", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51dd8703-8336-4826-91fe-6aa83fc71f1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21796c5-a0e2-41fa-92cf-98a6e10b3829");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b911ddf-db49-495a-9ffd-29efd60e3f7b", null, "Admin", "ADMIN" },
                    { "ef29ee16-2665-4574-a40d-35ddcf78fdf4", null, "User", "USER" }
                });
        }
    }
}
