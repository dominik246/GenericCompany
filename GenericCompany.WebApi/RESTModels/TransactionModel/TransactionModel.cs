using GenericCompany.Common.BaseClasses.RESTModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.RESTModels.TransactionModel
{
    public class TransactionModel : BaseRESTModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
    }
}
