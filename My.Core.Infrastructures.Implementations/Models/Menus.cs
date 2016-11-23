//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Menus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menus()
        {
            this.ChildMenus = new HashSet<Menus>();
            this.ApplicationRole = new HashSet<ApplicationRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
        public bool IsExternalLinks { get; set; }
        public string ExternalURL { get; set; }
        public bool Void { get; set; }
        public Nullable<int> ParentMenuId { get; set; }
        public int CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> LastUpdateUserId { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public Nullable<int> System_ControllerActionsId { get; set; }
        public bool AllowAnonymous { get; set; }
        public int Order { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menus> ChildMenus { get; set; }
        public virtual Menus ParentMenu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationRole> ApplicationRole { get; set; }
        public virtual System_ControllerActions System_ControllerActions { get; set; }
    }
}
