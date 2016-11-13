namespace ParkingLotWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_GetAnnouncement_ResultMetaData))]
    public partial class API_GetAnnouncement_Result
    {
    	public static API_GetAnnouncement_Result Create(){
    		return new API_GetAnnouncement_Result();
    	}
    }
    
    public partial class API_GetAnnouncement_ResultMetaData
    {
        [Required]
        public int No { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        
        [StringLength(1000, ErrorMessage="欄位長度不得大於 1000 個字元")]
        [Required]
        public string Detail { get; set; }
        [Required]
        public bool ToTop { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        public string StartDate { get; set; }
    }
}
