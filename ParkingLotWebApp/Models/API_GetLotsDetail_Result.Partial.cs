namespace ParkingLotWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_GetLotsDetail_ResultMetaData))]
    public partial class API_GetLotsDetail_Result
    {
    	public static API_GetLotsDetail_Result Create(){
    		return new API_GetLotsDetail_Result();
    	}
    }
    
    public partial class API_GetLotsDetail_ResultMetaData
    {
        [Required]
        public int ID { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        public string Name { get; set; }
        
        [StringLength(75, ErrorMessage="欄位長度不得大於 75 個字元")]
        [Required]
        public string Address { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        [Required]
        public string Tel { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        public string Period { get; set; }
        
        [StringLength(512, ErrorMessage="欄位長度不得大於 512 個字元")]
        [Required]
        public string Charge { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        public Nullable<int> CarTotalGrid { get; set; }
        public Nullable<int> CarLastGrid { get; set; }
        public Nullable<int> MotoTotalGrid { get; set; }
        public Nullable<int> MotoLastGrid { get; set; }
    }
}
