using AutoMapper;

using GenericCompany.Model.Common.Models;
using GenericCompany.WebApi.RESTModels.TransactionModel;
using GenericCompany.WebApi.RESTModels.UserModel;
using GenericCompany.WebApi.RESTModels.UserTransactionModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IUserPoco, UserModel>().ReverseMap();
            CreateMap<ITransactionPoco, TransactionModel>().ReverseMap();
            CreateMap<IUserTransactionPoco, UserTransactionModel>().ReverseMap();
        }
    }
}
