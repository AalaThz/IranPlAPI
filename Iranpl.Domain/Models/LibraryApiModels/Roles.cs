using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.Library
{
    public class Roles
    {
        [Display(Name = "شناسه گروه")]
        [Key]
        public System.Guid RoleId { get; set; }

        [Display(Name = "نام گروه")]
        public string RoleName { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "اولویت")]
        public Nullable<int> Priority { get; set; }

        [Display(Name = "تائید شده")]
        public bool IsVerified { get; set; }

        [Display(Name = "نشان داده شود")]
        public bool IsVisible { get; set; }


        [Display(Name = "دسترسی")]
        [NotMapped]
        public bool HaveRole { get; set; }

        [Display(Name = "وضعیت")]
        [NotMapped]
        public bool Enable { get; set; }

        [Display(Name = "واحد")]
        [NotMapped]
        public long OrgId { get; set; }

        [Display(Name = "نام واحد")]
        [NotMapped]
        public string OrgName { get; set; }

        [NotMapped]
        [Display(Name = "دسترسی")]
        public bool HaveAccess { get; set; }



        //public virtual ICollection<UserRoleActions> UserRoleActions { get; set; }
    }
}
