using AutoMapper;

using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.Generic;
using GenericCompany.Common.UrlFields;
using GenericCompany.DAL.Models;
using GenericCompany.DAL.Tables;
using GenericCompany.Model.Common.Models;
using GenericCompany.Repository.Common.Repositories;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GenericCompany.Common.Enums.Sort;

namespace GenericCompany.Repository.Repositories
{
    public class UserTransactionRepository : IUserTransactionRepository
    {
        private readonly PublicDbContext _db;
        private readonly IMapper Mapper;
        public UserTransactionRepository(PublicDbContext db, IMapper mapper)
        {
            _db = db;
            Mapper = mapper;
        }
        public async Task<int> CreateAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<UserTransactionEntity>>(modelList);
            var table = _db.UserTransaction;
            await table.AddRangeAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<UserTransactionEntity>>(modelList);
            var table = _db.UserTransaction;
            await table.BulkDeleteAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<IUserTransactionPoco>> FindAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            var table = _db.UserTransaction;
            var sql = FilterUserTransaction(table, filter);
            var result = await sql.ToListAsync();
            return Mapper.Map<IEnumerable<IUserTransactionPoco>>(result);
        }

        public async Task<IUserTransactionPoco> GetAsync(IBaseFilterModel filter, IUrlFields fields)
        {
            var table = _db.UserTransaction;
            var sql = FilterUserTransaction(table, filter);
            var result = await sql.FirstOrDefaultAsync();
            return Mapper.Map<IUserTransactionPoco>(result);
        }

        public async Task<int> GetDbCountAsync(IBaseFilterModel filter = null)
        {
            var table = _db.UserTransaction;
            if (filter == null)
            {
                return await table.CountAsync();
            }
            var sql = FilterUserTransaction(table, filter);
            return await sql.CountAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<IUserTransactionPoco> modelList)
        {
            var table = _db.UserTransaction;
            var entityList = Mapper.Map<IEnumerable<UserTransactionEntity>>(modelList);
            await table.BulkUpdateAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        private static IQueryable<UserTransactionEntity> FilterUserTransaction(IQueryable<UserTransactionEntity> query, IBaseFilterModel filter)
        {
            if (filter != null)
            {
                if (filter.Id != default)
                {
                    query = query.Where(u => u.Id == filter.Id);
                }
                if (filter.DateCreated != default)
                {
                    query = query.Where(u => u.DateCreated == filter.DateCreated);
                }
                if (filter.Ids != default)
                {
                    query = query.Where(u => filter.Ids.Contains(u.Id));
                }
            }
            return query;
        }
    }
}
