using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using bArtSolutionTest.Data.Entities;
using bArtSolutionTest.Data.Infrastructure;
using bArtSolutionTest.Domain.Services.Implementation;
using bArtSolutionTest.Domain.Services.Interfaces;

namespace bArtSolutionTest.WebApi.ServiceExtension
{
    public static class ServicesExtension
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IRepository<Incident>, Repository<Incident>>();
            services.AddScoped<IRepository<Account>, Repository<Account>>();
            services.AddScoped<IRepository<Contact>, Repository<Contact>>();
        }

        public static void InitializeConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
