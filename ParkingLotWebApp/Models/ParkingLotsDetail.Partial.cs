namespace ParkingLotWebApp.Models
{
    using App_GlobalResources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using My.Core.Infrastructures.Implementations.Resources;
    using System.Collections.ObjectModel;

    /// <summary>
    /// 停車場資訊
    /// </summary>
    [MetadataType(typeof(ParkingLotsDetailMetaData))]
    public partial class ParkingLotsDetail
    {
        public static ParkingLotsDetail Create()
        {
            return new ParkingLotsDetail()
            {
                Address = string.Empty,
                Charge = string.Empty,
                ID = 0,
                LastUpdate = DateTime.Now,
                Latitude = 0.0f,
                Longitude = 0.0f,
                Name = string.Empty,
                ParkingLotsFloor = new Collection<ParkingLotsFloor>(),
                Period = "",
                Tel = "",
                Void = false
            };
        }
    }

    public partial class ParkingLotsDetailMetaData
    {
        [Required]
        [Display(Name = "ParkingLotsDetail_ID", ResourceType = typeof(WebPages))]
        public int ID { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required]
        [Display(Name = "ParkingLotsDetail_Name", ResourceType = typeof(WebPages))]
        public string Name { get; set; }

        [StringLength(75, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required]
        [Display(Name = "ParkingLotsDetail_Address", ResourceType = typeof(WebPages))]
        public string Address { get; set; }

        [StringLength(15, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required]
        [Display(Name = "Tel", ResourceType = typeof(Common))]
        [Phone]
        public string Tel { get; set; }

        [StringLength(25, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required]
        [Display(Name = "ParkingLotsDetail_Period", ResourceType = typeof(WebPages))]
        [RegularExpression("\\d{1,2}:\\d{1,2}~\\d{1,2}:\\d{1,2}",
            ErrorMessageResourceName = "ParkingLotsDetail_Period_VaildErrorMessage",
            ErrorMessageResourceType = typeof(WebPages))]
        public string Period { get; set; }

        [StringLength(100, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(ErrorMessage))]
        [Required]
        [Display(Name = "Charge", ResourceType = typeof(Common))]
        public string Charge { get; set; }
        [Required]
        [Display(Name = "Longitude", ResourceType = typeof(Common))]
        public double Longitude { get; set; }
        [Required]
        [Display(Name = "Latitude", ResourceType = typeof(Common))]
        public double Latitude { get; set; }
        [Required]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        public bool Void { get; set; }
        [Display(Name = "ParkingLotsDetail_LastUpdate", ResourceType = typeof(WebPages))]
        public DateTime? LastUpdate { get; set; }
    }
}
