using GenericCompany.Common.BaseClasses.BaseRepositoryModels;
using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Repository.Common.Repositories
{
    public interface ITransactionRepository : IApplicationReadDbConnection<ITransactionPoco, IBaseFilterModel, IUrlFields>,
        IApplicationWriteDbConnection<ITransactionPoco, IBaseFilterModel>
    {
    }
}
