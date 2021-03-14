using GenericCompany.Common.BaseClasses.BaseServiceModels;
using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GenericCompany.Common.Enums.TaskStatus;

namespace GenericCompany.Service.Common.Services
{
    public interface IUserService : IBaseServiceReadModel<IUserPoco, IUserFilter, IUrlFields>,
                                    IBaseServiceWriteModel<IUserPoco, ReturnStatus, IUserFilter>
    {
    }
}
