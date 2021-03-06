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
    
    public partial class System_ControllerActions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public System_ControllerActions()
        {
            this.Menus = new HashSet<Menus>();
            this.ApplicationRole = new HashSet<ApplicationRole>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ControllerId { get; set; }
        public bool Void { get; set; }
        public int CreateUserId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<int> LastUpdateUserId { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public bool AllowAnonymous { get; set; }
    
        public virtual System_Controllers System_Controllers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menus> Menus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationRole> ApplicationRole { get; set; }
    }
}
