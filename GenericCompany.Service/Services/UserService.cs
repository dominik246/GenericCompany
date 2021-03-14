using GenericCompany.Common.Filters.UserFilter;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;
using GenericCompany.Repository.Common.Repositories;
using GenericCompany.Service.Common.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> CreateAsync(IEnumerable<IUserPoco> modelList)
        {
            return await _repo.CreateAsync(modelList);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<IUserPoco> modelList)
        {
            return await _repo.DeleteRangeAsync(modelList);
        }

        public async Task<IEnumerable<IUserPoco>> FindAsync(IUserFilter filter, IUrlFields fields)
        {
            return await _repo.FindAsync(filter, fields);
        }

        public async Task<IUserPoco> GetAsync(IUserFilter filter, IUrlFields fields)
        {
            return await _repo.GetAsync(filter, fields);
        }

        public async Task<int> GetDbCountAsync(IUserFilter filter = null)
        {
            return await _repo.GetDbCountAsync(filter);
        }

        public async Task<int> UpdateRangeAsync(IList<IUserPoco> modelList)
        {
            return await _repo.UpdateRangeAsync(modelList);
        }
    }
}
