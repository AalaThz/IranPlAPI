using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.ViewModel.Users
{
    public class MessageContainer
    {
        public long Id { get; set; }

        [Display(Name = "عنوان پیام")]
        public string MessageTitle { get; set; }

        [Display(Name = "خلاصه پیام")]
        public string MessageSummary { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "متن پیام")]
        public string MessageBody { get; set; }

        [Display(Name = "نشانه خوانده شده")]
        public bool ReadFlag { get; set; }

        [Display(Name = "تاریخ دریافت پیام")]
        public DateTime? ReceiveDate { get; set; }

        [Display(Name = "تاریخ خواندن پیام")]
        public DateTime? ReadDate { get; set; }

        //public int id { get; set; }
        //public string MessageTitle { get; set; }
        //public string MessageSummary { get; set; }
        //public string MessageBody { get; set; }
        //public bool ReadFlag { get; set; }
        //public DateTime ReceiveDate { get; set; }
        //public DateTime? ReadDate { get; set; }
    }
}
