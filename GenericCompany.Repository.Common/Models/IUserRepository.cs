using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericCompany.Repository.Common.Repositories
{
    public interface IUserRepository
    {
        Task<int> CreateAsync(IEnumerable<IUserPoco> modelList);
        Task<int> DeleteRangeAsync(IEnumerable<IUserPoco> modelList);
        Task<IEnumerable<IUserPoco>> FindAsync(IUserFilter filter, IUrlFields fields);
        Task<IUserPoco> GetAsync(IUserFilter filter, IUrlFields fields);
        Task<int> GetDbCountAsync(IUserFilter filter = null);
        Task<int> UpdateRangeAsync(IEnumerable<IUserPoco> modelList);
    }
}