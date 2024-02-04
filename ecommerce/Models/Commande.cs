namespace ecommerce.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public List<ligne_Commande> LignesCommande { get; set; }


    }
}
