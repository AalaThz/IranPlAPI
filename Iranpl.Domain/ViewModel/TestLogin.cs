using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.ViewModel
{
    public class TestLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }  
    
    public class TestLoginDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token{ get; set; }
        public Guid? userId{ get; set; }
    }  
}
