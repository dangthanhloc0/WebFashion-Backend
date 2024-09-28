using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKENDEMO.Migrations
{
    /// <inheritdoc />
    public partial class updateordertails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1dade5-63a2-4eaa-9094-7a29b6692cc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c33ad6f-11e4-489f-b3a3-0090447113ba");

            migrationBuilder.AlterColumn<long>(
                name: "price",
                table: "orderDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e14da5f-c25c-4071-acfd-c902b6222aca", null, "User", "USER" },
                    { "913bcbbc-c19d-40df-844a-ab7922450da0", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e14da5f-c25c-4071-acfd-c902b6222aca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "913bcbbc-c19d-40df-844a-ab7922450da0");

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "orderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d1dade5-63a2-4eaa-9094-7a29b6692cc0", null, "Admin", "ADMIN" },
                    { "8c33ad6f-11e4-489f-b3a3-0090447113ba", null, "User", "USER" }
                });
        }
    }
}
