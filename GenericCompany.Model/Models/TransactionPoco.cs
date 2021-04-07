using GenericCompany.Common.BaseClasses.PocoModels;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Models
{
    public class TransactionPoco : BasePocoModel, ITransactionPoco
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
