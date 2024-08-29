using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKENDEMO.Migrations
{
    /// <inheritdoc />
    public partial class newdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ff0c45-98ff-47e5-8bef-d8344d0ea0ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f55889ed-52fe-40ac-8a09-dd835963153f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f2acc5fe-9aa8-49d8-b1a5-2dcb2373104b", null, "User", "USER" },
                    { "f7dd3913-9454-4260-a62f-d0eb5c51cb29", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2acc5fe-9aa8-49d8-b1a5-2dcb2373104b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7dd3913-9454-4260-a62f-d0eb5c51cb29");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87ff0c45-98ff-47e5-8bef-d8344d0ea0ca", null, "User", "USER" },
                    { "f55889ed-52fe-40ac-8a09-dd835963153f", null, "Admin", "ADMIN" }
                });
        }
    }
}
