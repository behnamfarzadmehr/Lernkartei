using Lernkartei.Domain.User;
using Lernkartei.InfraStructure.Concrete.Repository;
using Microsoft.AspNetCore.Identity;
using Swish.InfraStructure.context;

namespace Swish.InfraStructure.Concrete.User
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        public UserRepository(LernkarteiContext context) :base(context)
        {

        }
    }
}
