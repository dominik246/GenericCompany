using GenericCompany.Common.BaseClasses.FilterModels;

namespace GenericCompany.Common.Filters.TransactionFilter
{
    public interface ITransactionFilter : IBaseFilterModel
    {
        string Name { get; set; }
        decimal Price { get; set; }
    }
}