namespace My.Core.Infrastructures.Implementations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(UserOperationLogMetaData))]
    public partial class UserOperationLog
    {
    }

    public partial class UserOperationLogMetaData
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.MUI))]
        [Required]
        public long Id { get; set; }
        [Display(Name = "Body", ResourceType = typeof(Resources.MUI))]
        public string Body { get; set; }
        [Required]
        [Display(Name = "LogTime", ResourceType = typeof(Resources.MUI))]
        [UIHint("UTCLocalTimeDisplay")]
        public System.DateTime LogTime { get; set; }
        [Required]
        [Display(Name = "OpreationCode", ResourceType = typeof(Resources.MUI))]
        public int OpreationCode { get; set; }
        [Display(Name = "URL", ResourceType = typeof(Resources.MUI))]
        [Url]
        public string URL { get; set; }
        [Required]
        [Display(Name = "LogUserName", ResourceType = typeof(Resources.MUI))]
        [UIHint("UserIDMappingDisplay")]
        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual UserOperationCodeDefine UserOperationCodeDefine { get; set; }
    }
}
