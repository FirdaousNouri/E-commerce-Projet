namespace ecommerce.Models
{
    public class ligne_Commande
    {
        public int ID { get; set; }
        public int ProduitId { get; set; }
        public int CommandeId { get; set; }
        public int Quantite { get; set; }
        public Produit? Produit{ get; set; }
        public Commande ?Commande { get; set; }



    }
}
