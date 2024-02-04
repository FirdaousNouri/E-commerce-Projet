using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class migrate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ligne_Commande_Panier_PanierId",
                table: "ligne_Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Produit_Produitid",
                table: "Panier");

            migrationBuilder.DropIndex(
                name: "IX_ligne_Commande_PanierId",
                table: "ligne_Commande");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "ligne_Commande");

            migrationBuilder.RenameColumn(
                name: "Produitid",
                table: "Panier",
                newName: "ProduitId");

            migrationBuilder.RenameIndex(
                name: "IX_Panier_Produitid",
                table: "Panier",
                newName: "IX_Panier_ProduitId");

            migrationBuilder.AlterColumn<int>(
                name: "ProduitId",
                table: "Panier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantite",
                table: "Panier",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_Produit_ProduitId",
                table: "Panier",
                column: "ProduitId",
                principalTable: "Produit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Produit_ProduitId",
                table: "Panier");

            migrationBuilder.DropColumn(
                name: "Quantite",
                table: "Panier");

            migrationBuilder.RenameColumn(
                name: "ProduitId",
                table: "Panier",
                newName: "Produitid");

            migrationBuilder.RenameIndex(
                name: "IX_Panier_ProduitId",
                table: "Panier",
                newName: "IX_Panier_Produitid");

            migrationBuilder.AlterColumn<int>(
                name: "Produitid",
                table: "Panier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "ligne_Commande",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ligne_Commande_PanierId",
                table: "ligne_Commande",
                column: "PanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ligne_Commande_Panier_PanierId",
                table: "ligne_Commande",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Panier_Produit_Produitid",
                table: "Panier",
                column: "Produitid",
                principalTable: "Produit",
                principalColumn: "id");
        }
    }
}
