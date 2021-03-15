using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.UrlFields;
using GenericCompany.Model.Common.Models;
using GenericCompany.Repository.Common.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Repository.Repositories
{
    public class UserTransactionRepository : IUserTransactionRepository
    {
        public Task<int> CreateAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRangeAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUserTransactionPoco>> FindAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            throw new NotImplementedException();
        }

        public Task<IUserTransactionPoco> GetAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetDbCountAsync(IBaseFilterModel filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRangeAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }
    }
}
