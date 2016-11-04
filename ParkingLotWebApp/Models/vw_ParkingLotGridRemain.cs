using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class vw_ParkingLotGridRemain
    {
       
        public bool NoneFloor { get; set; }

        public string 樓層名稱 { get; set; }

        public int 剩餘停車格數 { get; set; }

        public int 剩餘機車格數 { get; set; }

        public short FloorOrder { get; set; }
    }
}