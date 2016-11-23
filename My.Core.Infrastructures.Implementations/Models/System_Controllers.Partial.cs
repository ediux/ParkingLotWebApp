namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(System_ControllersMetaData))]
    public partial class System_Controllers
    {
    }

    public partial class System_ControllersMetaData
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        public int Id { get; set; }

        [StringLength(256, ErrorMessage = "欄位長度不得大於 256 個字元")]
        [Required]
        [Display(Name = "控制器路由名稱")]
        public string Name { get; set; }

        [StringLength(256, ErrorMessage = "欄位長度不得大於 256 個字元")]
        [Required]
        [Display(Name = "控制器類別名稱")]
        public string ClassName { get; set; }

        [StringLength(512, ErrorMessage = "欄位長度不得大於 512 個字元")]
        [Required]
        [Display(Name = "控制器命名空間")]
        public string Namespace { get; set; }
        [Required]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Required]
        [Display(Name = "CreateUserId", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int CreateUserId { get; set; }
        [Required]
        [Display(Name = "CreateTime", ResourceType = typeof(MUI))]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime CreateTime { get; set; }
        [Display(Name = "LastUpdateUserId", ResourceType = typeof(MUI))]
        [UIHint("UserIDMappingDisplay")]
        public Nullable<int> LastUpdateUserId { get; set; }
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        [UIHint("UTCLocalTimeDisplay")]
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        [Display(Name = "允許匿名")]
        [UIHint("YesNoDisplay")]
        public bool AllowAnonymous { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [Display(Name = "動作清單")]
        public virtual ICollection<System_ControllerActions> System_ControllerActions { get; set; }
    }
}
