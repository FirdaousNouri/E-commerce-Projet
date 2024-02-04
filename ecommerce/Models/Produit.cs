namespace ecommerce.Models
{
    public class Produit
    {
       public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string PhotoUrl { get; set;}
        
        public float Price { get; set; }

        public int Quantite { get; set; }

        public String ? Categorie { get; set; }
        
        public List<ligne_Commande> LignesCommande { get; set; }
     


    }
}
