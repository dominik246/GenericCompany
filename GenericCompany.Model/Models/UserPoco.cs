using GenericCompany.Common.BaseClasses.PocoModels;
using GenericCompany.Model.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Models
{
    public class UserPoco : BasePocoModel, IUserPoco
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
