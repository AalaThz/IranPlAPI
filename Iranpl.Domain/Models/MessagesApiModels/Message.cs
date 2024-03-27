using Iranpl.Domain.Models.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.Message
{
    public class Message
    {
        [Key]
        public long Id { get; set; }

        public long OrgId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? SenderUserID { get; set; }

        [RequiredLocalized]
        [Display(Name = "عنوان پیام")]
        public string MessageTitle { get; set; }

        [Display(Name = "خلاصه پیام")]
        public string MessageSummary { get; set; }

        [RequiredLocalized]
        [DataType(DataType.MultilineText)]
        [Display(Name = "متن پیام")]
        public string MessageBody { get; set; }

        [Display(Name = "نشانه خوانده شده")]
        public bool ReadFlag { get; set; }

        [Display(Name = "تاریخ دریافت پیام")]
        public System.DateTime? ReceiveDate { get; set; }

        [Display(Name = "تاریخ خواندن پیام")]
        public System.DateTime? ReadDate { get; set; }

        [NotMapped]
        public Guid? RoleId { get; set; }
        public virtual LibOrg LibOrg { get; set; }
        //public virtual Users Users { get; set; }

        [Display(Name = "فایل آپلود")]
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
    }
}
