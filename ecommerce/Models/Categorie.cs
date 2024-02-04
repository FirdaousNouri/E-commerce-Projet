namespace ecommerce.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string? Name { get; set; }



        public ICollection<Produit>? produits { get; set; }
    }
}
