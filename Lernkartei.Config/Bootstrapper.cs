using Lernkartei.Domain.Abstraction;
using Lernkartei.Domain.User;
using Lernkartei.Infrastructure.Concrete;
using Lernkartei.InfraStructure.Concrete.Repository;
using Lernkartei.Service.Abstract.Card;
using Lernkartei.Service.Concrete.Card;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swish.InfraStructure.Concrete.User;
using Swish.InfraStructure.context;

namespace Swish.Config
{
    public static class Bootstrapper
    {
        public static void AddLernkartei(this IServiceCollection collection, IConfiguration options)
        {
            //TODO: use batch registration here O_o
            collection.AddScoped<IUserRepository, UserRepository>();

            collection.AddIdentity<IdentityUser, IdentityRole>()

                      .AddEntityFrameworkStores<LernkarteiContext>()
                      .AddDefaultTokenProviders();
            collection.AddDbContext<LernkarteiContext>(builder =>
                                        builder.UseSqlServer(options["ConnectionString"]));

            //services
            collection.AddScoped<ICardService, CardService>();
            collection.AddScoped<ICardHouseService, CardHouseService>();
            //Repositories
            collection.AddScoped<ICardRepository, CardRepository>();
            collection.AddScoped<ICardHouseRepository, CardHouseRepository>();



            collection.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
