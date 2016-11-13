namespace ParkingLotWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_GetFloorsGrid_ResultMetaData))]
    public partial class API_GetFloorsGrid_Result
    {
    	public static API_GetFloorsGrid_Result Create(){
    		return new API_GetFloorsGrid_Result();
    	}
    }
    
    public partial class API_GetFloorsGrid_ResultMetaData
    {
        [Required]
        public int CarTotalGrid { get; set; }
        [Required]
        public int CarLastGrid { get; set; }
        [Required]
        public int MotoTotalGrid { get; set; }
        [Required]
        public int MotoLastGrid { get; set; }
        [Required]
        public short FloorOrder { get; set; }
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        public string FloorName { get; set; }
        [Required]
        public int ID { get; set; }
    }
}
