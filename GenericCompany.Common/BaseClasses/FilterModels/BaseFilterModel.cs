using GenericCompany.Common.Custom;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.BaseClasses.FilterModels
{
    public class BaseFilterModel : IBaseFilterModel
    {
        public Guid? Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
#nullable enable
        public Records.DateTimeRange? DateTimeRange { get; set; }
#nullable disable
        public string SearchQuery { get; set; }
        public HashSet<Guid> Ids { get; set; }
    }
}
