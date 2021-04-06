using GenericCompany.Common.BaseClasses.FilterModels;
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
    public class UserTransactionService : IUserTransactionService
    {
        private readonly IUserTransactionRepository _repo;
        public UserTransactionService(IUserTransactionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> CreateAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            return await _repo.CreateAsync(modelList);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            return await _repo.DeleteRangeAsync(modelList);
        }

        public async Task<IEnumerable<IUserTransactionPoco>> FindAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            return await _repo.FindAsync(filter, fields);
        }

        public async Task<IUserTransactionPoco> GetAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            return await _repo.GetAsync(filter, fields);
        }

        public async Task<int> GetDbCountAsync(IBaseFilterModel filter = null)
        {
            return await _repo.GetDbCountAsync(filter);
        }

        public async Task<int> UpdateRangeAsync(IList<IUserTransactionPoco> modelList)
        {
            return await _repo.UpdateRangeAsync(modelList);
        }
    }
}
