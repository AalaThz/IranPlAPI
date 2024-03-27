using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.Message
{
    public class RequiredLocalizedAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value != null; // اعتبارسنجی: فیلد نباید خالی باشد
        }

        public override string FormatErrorMessage(string name)
        {
            //return base.FormatErrorMessage(name);
            return $"{name} is  required."; // پیام خطا
        }
    }
}
