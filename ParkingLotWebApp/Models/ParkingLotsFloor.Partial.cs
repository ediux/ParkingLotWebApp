namespace ParkingLotWebApp.Models
{
    using App_GlobalResources;
    using My.Core.Infrastructures.Implementations.Resources;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ParkingLotsFloorMetaData))]
    public partial class ParkingLotsFloor
    {
        public static ParkingLotsFloor Create()
        {
            return new ParkingLotsFloor()
            {
                LastUpdate = DateTime.Now
            };
        }
    }
    
    public partial class ParkingLotsFloorMetaData
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        public int ID { get; set; }
        [Required]
        [Display(Name = "ParkingLotsDetail_Name", ResourceType = typeof(WebPages))]
        public int ParkingLotsID { get; set; }
        [Required]
        [Display(Name = "ParkingLotsFloor_FloorOrder", ResourceType = typeof(WebPages))]
        public short FloorOrder { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        [Display(Name = "ParkingLotsFloor_FloorName", ResourceType = typeof(WebPages))]
        public string FloorName { get; set; }
        [Required]
        [Display(Name = "ParkingLotsFloor_CarTotalGrid", ResourceType = typeof(WebPages))]
        public int CarTotalGrid { get; set; }
        [Required]
        [Display(Name = "ParkingLotsFloor_CarLastGrid", ResourceType = typeof(WebPages))]
        public int CarLastGrid { get; set; }
        [Required]
        [Display(Name = "ParkingLotsFloor_MotoTotalGrid", ResourceType = typeof(WebPages))]
        public int MotoTotalGrid { get; set; }
        [Required]
        [Display(Name = "ParkingLotsFloor_MotoLastGrid", ResourceType = typeof(WebPages))]
        public int MotoLastGrid { get; set; }
        [Required]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        public bool Void { get; set; }
        [Display(Name = "LastUpdate", ResourceType = typeof(Common))]
        public Nullable<System.DateTime> LastUpdate { get; set; }
        [Required]
        public int CarLastGridRFID { get; set; }
        [JsonIgnore]
        public virtual ParkingLotsDetail ParkingLotsDetail { get; set; }
        public virtual ICollection<ParkingLotsRecord_HT> ParkingLotsRecord_HT { get; set; }
        public virtual ICollection<ParkingLotsRecord> ParkingLotsRecord { get; set; }
    }
}
