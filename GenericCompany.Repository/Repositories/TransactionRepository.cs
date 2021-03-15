﻿using GenericCompany.Common.BaseClasses.FilterModels;
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
    public class TransactionRepository : ITransactionRepository
    {
        public Task<int> CreateAsync(IEnumerable<ITransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteRangeAsync(IEnumerable<ITransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ITransactionPoco>> FindAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            throw new NotImplementedException();
        }

        public Task<ITransactionPoco> GetAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetDbCountAsync(IBaseFilterModel filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRangeAsync(IEnumerable<ITransactionPoco> modelList)
        {
            throw new NotImplementedException();
        }
    }
}