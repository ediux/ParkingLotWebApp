using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class ApplicationRole : IRole<int>
    {
        public static ApplicationRole Create()
        {
            return new ApplicationRole()
            {
                Id = -1,
                CreateTime = DateTime.Now.ToUniversalTime(),
                CreateUserId = -1,
                LastUpdateTime = DateTime.Now.ToUniversalTime(),
                LastUpdateUserId = -1,
                Name = string.Empty,
              
            };
        }
    }
}
