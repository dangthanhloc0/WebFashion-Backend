using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class dberrorfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discountDetails_AppUser_AppUserId",
                table: "discountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_AppUser_appUserId",
                table: "messageOfCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUser_appUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb34f8d-e5f8-4c72-9de3-ca125996379f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61426120-4184-4d16-96d8-a529cfe187e5");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDay",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b2780ed5-942a-4d79-a96a-4565e3143281", null, "Admin", "ADMIN" },
                    { "bdb944d3-2f7e-4fc9-bb28-995f1468551a", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_discountDetails_AspNetUsers_AppUserId",
                table: "discountDetails",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_appUserId",
                table: "messageOfCustomers",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_appUserId",
                table: "Orders",
                column: "appUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discountDetails_AspNetUsers_AppUserId",
                table: "discountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_AspNetUsers_appUserId",
                table: "messageOfCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_appUserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2780ed5-942a-4d79-a96a-4565e3143281");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdb944d3-2f7e-4fc9-bb28-995f1468551a");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthDay",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDay = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3eb34f8d-e5f8-4c72-9de3-ca125996379f", null, "Admin", "ADMIN" },
                    { "61426120-4184-4d16-96d8-a529cfe187e5", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_discountDetails_AppUser_AppUserId",
                table: "discountDetails",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_messageOfCustomers_AppUser_appUserId",
                table: "messageOfCustomers",
                column: "appUserId",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUser_appUserId",
                table: "Orders",
                column: "appUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }
    }
}
