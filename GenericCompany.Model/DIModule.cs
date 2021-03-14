using GenericCompany.Common;
using GenericCompany.Model.Common.Models;
using GenericCompany.Model.Models;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model
{
    public static class DIModule
    {
        public static IServiceCollection AddModels(this IServiceCollection services)
        {
            services
                .AddCommons()

                .AddScoped<IUserPoco, UserPoco>();

            return services;
        }
    }
}
