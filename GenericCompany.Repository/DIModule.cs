using GenericCompany.DAL;
using GenericCompany.Repository.Common.Repositories;
using GenericCompany.Repository.Repositories;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Repository
{
    public static class DIModule
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddDAL()
                .AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
