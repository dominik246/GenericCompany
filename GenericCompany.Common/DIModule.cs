using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.BaseClasses.PocoModels;
using GenericCompany.Common.BaseClasses.RESTModels;
using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common
{
    public static class DIModule
    {
        public static IServiceCollection AddCommons(this IServiceCollection services)
        {
            services
                .AddScoped<IBaseFilterModel, BaseFilterModel>()
                .AddScoped<IBasePocoModel, BasePocoModel>()
                .AddScoped<IBaseRESTModel, BaseRESTModel>()

                .AddScoped<IUserFilter, UserFilter>()

                .AddScoped<IUrlFields, UrlFields.UrlFields>();

            return services;
        }
    }
}
