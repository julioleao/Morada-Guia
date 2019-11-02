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
    }
}