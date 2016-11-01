namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(ApplicationGroupTreeMetaData))]
    public partial class ApplicationGroupTree
    {
    }
    
    public partial class ApplicationGroupTreeMetaData
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.MUI))]
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "ParentId", ResourceType = typeof(Resources.MUI))]
        public int ParentId { get; set; }
        [Required]
        [Display(Name = "ChildId", ResourceType = typeof(Resources.MUI))]
        public int ChildId { get; set; }
        [Required]
        [Display(Name = "Level", ResourceType = typeof(Resources.MUI))]
        public int Level { get; set; }
        [Required]
        [UIHint("VoidDisplay")]
        [Display(Name = "Void", ResourceType = typeof(Resources.MUI))]
        public bool Void { get; set; }
    
        public virtual ApplicationGroup ApplicationGroup { get; set; }
        public virtual ApplicationGroup ApplicationGroup1 { get; set; }
        public virtual ApplicationGroup ApplicationGroup2 { get; set; }
    }
}
