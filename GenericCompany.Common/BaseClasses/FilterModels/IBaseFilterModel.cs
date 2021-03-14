using GenericCompany.Common.Custom;

using System;
using System.Collections.Generic;

namespace GenericCompany.Common.BaseClasses.FilterModels
{
    public interface IBaseFilterModel
    {
        DateTime? DateCreated { get; set; }
#nullable enable
        Records.DateTimeRange? DateTimeRange { get; set; }
#nullable disable
        DateTime? DateUpdated { get; set; }
        Guid? Id { get; set; }
        HashSet<Guid> Ids { get; set; }
        string SearchQuery { get; set; }
    }
}