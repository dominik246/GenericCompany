using GenericCompany.Repository;
using GenericCompany.Service.Common.Services;
using GenericCompany.Service.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Service
{
    public static class DIModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddRepositories()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ITransactionService, TransactionService>()
                .AddScoped<IUserTransactionService, UserTransactionService>();

            return services;
        }
    }
}
