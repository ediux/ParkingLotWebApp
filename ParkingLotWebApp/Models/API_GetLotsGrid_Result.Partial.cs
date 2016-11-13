namespace ParkingLotWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_GetLotsGrid_ResultMetaData))]
    public partial class API_GetLotsGrid_Result
    {
    	public static API_GetLotsGrid_Result Create(){
    		return new API_GetLotsGrid_Result();
    	}
    }
    
    public partial class API_GetLotsGrid_ResultMetaData
    {
        public Nullable<int> CarTotalGrid { get; set; }
        public Nullable<int> CarLastGrid { get; set; }
        public Nullable<int> MotoTotalGrid { get; set; }
        public Nullable<int> MotoLastGrid { get; set; }
        [Required]
        public int ID { get; set; }
    }
}
