using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class migrate9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "rate",
                table: "Produit");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Produit",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Produit");

            migrationBuilder.AddColumn<int>(
                name: "rate",
                table: "Produit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
