using GenericCompany.Common.BaseClasses.BaseServiceModels;
using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Service.Common.Services
{
    public interface IUserTransactionService : IBaseServiceReadModel<IUserTransactionPoco, IBaseFilterModel, IUrlFields>,
        IBaseServiceWriteModel<IUserTransactionPoco, IBaseFilterModel>
    {
    }
}
