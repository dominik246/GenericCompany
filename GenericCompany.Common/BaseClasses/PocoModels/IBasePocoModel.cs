using System;

namespace GenericCompany.Common.BaseClasses.PocoModels
{
    public interface IBasePocoModel
    {
        DateTime DateCreated { get; set; }
        DateTime? DateUpdated { get; set; }
        Guid Id { get; set; }
    }
}