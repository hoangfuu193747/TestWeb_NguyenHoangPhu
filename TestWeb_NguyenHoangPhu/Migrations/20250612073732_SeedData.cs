using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWeb_NguyenHoangPhu.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Microsoft", 10.99m, 100, "ASP.NET Core" },
                    { 2, "EF Team", 12.99m, 50, "Entity Framework Core" },
                    { 3, "Mark J. Price", 15.49m, 80, "C# Fundamentals" },
                    { 4, "Sheep", 10.29m, 65, "Sleep" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
