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
    
    public partial class ApplicationRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationRole()
        {
            this.ApplicationUser = new HashSet<ApplicationUser>();
            this.Menus = new HashSet<Menus>();
            this.System_ControllerActions = new HashSet<System_ControllerActions>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Void { get; set; }
        public int CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int LastUpdateUserId { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menus> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<System_ControllerActions> System_ControllerActions { get; set; }
    }
}
