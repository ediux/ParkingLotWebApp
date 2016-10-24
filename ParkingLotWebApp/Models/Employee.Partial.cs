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
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "員工姓名")]
        public string Name { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        [Display(Name = "員工代碼")]
        public string Code { get; set; }
        [Required]
        [Display(Name = "是否刪除")]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "建立者")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "建立時間")]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        [Display(Name = "最後更新者")]
        public int LastUserId { get; set; }
        [Required]
        [Display(Name = "最後更新時間")]
        public System.DateTime LastUpdateUTCTime { get; set; }
    
        public virtual ICollection<Cars> Cars { get; set; }
    }
}
