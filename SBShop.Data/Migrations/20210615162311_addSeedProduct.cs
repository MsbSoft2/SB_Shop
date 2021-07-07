using Microsoft.EntityFrameworkCore.Migrations;

namespace SBShop.Data.Migrations
{
    public partial class addSeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "Name", "Price" },
                values: new object[] { 1, 2, "اولین محصول ایجاد شده از طریق پیشفرص برنامه می باشد", "Default.png", "محصول اول", 100000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);
        }
    }
}
