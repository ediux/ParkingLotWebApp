namespace My.Core.Infrastructures.Implementations.Models
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(MenusMetaData))]
    public partial class Menus
    {
    }

    public partial class MenusMetaData
    {
        [Required]
        [Display(Name = "Id", ResourceType = typeof(MUI))]
        public int Id { get; set; }

        [StringLength(256, ErrorMessage = "欄位長度不得大於 256 個字元")]
        [Required]
        [Display(Name = "選單名稱")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Display(Name = "圖示CSS")]
        public string IconCSS { get; set; }
        [Required]
        [Display(Name = "是否為外部URL")]
        public bool IsExternalLinks { get; set; }

        [StringLength(2048, ErrorMessage = "欄位長度不得大於 2048 個字元")]
        [Display(Name = "外部URL")]
        public string ExternalURL { get; set; }
        [Required]
        [Display(Name = "Void", ResourceType = typeof(MUI))]
        [UIHint("VoidDisplay")]
        public bool Void { get; set; }
        [Display(Name = "上層選單識別代碼")]
        public Nullable<int> ParentMenuId { get; set; }
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
        
        public Nullable<int> System_ControllerActionsId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [Display(Name = "子選單")]
        public virtual ICollection<Menus> ChildMenus { get; set; }
        [Display(Name = "上層選單")]
        public virtual Menus ParentMenu { get; set; }
                
        [Display(Name = "應用程式角色")]
        public virtual ICollection<ApplicationRole> ApplicationRole { get; set; }

        [Display(Name = "對應控制器動作")]
        public virtual System_ControllerActions System_ControllerActions { get; set; }
    }
}
