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

        // public async Task<IEnumerable<Imovel>> GetImoveis()
        // {
        //     var imoveis = await _context.Imovel.Include(p => p.Fotos).ToListAsync();

        //     return imoveis;
        // }
        public async Task<PagedList<Imovel>> GetImoveis(ImovelParams imovelParams)
        {
            var imoveis = _context.Imovel.Include(p => p.Fotos).AsQueryable();

            if(imovelParams.Tipo != null && imovelParams.Tipo != "undefined") {
                imoveis = imoveis.Where(i => i.Tipo == imovelParams.Tipo);
            }

            imoveis = imoveis.Where(i => i.Valor >= imovelParams.ValorMin && i.Valor <= imovelParams.ValorMax);

            return await PagedList<Imovel>.CreateAsync(imoveis, imovelParams.PageNumber, imovelParams.PageSize);        
        }


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
        
        // public async Task<IEnumerable<Imovel>> GetLikesFromUser(int userId, Like like)
        // {
        //     //await _context.Likes.Where(i => i.LikerId == userId).Include(i => i.ImovelLikeId).ToListAsync();
        //     return await _context.Imovel.Where(i => i.Id == _context.Like && userId == _context.Like.Where).Include(i => i.Fotos).ToListAsync();
        // }

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

        public async Task<Like> GetLike(int userId, int imovelId)
        {
            return await _context.Likes.FirstOrDefaultAsync(i => i.LikerId == userId && i.ImovelLikeId == imovelId);
        }

        public async Task<Messages> GetMessage(int id)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<PagedList<Messages>> GetMessagesForUser(MessageParams messageParams) 
         {
             var messages = _context.Messages.Include(u => u.Sender)
             .Include(u => u.Recipient)
             .AsQueryable();

             switch (messageParams.MessageContainer)
             {
                case "Inbox":
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId);
                    break;
                    case "Outbox":
                    messages = messages.Where(u => u.SenderId == messageParams.UserId);
                    break;
                    default:
                    messages = messages.Where(u => u.RecipientId == messageParams.UserId && u.IsRead == false);
                    break;
             }

             messages = messages.OrderByDescending(d => d.MessageSent);
             return await PagedList<Messages>.CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
         }

        public async Task<IEnumerable<Messages>> GetMessageThread(int userId, int recipientId)
         {
             var messages = await _context.Messages
                .Include(u => u.Sender)
                .Include(u => u.Recipient)
                .Where(m => m.RecipientId == userId && m.SenderId == recipientId
                    || m.RecipientId == recipientId && m.SenderId == userId)
                .OrderByDescending(m => m.MessageSent)
                .ToListAsync();

                return messages;
         }
    }
}