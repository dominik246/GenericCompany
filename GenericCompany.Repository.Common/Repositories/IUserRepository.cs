using GenericCompany.Common.BaseClasses.BaseRepositoryModels;
using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericCompany.Repository.Common.Repositories
{
    public interface IUserRepository :
        IApplicationReadDbConnection<IUserPoco, IUserFilter, IUrlFields>,
        IApplicationWriteDbConnection<IUserPoco, IUserFilter>
    {
    }
}