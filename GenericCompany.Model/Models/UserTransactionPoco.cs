using GenericCompany.Common.BaseClasses.PocoModels;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Models
{
    public class UserTransactionPoco : BasePocoModel, IUserTransactionPoco
    {
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public ITransactionPoco Transaction { get; set; }
        public IUserPoco User { get; set; }
    }
}
