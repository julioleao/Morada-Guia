using Microsoft.EntityFrameworkCore;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<User> Users { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.ImovelLikeId});
            modelBuilder.Entity<Like>()
                .HasOne(u => u.ImovelLike)
                .WithMany(i => i.Liker)
                .HasForeignKey(u => u.ImovelLikeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Like>()
                .HasOne(i => i.Liker)
                .WithMany(u => u.ImovelLike)
                .HasForeignKey(i => i.LikerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Messages>()
                .HasOne(u => u.Sender)
                .WithMany(m => m.MessagesSent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Messages>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}