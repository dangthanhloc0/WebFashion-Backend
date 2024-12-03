using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class fixbugError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_appUserId",
                table: "messageOfCustomers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b140ec3-89ce-4407-a53b-1829fe94f949");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d64b0308-fce1-437b-877f-8754d283a8b9");

            migrationBuilder.RenameColumn(
                name: "appUserId",
                table: "messageOfCustomers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_messageOfCustomers_appUserId",
                table: "messageOfCustomers",
                newName: "IX_messageOfCustomers_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "messageOfCustomers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c55a4fc-aafd-48f2-8b3f-def6f2cec665", null, "Admin", "ADMIN" },
                    { "a4384874-8bdd-493f-8632-68a4d246bee1", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_AppUserId",
                table: "messageOfCustomers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_AppUserId",
                table: "messageOfCustomers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c55a4fc-aafd-48f2-8b3f-def6f2cec665");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4384874-8bdd-493f-8632-68a4d246bee1");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "messageOfCustomers",
                newName: "appUserId");

            migrationBuilder.RenameIndex(
                name: "IX_messageOfCustomers_AppUserId",
                table: "messageOfCustomers",
                newName: "IX_messageOfCustomers_appUserId");

            migrationBuilder.AlterColumn<string>(
                name: "appUserId",
                table: "messageOfCustomers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9b140ec3-89ce-4407-a53b-1829fe94f949", null, "Admin", "ADMIN" },
                    { "d64b0308-fce1-437b-877f-8754d283a8b9", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_appUserId",
                table: "messageOfCustomers",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
