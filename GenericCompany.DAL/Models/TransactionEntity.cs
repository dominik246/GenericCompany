using GenericCompany.Common.BaseClasses.EntityModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.DAL.Models
{
    public class TransactionEntity : BaseEntityModel
    {
        [MaxLength(24)]
        [Required]
        public string Name { get; set; }
        [MaxLength(3000)]
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
