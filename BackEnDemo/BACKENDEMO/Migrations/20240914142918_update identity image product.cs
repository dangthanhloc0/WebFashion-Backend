using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKENDEMO.Migrations
{
    /// <inheritdoc />
    public partial class updateidentityimageproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3097ac07-2646-435e-821a-4679f9a9123c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "412f27e1-18f5-4c01-a980-809eb8192a90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d1dade5-63a2-4eaa-9094-7a29b6692cc0", null, "Admin", "ADMIN" },
                    { "8c33ad6f-11e4-489f-b3a3-0090447113ba", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1dade5-63a2-4eaa-9094-7a29b6692cc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c33ad6f-11e4-489f-b3a3-0090447113ba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3097ac07-2646-435e-821a-4679f9a9123c", null, "User", "USER" },
                    { "412f27e1-18f5-4c01-a980-809eb8192a90", null, "Admin", "ADMIN" }
                });
        }
    }
}
