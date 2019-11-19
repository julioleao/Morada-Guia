using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MoradaGuia.API.Helpers;
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
            return imoveis;
        }
        /* public async Task<PagedList<Imovel>> GetImoveis(ImovelParams imovelParams)
        {
            var imoveis = _context.Imovel.Include(p => p.Fotos).AsQueryable();

            //imoveis = imoveis.Where(i => i.Id != imovelParams.ImovelId);
            imoveis = imoveis.Where(i => i.Tipo == imovelParams.Tipo);
            imoveis = imoveis.Where(i => i.Valor >= imovelParams.ValorMin && i.Valor <= imovelParams.ValorMax);

            return await PagedList<Imovel>.CreateAsync(imoveis, imovelParams.PageNumber, imovelParams.PageSize);        
        } */


        public async Task<Imovel> GetImovel(int id)
        {
            var imovel = await _context.Imovel.Include(p => p.Fotos).FirstOrDefaultAsync(u => u.Id == id);
            return imovel;
        }
        // Mostar imoveis do usuário logado
        public async Task<IEnumerable<Imovel>> GetImovelFromUser(int userId)
        {
            return await _context.Imovel.Where(i => i.UserId == userId).Include(i => i.Fotos).ToListAsync();
        }
        

        // Função Where sendo utilizada
        public async Task<Photo> GetMainPhotoForImovel(int imovelId)
        {
            return await _context.Photos.Where(i => i.ImovelId == imovelId).FirstOrDefaultAsync(p => p.Principal);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

            return photo;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
               
            var users = await _context.Users.Include(p => p.Imovels).ToListAsync();;

            
            return users;
        }

        
        


        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}