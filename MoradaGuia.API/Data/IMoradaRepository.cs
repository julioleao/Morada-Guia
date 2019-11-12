using System.Collections.Generic;
using System.Threading.Tasks;
using MoradaGuia.API.Helpers;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public interface IMoradaRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
         Task<PagedList<Imovel>> GetImoveis(ImovelParams imovelParams);
         Task<Imovel> GetImovel(int id);
         Task<Photo> GetPhoto(int id);
         Task<Photo> GetMainPhotoForImovel(int imovelId);
         Task<IEnumerable<Imovel>> GetImovelFromUser(int userId);
         //Task<IEnumerable<Imovel>> GetLikesFromUser(int userId, Like like);
         Task<Like> GetLike(int userId, int imovelId);
         Task<Messages> GetMessage(int id);
         Task<PagedList<Messages>> GetMessagesForUser(MessageParams messageParams);
         Task<IEnumerable<Messages>> GetMessageThread(int userId, int recipientId);
    }
}