using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static GenericCompany.Common.Enums.Sort;

namespace GenericCompany.Common.UrlFields
{
    public class UrlFields : IUrlFields
    {
        public string SearchQuery { get; set; } = "";
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 30;
        public string SortProperty { get; set; } = "Name";
        public SortOrder SortOrder { get; set; }
        public string IncludeProperties { get; set; }
    }
}
