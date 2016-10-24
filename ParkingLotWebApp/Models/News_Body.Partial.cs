namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(News_BodyMetaData))]
    public partial class News_Body
    {
    }
    
    public partial class News_BodyMetaData
    {
        [Required]
        public int Id { get; set; }
        [Display(Name="���i���D")]
        public Nullable<int> Header_Id { get; set; }
        [Display(Name="���i���e")]
        public string Content { get; set; }
        [Required]
        [Display(Name="������")]
        public int Version { get; set; }
        [Required]
        [Display(Name="�إߪ�")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "�إ߮ɶ�")]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        [Display(Name = "�̫��s��")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "�̫��s�ɶ�")]
        public System.DateTime LastUpdateUTCTime { get; set; }
    
        public virtual News_Header News_Header { get; set; }
    }
}
