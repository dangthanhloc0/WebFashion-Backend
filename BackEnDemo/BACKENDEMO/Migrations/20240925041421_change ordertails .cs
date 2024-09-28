using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKENDEMO.Migrations
{
    /// <inheritdoc />
    public partial class changeordertails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e14da5f-c25c-4071-acfd-c902b6222aca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "913bcbbc-c19d-40df-844a-ab7922450da0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2869d3a2-dc54-4972-a1ac-0d986aedff09", null, "User", "USER" },
                    { "5b8306c8-d3d0-4bef-8e61-aa62cdc82c51", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2869d3a2-dc54-4972-a1ac-0d986aedff09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b8306c8-d3d0-4bef-8e61-aa62cdc82c51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e14da5f-c25c-4071-acfd-c902b6222aca", null, "User", "USER" },
                    { "913bcbbc-c19d-40df-844a-ab7922450da0", null, "Admin", "ADMIN" }
                });
        }
    }
}
