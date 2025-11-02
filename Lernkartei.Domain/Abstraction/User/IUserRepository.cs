using Lernkartei.Domain.Abstraction;
using Microsoft.AspNetCore.Identity;

namespace Lernkartei.Domain.User
{
    public interface IUserRepository : IRepository<IdentityUser>
    {

    }
}
