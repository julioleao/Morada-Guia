using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoradaGuia.API.Models;

namespace MoradaGuia.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
        Task<string> GetCurrentSessionUserId(IdentityDbContext dbContext);

    }
}