using Cvjecarnica.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cvjecarnica.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        public DbSet<Cvijet> Cvijece { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cvijet>().Property(f => f.Cijena).HasPrecision(10, 2);

            modelBuilder.Entity<Kategorija>().HasData(
                new Kategorija() { Id = 1, Naziv = "Ruze" },
                new Kategorija() { Id = 2, Naziv = "Karanfili" },
                new Kategorija() { Id = 3, Naziv = "Orhideje" },
                new Kategorija() { Id = 4, Naziv = "Tulipani" },
                new Kategorija() { Id = 5, Naziv = "Ljiljani" });

            modelBuilder.Entity<Cvijet>().HasData(
                 new Cvijet() { Id = 1, Naziv = "Ruze", Boja = "Crvena", Cijena = 3.50m, SlikaUrl = "https://i.pinimg.com/originals/36/d7/90/36d7908b0f6b3485663605048784c2d5.jpg", KategorijaId = 1 },
                 new Cvijet() { Id = 2, Naziv = "Lavanda", Boja = "Ljubicasta", Cijena = 3.00m, SlikaUrl = "https://images.unsplash.com/photo-1629730030412-6d3bb01336f9?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1yZWxhdGVkfDE1fHx8ZW58MHx8fHx8&w=1000&q=80", KategorijaId = 2 },
                 new Cvijet() { Id = 3, Naziv = "Orhideje", Boja = "Zuta", Cijena = 5.00m, SlikaUrl = "https://www.crushpixel.com/big-static18/preview4/yellow-orchid-2820641.jpg", KategorijaId = 3 },
                 new Cvijet() { Id = 4, Naziv = "Tulipani", Boja = "Bijela", Cijena = 3.00m, SlikaUrl = "https://lucysflowersnyc.com/wp-content/uploads/bfi_thumb/6767-q1rt7c6fwmm8q8j0ovlu9qj929ch5gey2al1qer15k.jpeg", KategorijaId = 4 },
                 new Cvijet() { Id = 5, Naziv = "Ljiljani", Boja = "Plavi", Cijena = 5.00m, SlikaUrl = "https://www.crushpixel.com/big-static18/preview4/blue-lilies-flower-background-with-2934003.jpg", KategorijaId = 5 }
                 );
        }
    }
}