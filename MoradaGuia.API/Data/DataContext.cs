using Microsoft.EntityFrameworkCore;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}