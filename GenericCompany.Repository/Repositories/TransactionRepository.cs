using AutoMapper;

using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.Filters.TransactionFilter;
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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly PublicDbContext _db;
        private readonly IMapper Mapper;
        public TransactionRepository(PublicDbContext db, IMapper mapper)
        {
            _db = db;
            Mapper = mapper;
        }
        public async Task<int> CreateAsync(IEnumerable<ITransactionPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<TransactionEntity>>(modelList);
            var table = _db.Transaction;
            await table.AddRangeAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<ITransactionPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<TransactionEntity>>(modelList);
            var table = _db.Transaction;
            await table.BulkDeleteAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ITransactionPoco>> FindAsync(ITransactionFilter filter, IUrlFields fields)
        {
            var table = _db.Transaction;
            var sql = FilterTransaction(table, filter);
            sql = SetFields(sql, fields);
            var result = await sql.ToListAsync();
            return Mapper.Map<IEnumerable<ITransactionPoco>>(result);
        }

        public async Task<ITransactionPoco> GetAsync(ITransactionFilter filter, IUrlFields fields)
        {
            var table = _db.Transaction;
            var sql = FilterTransaction(table, filter);
            var result = await sql.FirstOrDefaultAsync();
            return Mapper.Map<ITransactionPoco>(result);
        }

        public async Task<int> GetDbCountAsync(ITransactionFilter filter = null)
        {
            var table = _db.Transaction;
            if (filter == null)
            {
                return await table.CountAsync();
            }
            var sql = FilterTransaction(table, filter);
            return await sql.CountAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<ITransactionPoco> modelList)
        {
            var table = _db.Transaction;
            var entityList = Mapper.Map<IEnumerable<TransactionEntity>>(modelList);
            await table.BulkUpdateAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        private static IQueryable<TransactionEntity> FilterTransaction(IQueryable<TransactionEntity> query, ITransactionFilter filter)
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
                if(filter.Name != default)
                {
                    query = query.Where(u => u.Name.Contains(filter.Name));
                }
                if (filter.Price != default)
                {
                    query = query.Where(u => u.Price == filter.Price);
                }
            }
            return query;
        }

        private static IQueryable<TransactionEntity> SetFields(IQueryable<TransactionEntity> query, IUrlFields fields)
        {
            if (fields != default)
            {
                if (fields.PageSize != default && fields.PageNumber != default)
                {
                    const int zeroIndex = 1;
                    query = query
                    .Skip(fields.PageSize * (fields.PageNumber - zeroIndex))
                    .Take(fields.PageSize);
                }
                if (fields.SortOrder != default &&
                   fields.SortProperty != default)
                {
                    switch (fields.SortOrder)
                    {
                        case SortOrder.Desc:
                            query = query.OrderByDescending(u => SwitchSortProperty(fields, u));
                            break;
                        case SortOrder.Asc:
                            query = query.OrderBy(u => SwitchSortProperty(fields, u));
                            break;
                    }
                }
            }
            return query;
        }

        private static string SwitchSortProperty(IUrlFields fields, TransactionEntity entity)
        {
            return true switch
            {
                var _ when TypeSafeComparison<TransactionEntity>
                    .Name(p => p.Name)
                    .Equals(fields.SortProperty, StringComparison.OrdinalIgnoreCase) => nameof(entity.Name),
                var _ when TypeSafeComparison<TransactionEntity>
                    .Name(p => p.Price)
                    .Equals(fields.SortProperty, StringComparison.OrdinalIgnoreCase) => nameof(entity.Price),
                _ => default,
            };
        }

    }
}
