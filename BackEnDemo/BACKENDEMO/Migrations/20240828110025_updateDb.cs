using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BACKENDEMO.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e39a90-45a7-4e83-9b5b-6c0edb950000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b8a503-dc1a-40c8-bbe1-fe73f7bb645d");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87ff0c45-98ff-47e5-8bef-d8344d0ea0ca", null, "User", "USER" },
                    { "f55889ed-52fe-40ac-8a09-dd835963153f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_CategoryId",
                table: "products");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryId",
                table: "products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ff0c45-98ff-47e5-8bef-d8344d0ea0ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f55889ed-52fe-40ac-8a09-dd835963153f");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64e39a90-45a7-4e83-9b5b-6c0edb950000", null, "Admin", "ADMIN" },
                    { "c7b8a503-dc1a-40c8-bbe1-fe73f7bb645d", null, "User", "USER" }
                });
        }
    }
}
