using GenericCompany.Common.Enums;

namespace GenericCompany.Common.UrlFields
{
    public interface IUrlFields
    {
        string IncludeProperties { get; set; }
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string SearchQuery { get; set; }
        Sort.SortOrder SortOrder { get; set; }
        string SortProperty { get; set; }
    }
}