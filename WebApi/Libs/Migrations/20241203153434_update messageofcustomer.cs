using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class updatemessageofcustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserId",
                table: "messageOfCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "messageOfCustomers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b140ec3-89ce-4407-a53b-1829fe94f949", null, "Admin", "ADMIN" },
                    { "d64b0308-fce1-437b-877f-8754d283a8b9", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b140ec3-89ce-4407-a53b-1829fe94f949");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64b0308-fce1-437b-877f-8754d283a8b9");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "messageOfCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
                    { "10922972-e102-4ac8-b0b9-aeb907427f54", null, "Admin", "ADMIN" },
                    { "ffce35fb-96c2-4a9a-a56d-0a1444f4302a", null, "User", "USER" }
                });
        }
    }
}
