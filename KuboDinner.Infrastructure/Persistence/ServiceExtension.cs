using KuboDinner.Infrastructure.Persistence.Context;
using KuboDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KuboDinner.Infrastructure.Persistence
{
    public static class ServiceExtension
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KuboDinnerDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlDbConnection"));
            });

            services.AddScoped<PublishDomainEventsInterceptor>();
        }
    }
}
