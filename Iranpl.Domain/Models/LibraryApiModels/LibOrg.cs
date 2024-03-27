using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Iranpl.Domain.Models.Library
{
    public class LibOrg
    {
        [Display(Name = "شناسه سازمانی")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long OrgId { get; set; }

        [Required(ErrorMessage = "واحد مورد نظر را انتخاب نمایید")]
        [Display(Name = "نام واحد")]
        public string OrgName { get; set; }

        [Required(ErrorMessage = "واحد پدر را انتخاب کنید")]
        [Display(Name = "شناسه والد")]
        public long ParentId { get; set; }

        //[NotMapped]
        [Display(Name = "عنوان والد")]
        public string ParentName { get; set; }


        [Required(ErrorMessage = "نوع واحد را انتخاب نمایید")]
        [Display(Name = "شناسه نوع واحد")]
        public int PropertyID { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "عرض جغرافیایی")]
        public string Lat { get; set; }
        [Display(Name = "طول جغرافیایی")]
        public string Lon { get; set; }

        [Display(Name = "تلفن1")]
        public string Tel { get; set; }
        [Display(Name = "تلفن2")]
        public string Tel2 { get; set; }
        [Display(Name = "تلفن3")]
        public string Tel3 { get; set; }

        [Display(Name = "نمابر")]
        public string Fax { get; set; }
        [Display(Name = "پست الکترونیک")]
        public string Mail { get; set; }
        [Display(Name = "وب سایت")]
        public string WebSite { get; set; }
        //[Display(Name = "توضیحات")] 
        // بنابه درخواست امور کتابخانه ها نام فیلد تغییر کرده است
        [Display(Name = "کد بین سیستمی کتابخانه")]
        public string DSCP { get; set; }

        //[Display(Name = "نوع واحد")]
        //public virtual LibLibraryProperty LibLibraryProperty { get; set; }



        //public virtual ICollection<BrwBorrowHistory> BrwBorrowHistory { get; set; }
        //public virtual ICollection<BrwCurrentBorrows> BrwCurrentBorrows { get; set; }
        //public virtual ICollection<BrwCurrentTempDelivery> BrwCurrentTempDelivery { get; set; }
        //public virtual ICollection<BrwReserveDocument> BrwReserveDocument { get; set; }
        //public virtual ICollection<BrwTempDeliveryHistory> BrwTempDeliveryHistory { get; set; }
        //public virtual ICollection<LibStorageInfo> LibStorageInfo { get; set; }
        //public virtual ICollection<PayHistory> PayHistory { get; set; }
        //[Display(Name = "کد کتابخانه")]
        [Display(Name = "نام کتابخانه بین سیستمی")]
        public string BarcodeLetter { get; set; }

        [Display(Name = "فیش پرینتر دارد")]
        public bool HasFishPrinter { get; set; }


        [Display(Name = "تعداد چاپ رسید")]
        public int DefaultReceiptNumber { get; set; }

        [Display(Name = "ارسال پیام کوتاه")]
        public bool SendSms { get; set; }

        [Display(Name = "ارسال ایمیل")]
        public bool SendEmail { get; set; }

        [Display(Name = "آغاز ساعت کاری")]
        public string OpenTime { get; set; }

        [Display(Name = "پایان ساعت کاری")]
        public string CloseTime { get; set; }

        [Display(Name = "کد پستی")]
        public string PostalCode { get; set; }

        [Display(Name = "پیش شماره")]
        [Required(ErrorMessage = "لطفا پیش شماره استان خود را وارد کنید")]
        public string PishShomare { get; set; }

        [Display(Name = "فعال بودن")]
        public bool Active_Lib { get; set; }

        [Display(Name = "مقدار تمدید کارت pvc")]
        public int ValuePvc { get; set; }

        [Display(Name = "کارت pvc")]
        public bool IsPvc { get; set; }
        public bool? HaveElectronicPay { get; set; }


        [NotMapped]
        public int? oldOrgType { set; get; }

        [NotMapped]
        //جهت شناسایی درخت 
        public int type { set; get; }
        //[NotMapped]
        //public List<GetAllChangeOrgIds> orgids { get; set; }


        [NotMapped]
        [IgnoreDataMember]

        public string button_add_pos { get; set; }


        [NotMapped]
        [IgnoreDataMember]

        public string button { get; set; }

        [NotMapped]
        [IgnoreDataMember]

        public string button_Delete { get; set; }

    }
}
