using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class prdt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Produit");

            migrationBuilder.AddColumn<string>(
                name: "Quantite",
                table: "ligne_Commande",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "ligne_Commande");

            migrationBuilder.AddColumn<string>(
                name: "Quantite",
                table: "Produit",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
