using GenericCompany.DAL.Tables;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.DAL
{
    public static class DIModule
    {
        public static IServiceCollection AddDAL(this IServiceCollection services)
        {
            services
                .AddDbContext<PublicDbContext>();

            return services;
        }
    }
}
