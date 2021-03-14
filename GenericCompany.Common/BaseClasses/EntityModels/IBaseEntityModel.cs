using System;

namespace GenericCompany.Common.BaseClasses.EntityModels
{
    public interface IBaseEntityModel
    {
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
        Guid Id { get; set; }
    }
}