using GenericCompany.Common.BaseClasses.PocoModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Common.Models
{
    public interface ITransactionPoco : IBasePocoModel
    {
        string Description { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
