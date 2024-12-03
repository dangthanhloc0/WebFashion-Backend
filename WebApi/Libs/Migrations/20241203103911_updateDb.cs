using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "messageDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00a1f99a-5c29-41c0-8120-cfdea1634260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c118efb-bd7c-458e-952f-4c426cdacf38");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthDay",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "messageOfCustomers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "productId",
                table: "messageOfCustomers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_messageOfCustomers_productId",
                table: "messageOfCustomers",
                column: "productId");

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
                name: "FK_messageOfCustomers_products_productId",
                table: "messageOfCustomers",
                column: "productId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AppUser_appUserId",
                table: "Orders",
                column: "appUserId",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_discountDetails_AppUser_AppUserId",
                table: "discountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_AppUser_appUserId",
                table: "messageOfCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_messageOfCustomers_products_productId",
                table: "messageOfCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AppUser_appUserId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_messageOfCustomers_productId",
                table: "messageOfCustomers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3eb34f8d-e5f8-4c72-9de3-ca125996379f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61426120-4184-4d16-96d8-a529cfe187e5");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "messageOfCustomers");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "messageOfCustomers");

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

            migrationBuilder.CreateTable(
                name: "messageDetails",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    messageOfCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageDetails", x => new { x.productId, x.messageOfCustomerId });
                    table.ForeignKey(
                        name: "FK_messageDetails_messageOfCustomers_messageOfCustomerId",
                        column: x => x.messageOfCustomerId,
                        principalTable: "messageOfCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messageDetails_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00a1f99a-5c29-41c0-8120-cfdea1634260", null, "User", "USER" },
                    { "1c118efb-bd7c-458e-952f-4c426cdacf38", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_messageDetails_messageOfCustomerId",
                table: "messageDetails",
                column: "messageOfCustomerId");

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
    }
}
