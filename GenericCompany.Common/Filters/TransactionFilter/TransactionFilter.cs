using GenericCompany.Common.BaseClasses.FilterModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.Filters.TransactionFilter
{
    public class TransactionFilter : BaseFilterModel, ITransactionFilter
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
