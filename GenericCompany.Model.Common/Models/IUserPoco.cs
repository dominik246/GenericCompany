using GenericCompany.Common.BaseClasses.PocoModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCompany.Model.Common.Models
{
    public interface IUserPoco : IBasePocoModel
    {
        string Email { get; set; }
        string FullName { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}
