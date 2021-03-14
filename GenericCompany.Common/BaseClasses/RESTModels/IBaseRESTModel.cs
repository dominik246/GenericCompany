using System;

namespace GenericCompany.Common.BaseClasses.RESTModels
{
    public interface IBaseRESTModel
    {
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
        Guid Id { get; set; }
    }
}