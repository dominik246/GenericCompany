﻿using GenericCompany.Common.BaseClasses.RESTModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCompany.WebApi.RESTModels.UserModel
{
    public class UserModel : BaseRESTModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
