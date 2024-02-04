namespace ecommerce.Models
{
    public class Panier
    {
        public int Id { get; set; }
        public int Quantite { get; set; }
        public int ProduitId { get; set; }
        public Produit? Produit { get; set; }
        public List<Produit> produit{ get; set; }



    }
}
