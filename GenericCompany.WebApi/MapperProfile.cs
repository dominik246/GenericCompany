using AutoMapper;

using GenericCompany.Model.Common.Models;
using GenericCompany.WebApi.RESTModels.UserModel;

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
        }
    }
}
