using My.Core.Infrastructures.Implementations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class UserProfileViewModel : ApplicationUser
    {
        public int RoleId { get; set; }
    }
}