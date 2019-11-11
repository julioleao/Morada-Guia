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
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.ImovelLikeId});
            builder.Entity<Like>()
                .HasOne(u => u.ImovelLike)
                .WithMany(i => i.Liker)
                .HasForeignKey(u => u.ImovelLikeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Like>()
                .HasOne(i => i.Liker)
                .WithMany(u => u.ImovelLike)
                .HasForeignKey(i => i.LikerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}