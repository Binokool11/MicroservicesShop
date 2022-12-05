using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Binokool.Services.ProductAPI.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImgUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Acoustic guitar", "Идеальный вариант для домашних посиделок и самообучения", "https://musicmarket.by/images/thumbnails/240/240/detailed/1045/gibson-les-paul-tribute-sh-1.jpg", "Gibson-SG", 1000.0 },
                    { 2, "Acoustic guitar", "Выбор профессионального музыканта", "https://musicmarket.by/images/thumbnails/240/240/detailed/1045/gibson-les-paul-custom-w-ebony-fingerboard-gloss-2019-e-1.jpg", "Crafter-SF", 3000.0 },
                    { 3, "Electric guitar", "Гитара для продолжающих гитаристов", "https://musicmarket.by/images/thumbnails/240/240/detailed/1024/AD810_SSB_-main-cort.jpg", "Cort-BF", 1500.0 },
                    { 4, "Electric guitar", "Прекрасная гитара из красного дерева", "https://musicmarket.by/images/thumbnails/240/240/detailed/1066/crafter-d-7-n.jpg", "Sonata-TR", 1000.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "ProductId");
        }
    }
}
