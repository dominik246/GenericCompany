using AutoMapper;

using GenericCompany.Common.Filters.UserFilter;
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
    public class UserRepository : IUserRepository
    {
        private readonly PublicDbContext _db;
        private readonly IMapper Mapper;
        public UserRepository(PublicDbContext db, IMapper mapper)
        {
            _db = db;
            Mapper = mapper;
        }

        public async Task<int> CreateAsync(IEnumerable<IUserPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<UserEntity>>(modelList);
            var table = _db.Users;
            await table.AddRangeAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<IUserPoco> modelList)
        {
            var entityList = Mapper.Map<IEnumerable<UserEntity>>(modelList);
            var table = _db.Users;
            await table.BulkDeleteAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<IUserPoco>> FindAsync(IUserFilter filter, IUrlFields fields)
        {
            var table = _db.Users;
            var sql = FilterUser(table, filter);
            sql = SetFields(sql, fields);
            var result = await sql.ToListAsync();
            return Mapper.Map<IEnumerable<IUserPoco>>(result);
        }

        public async Task<IUserPoco> GetAsync(IUserFilter filter, IUrlFields fields)
        {
            var table = _db.Users;
            var sql = FilterUser(table, filter);
            var result = await sql.FirstOrDefaultAsync();
            return Mapper.Map<IUserPoco>(result);
        }

        public async Task<int> GetDbCountAsync(IUserFilter filter = null)
        {
            var table = _db.Users;
            if (filter == null)
            {
                return await table.CountAsync();
            }
            var sql = FilterUser(table, filter);
            return await sql.CountAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<IUserPoco> modelList)
        {
            var table = _db.Users;
            var entityList = Mapper.Map<IEnumerable<UserEntity>>(modelList);
            await table.BulkUpdateAsync(entityList);
            return await _db.SaveChangesAsync();
        }

        private static IQueryable<UserEntity> FilterUser(IQueryable<UserEntity> query, IUserFilter filter)
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

        private static IQueryable<UserEntity> SetFields(IQueryable<UserEntity> query, IUrlFields fields)
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

        private static string SwitchSortProperty(IUrlFields fields, UserEntity entity)
        {
            return true switch
            {
                var _ when TypeSafeComparison<UserEntity>
                    .Name(p => p.FullName)
                    .Equals(fields.SortProperty, StringComparison.OrdinalIgnoreCase) => nameof(entity.FullName),
                var _ when TypeSafeComparison<UserEntity>
                    .Name(p => p.Email)
                    .Equals(fields.SortProperty, StringComparison.OrdinalIgnoreCase) => nameof(entity.Email),
                var _ when TypeSafeComparison<UserEntity>
                    .Name(p => p.UserName)
                    .Equals(fields.SortProperty, StringComparison.OrdinalIgnoreCase) => nameof(entity.UserName),
                _ => default,
            };
        }
    }
}
