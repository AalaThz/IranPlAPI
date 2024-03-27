using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.ViewModel.Users
{
    public class UserInfoViewModel
    {
        public string? name { get; set; }
        public string family { get; set; }
        public Guid? userId { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Results
    {
        public string userId { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        
    }

    public class Root
    {
        public string statusPhrase { get; set; }
        public int status { get; set; }
        public Results results { get; set; }
    }


}
