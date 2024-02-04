using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;

namespace ecommerce.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ecommerce.Models.Produit>? Produit { get; set; }
        public DbSet<ecommerce.Models.ligne_Commande>? ligne_Commande { get; set; }
        public DbSet<ecommerce.Models.Commande>? Commande { get; set; }
        public DbSet<ecommerce.Models.Panier>? Panier { get; set; }
    }
}