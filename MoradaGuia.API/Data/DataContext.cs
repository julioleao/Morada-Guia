using Microsoft.EntityFrameworkCore;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Imovel> Imovel { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
    }
}