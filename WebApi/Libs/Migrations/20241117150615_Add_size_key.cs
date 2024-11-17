using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Libs.Migrations
{
    /// <inheritdoc />
    public partial class Add_size_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4317035c-3503-4bda-8c06-cf9dc6453269");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77bececc-db06-4879-8aff-3e9bb6b9287b");

            migrationBuilder.AddColumn<int>(
                name: "sizeId",
                table: "orderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00a1f99a-5c29-41c0-8120-cfdea1634260", null, "User", "USER" },
                    { "1c118efb-bd7c-458e-952f-4c426cdacf38", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_sizeId",
                table: "orderDetails",
                column: "sizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_Size_sizeId",
                table: "orderDetails",
                column: "sizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_Size_sizeId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_sizeId",
                table: "orderDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00a1f99a-5c29-41c0-8120-cfdea1634260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c118efb-bd7c-458e-952f-4c426cdacf38");

            migrationBuilder.DropColumn(
                name: "sizeId",
                table: "orderDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4317035c-3503-4bda-8c06-cf9dc6453269", null, "Admin", "ADMIN" },
                    { "77bececc-db06-4879-8aff-3e9bb6b9287b", null, "User", "USER" }
                });
        }
    }
}
