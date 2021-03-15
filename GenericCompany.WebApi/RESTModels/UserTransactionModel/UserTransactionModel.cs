using GenericCompany.Common.BaseClasses.RESTModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.RESTModels.UserTransactionModel
{
    public class UserTransactionModel : BaseRESTModel
    {
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public TransactionModel.TransactionModel Transaction { get; set; }
        public UserModel.UserModel User { get; set; }
    }
}
