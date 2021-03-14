using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.BaseClasses.PocoModels;
using GenericCompany.Common.UrlFields;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.BaseClasses.BaseRepositoryModels
{
    public interface IApplicationReadDbConnection<T, U, V>
        where T : IBasePocoModel
        where U : IBaseFilterModel
        where V : IUrlFields
    {
        Task<IEnumerable<T>> FindAsync(U filter, V fields);
        Task<T> GetAsync(U filter, V fields);
        Task<int> GetDbCountAsync(U filter = default);
    }
}
