using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.Library
{
    public class Users
    {
        [Key]
        [Display(Name = "شناسه کاربری")]
        public Guid UserId { get; set; }


        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Display(Name = "جلوگیری از ارائه خدمات")]
        public bool IsAnonymous { get; set; }

        [Display(Name = "تاریخ آخرین فعالیت")]
        public System.DateTime LastActivityDate { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "تاریخ تولد")]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Display(Name = "شماره شناسنامه")]
        public string BirthCertificationNumber { get; set; }

        [Display(Name = "کد پرسنلی")]
        public string EmployeeNumber { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تلفن")]
        public string PhoneNumber { get; set; }

        [Display(Name = "مدرک")]
        public Nullable<int> DegreeCode { get; set; }

        [MaxLength(249, ErrorMessage = "طول آدرس حداکثر 249کارکتر می باشد.")]
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "معرف")]
        public string Confirmer { get; set; }

        [Display(Name = "تلفن معرف")]
        public string ConfirmerTel { get; set; }
        public string Mobileconfirmer { get; set; }

        public Guid? UseridConfirmer { get; set; }

        public bool? FlagConfirmer { get; set; }

        [Display(Name = "کد ملی/کد خانوار")]
        public string NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public int Sex { get; set; }

        [Display(Name = "نام پدر")]
        public string FatherName { get; set; }

        [Display(Name = "تلفن همراه")]
        [StringLength(11, ErrorMessage = "شماره را به صورت 09120000000 وارد کنید.", MinimumLength = 11)]
        public string MobileNumber { get; set; }

        [Display(Name = "مدرک")]
        public string WorkHouse { get; set; }

        [Display(Name = "شماره حساب")]
        public string BankReceiptNumber { get; set; }
        [Display(Name = "نوع کارت")]
        public Nullable<int> PrintCardCount { get; set; }
        [MaxLength(249, ErrorMessage = "طول آدرس معرف حداکثر 249کارکتر می باشد.")]
        [Display(Name = "آدرس معرف")]
        public string ConfirmerAddress { get; set; }

        [Display(Name = "غیر ایرانی")]
        public bool? NonIranian { get; set; }

        [Display(Name = "ملیت")]
        public int? CountryId { get; set; }

        [Display(Name = "RFID Code")]
        public string RFIDCode { get; set; }

        [Display(Name = "آدرس تصویر")]
        public string ImageAddress { get; set; }
        [Display(Name = "آدرس ملحقات عضویت ها")]
        public string MTAttachments_Address { get; set; }

        [Display(Name = "کد کاربری")]
        public Nullable<long> UserCode { get; set; }

        [Display(Name = "کد واحد")]
        //public Nullable<long> OrgId { get; set; }
        public long OrgId { get; set; }

        [Display(Name = "شناسه نوع عضویت")]
        public Nullable<int> MembershipTypeId { get; set; }

        [Display(Name = "شناسه شغل")]
        public Nullable<int> JobCode { get; set; }

        [Display(Name = "وضعیت جسمانی")]
        public int? PhysicalStatus { get; set; }
        /*
        [Display(Name = "سامانه")]
        public virtual Applications Applications { get; set; }
        */


        //[Display(Name = "شغل")]
        //public virtual UserJob UserJob { get; set; }

        //[Display(Name = "نوع عضویت")]
        //public virtual UserMembershipType UserMembershipType { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        [UIHint("DateTemplate")]
        public System.DateTime? RegisterDate { get; set; }

        [Display(Name = "کاربر ایجاد کننده")]
        public Guid? CreatorUserId { get; set; }


        [Display(Name = "وضعیت تاهل")]
        public Nullable<int> MaritalStatus { get; set; }

        [Display(Name = "رشته تحصیلی")]
        public Nullable<int> FieldStudy { get; set; }

        [Display(Name = "انتخاب")]
        [NotMapped]
        public bool select { get; set; }

        [NotMapped]
        [Display(Name = "امکان ورود به سامانه")]
        public bool Approved { get; set; }

        [NotMapped]
        [Display(Name = "غیرفعال به دلیل کلمه عبور اشتباه")]
        public bool LockedOut { get; set; }

        [NotMapped]
        [Display(Name = "اجازه امانت")]
        public bool AllowBorrow { get; set; }

        //[NotMapped]
        //[Display(Name = "پست الکترونیک")]
        //public override string Email { get; set; }

        [NotMapped]
        [Display(Name = "تعداد امانات اضافی")]
        public int AddedDocForBorrow { get; set; }

        [NotMapped]
        [Display(Name = "نوع عضویت")]
        public int LibraryMembershipType { get; set; }

        [NotMapped]
        public int UserCount { get; set; }
        [NotMapped]
        public string BirhtDate { get; set; }

        [NotMapped]
        public bool isValid { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool? IsMembershipValid { get; set; }

        //public virtual ICollection<BrwBorrowHistory> BrwBorrowHistory { get; set; }
        //public virtual ICollection<BrwCurrentBorrows> BrwCurrentBorrows { get; set; }
        //public virtual ICollection<BrwCurrentTempDelivery> BrwCurrentTempDelivery { get; set; }
        //public virtual ICollection<BrwReserveDocument> BrwReserveDocument { get; set; }
        //public virtual ICollection<BrwTempDeliveryHistory> BrwTempDeliveryHistory { get; set; }
        //public virtual ICollection<PayHistory> PayHistory { get; set; }

        [Display(Name = "علاقه مندی شماره یک")]
        public string Favorite1 { get; set; }

        [Display(Name = "علاقه مندی شماره دو")]
        public string Favorite2 { get; set; }

        [Display(Name = "علاقه مندی شماره سه")]
        public string Favorite3 { get; set; }

        [Display(Name = "تعداد رمز عبور اشتباه")]
        public int FailedPasswordAttemptCount { get; set; }


        [Display(Name = "قفل شده")]
        public bool IsLockedOut { get; set; }

        [Display(Name = "تایید ")]
        public bool IsApproved { get; set; }

        [Display(Name = "نوع عضویت")]
        public int? MemberType { get; set; }
        [Display(Name = "تایید شماره موبایل")]

        public bool IsMobileVerified { get; set; }
        public int? UserRegisterNumber { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
