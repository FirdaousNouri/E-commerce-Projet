using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Data.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categorieId",
                table: "Produit",
                type: "int",
                nullable: true);

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
                name: "Panier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.Id);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produit_Categorie_categorieId",
                table: "Produit");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "PanierProduit");

            migrationBuilder.DropTable(
                name: "Panier");

            migrationBuilder.DropIndex(
                name: "IX_Produit_categorieId",
                table: "Produit");

            migrationBuilder.DropColumn(
                name: "categorieId",
                table: "Produit");
        }
    }
}
