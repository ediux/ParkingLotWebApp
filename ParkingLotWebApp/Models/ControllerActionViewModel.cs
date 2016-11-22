using My.Core.Infrastructures.Implementations.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class ControllerActionViewModel
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        public int Id { get; set; }

        [Required]
        [Display(Name = "動作名稱")]
        public string Name { get; set; }
    }
}