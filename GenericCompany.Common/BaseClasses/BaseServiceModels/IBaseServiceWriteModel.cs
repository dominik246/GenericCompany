using GenericCompany.Common.BaseClasses.FilterModels;
using GenericCompany.Common.BaseClasses.PocoModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.BaseClasses.BaseServiceModels
{
    public interface IBaseServiceWriteModel<T, U, V>
        where T : IBasePocoModel
        where U : IConvertible
        where V : IBaseFilterModel
    {
        Task<int> CreateAsync(IEnumerable<T> modelList);
        Task<int> DeleteRangeAsync(IEnumerable<T> modelList);
        Task<int> UpdateRangeAsync(IList<T> modelList);
    }
}
