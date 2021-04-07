using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.Filters.TransactionFilter;
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
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repo;
        public TransactionService(ITransactionRepository repo)
        {
            _repo = repo;
        }
        public async Task<int> CreateAsync(IEnumerable<ITransactionPoco> modelList)
        {
            return await _repo.CreateAsync(modelList);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<ITransactionPoco> modelList)
        {
            return await _repo.DeleteRangeAsync(modelList);
        }

        public async Task<IEnumerable<ITransactionPoco>> FindAsync(ITransactionFilter filter, IUrlFields fields)
        {
            return await _repo.FindAsync(filter, fields);
        }

        public async Task<ITransactionPoco> GetAsync(ITransactionFilter filter, IUrlFields fields)
        {
            return await _repo.GetAsync(filter, fields);
        }

        public async Task<int> GetDbCountAsync(ITransactionFilter filter = null)
        {
            return await _repo.GetDbCountAsync(filter);
        }

        public async Task<int> UpdateRangeAsync(IList<ITransactionPoco> modelList)
        {
            return await _repo.UpdateRangeAsync(modelList);
        }
    }
}
