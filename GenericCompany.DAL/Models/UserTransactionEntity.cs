using GenericCompany.Common.BaseClasses.EntityModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.DAL.Models
{
    public class UserTransactionEntity : BaseEntityModel
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [ForeignKey("Transaction")]
        public Guid TransactionId { get; set; }
        public UserEntity User { get; set; }
        public TransactionEntity Transaction { get; set; }
    }
}
