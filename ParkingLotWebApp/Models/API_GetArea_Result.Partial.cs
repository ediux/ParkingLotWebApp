namespace ParkingLotWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(API_GetArea_ResultMetaData))]
    public partial class API_GetArea_Result
    {
    	public static API_GetArea_Result Create(){
    		return new API_GetArea_Result();
    	}
    }
    
    public partial class API_GetArea_ResultMetaData
    {
        [Required]
        public int AreaID { get; set; }
        
        [StringLength(25, ErrorMessage="欄位長度不得大於 25 個字元")]
        [Required]
        public string Name { get; set; }
    }
}
