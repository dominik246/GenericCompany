using AutoMapper;

using GenericCompany.DAL.Models;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Repository
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, IUserPoco>().ReverseMap();
        }
    }
}
