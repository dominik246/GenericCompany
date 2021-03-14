using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.BaseClasses.PocoModels
{
    public class BasePocoModel : IBasePocoModel
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateUpdated { get; set; } = DateTime.Now;
    }
}
