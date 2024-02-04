using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Categorie_categorieId",
                table: "Produit");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "PanierProduit");

            migrationBuilder.DropIndex(
                name: "IX_Produit_categorieId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "categorieId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Panier");

            migrationBuilder.AddColumn<int>(
                name: "Produitid",
                table: "Panier",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantite",
                table: "ligne_Commande",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PanierId",
                table: "ligne_Commande",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Panier_Produitid",
                table: "Panier",
                column: "Produitid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ligne_Commande_Panier_PanierId",
                table: "ligne_Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Produit_Produitid",
                table: "Panier");

            migrationBuilder.DropIndex(
                name: "IX_Panier_Produitid",
                table: "Panier");

            migrationBuilder.DropIndex(
                name: "IX_ligne_Commande_PanierId",
                table: "ligne_Commande");

            migrationBuilder.DropColumn(
                name: "Produitid",
                table: "Panier");

            migrationBuilder.DropColumn(
                name: "PanierId",
                table: "ligne_Commande");

            migrationBuilder.AddColumn<int>(
                name: "categorieId",
                table: "Produit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Panier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Quantite",
                table: "ligne_Commande",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PanierProduit",
                columns: table => new
                {
                    PaniersId = table.Column<int>(type: "int", nullable: false),
                    Produitsid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanierProduit", x => new { x.PaniersId, x.Produitsid });
                    table.ForeignKey(
                        name: "FK_PanierProduit_Panier_PaniersId",
                        column: x => x.PaniersId,
                        principalTable: "Panier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PanierProduit_Produit_Produitsid",
                        column: x => x.Produitsid,
                        principalTable: "Produit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_categorieId",
                table: "Produit",
                column: "categorieId");

            migrationBuilder.CreateIndex(
                name: "IX_PanierProduit_Produitsid",
                table: "PanierProduit",
                column: "Produitsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Produit_Categorie_categorieId",
                table: "Produit",
                column: "categorieId",
                principalTable: "Categorie",
                principalColumn: "Id");
        }
    }
}
