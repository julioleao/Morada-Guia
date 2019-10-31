using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public class MoradaRepository : IMoradaRepository
    {
        private readonly DataContext _context;
        public MoradaRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Imovel>> GetImoveis()
        {
            var imoveis = await _context.Imovel.Include(p => p.Fotos).ToListAsync();

            return imoveis;        }

        public async Task<Imovel> GetImovel(int id)
        {
            var imovel = await _context.Imovel.Include(p => p.Fotos).FirstOrDefaultAsync(u => u.Id == id);
            return imovel;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Fotos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Fotos).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}