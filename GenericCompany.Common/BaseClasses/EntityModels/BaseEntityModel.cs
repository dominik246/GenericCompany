using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.BaseClasses.EntityModels
{
    public class BaseEntityModel : IBaseEntityModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateCreated { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public DateTime? DateUpdated { get; set; }
    }
}
