namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(System_ControllerActionsMetaData))]
    public partial class System_ControllerActions
    {
    }

    public partial class System_ControllerActionsMetaData
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        public int Id { get; set; }

        [StringLength(256, ErrorMessage = "欄位長度不得大於 256 個字元")]
        [Required]
        [Display(Name = "動作名稱")]
        public string Name { get; set; }
        [Display(Name = "所屬控制器")]
        public Nullable<int> ControllerId { get; set; }
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
        [UIHint("UTCLocalTimeDisplay")]
        [Display(Name = "LastUpdateTime", ResourceType = typeof(MUI))]
        public Nullable<System.DateTime> LastUpdateTime { get; set; }

        [Display(Name = "控制器")]
        public virtual System_Controllers System_Controllers { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Menus> Menus { get; set; }
    }
}
