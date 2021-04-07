using GenericCompany.Common.BaseClasses.PocoModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Common.Models
{
    public interface IUserTransactionPoco : IBasePocoModel
    {
        Guid UserId { get; set; }
        Guid TransactionId { get; set; }
        ITransactionPoco Transaction { get; set; }
        IUserPoco User { get; set; }
    }
}
