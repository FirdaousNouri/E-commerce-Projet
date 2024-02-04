using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class p : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "Produit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produit_PanierId",
                table: "Produit",
                column: "PanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Panier_PanierId",
                table: "Produit",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Panier_PanierId",
                table: "Produit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_PanierId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "Produit");
        }
    }
}
