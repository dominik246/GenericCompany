using GenericCompany.Common.BaseClasses.EntityModels;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.DAL.Models
{
    public class UserEntity : BaseEntityModel
    {
        [MaxLength(24)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(64)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(128)]
        [Required]
        public string Password { get; set; }

        [MaxLength(48)]
        [Required]
        public string Email { get; set; }
    }
}
