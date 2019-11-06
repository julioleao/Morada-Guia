using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MoradaGuia.API.Data
{
    public interface IUserResolveService
    {
        Task<string> GetCurrentSessionUserId(IdentityDbContext dbContext);
    }
}