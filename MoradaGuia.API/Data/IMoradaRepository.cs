using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}