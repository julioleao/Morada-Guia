using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoradaGuia.API.Data
{
    public class UserResolveService : IUserResolveService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public UserResolveService(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<string> GetCurrentSessionUserId(IdentityDbContext dbContext)
    {
        var currentSessionUserId = httpContextAccessor.HttpContext.User.Identity.Name;

        var user = await dbContext.Users                
            .SingleAsync(u => u.Id.Equals(currentSessionUserId));
        return user.Id;
    }
}
}