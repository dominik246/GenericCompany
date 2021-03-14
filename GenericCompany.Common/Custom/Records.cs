using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Common.Custom
{
    public static class Records
    {
        public record DateTimeRange(DateTime startDate, DateTime endDate);
    }
}
