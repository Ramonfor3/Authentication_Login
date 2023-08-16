using Authentication_Login.Repository.Abstract;
using Authentication_Login.Repository.Concret;
using Authentication_Login.Service.Abstract;
using Authentication_Login.Service.Concret;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Login
{
    public static class ConfigurationContext
    {
        public static void AddConfigurationContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserApplicationDbContext>(c =>
            {
                c.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
