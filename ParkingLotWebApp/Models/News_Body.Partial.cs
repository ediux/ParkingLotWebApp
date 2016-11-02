namespace ParkingLotWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(News_BodyMetaData))]
    public partial class News_Body
    {
        public static News_Body Create(int UserId)
        {
            var model = new News_Body();
            model.Void = false;
            model.LastUpdateUserId = model.CreateUserId = UserId;
            model.LastUpdateUTCTime = model.CreateUTCTime = DateTime.Now.ToUniversalTime();
            return model;
        }
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
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "�إ߮ɶ�")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateUTCTime { get; set; }
        [Required]
        [Display(Name = "�̫��s��")]
        [UIHint("UserIDMappingDisplay")]
        public int LastUpdateUserId { get; set; }
        [Required]
        [Display(Name = "�̫��s�ɶ�")]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LastUpdateUTCTime { get; set; }
        [Required]
        [Display(Name = "���A")]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }

        public virtual News_Header News_Header { get; set; }
    }
}
