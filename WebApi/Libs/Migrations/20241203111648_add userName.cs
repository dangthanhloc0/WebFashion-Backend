using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class adduserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2780ed5-942a-4d79-a96a-4565e3143281");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdb944d3-2f7e-4fc9-bb28-995f1468551a");

            migrationBuilder.AddColumn<string>(
                name: "NameOfUser",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10922972-e102-4ac8-b0b9-aeb907427f54", null, "Admin", "ADMIN" },
                    { "ffce35fb-96c2-4a9a-a56d-0a1444f4302a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10922972-e102-4ac8-b0b9-aeb907427f54");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffce35fb-96c2-4a9a-a56d-0a1444f4302a");

            migrationBuilder.DropColumn(
                name: "NameOfUser",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2780ed5-942a-4d79-a96a-4565e3143281", null, "Admin", "ADMIN" },
                    { "bdb944d3-2f7e-4fc9-bb28-995f1468551a", null, "User", "USER" }
                });
        }
    }
}
