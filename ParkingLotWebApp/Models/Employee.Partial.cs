namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    public partial class EmployeeMetaData
    {
        public virtual ICollection<Cars> Cars { get; set; }
    }
}
