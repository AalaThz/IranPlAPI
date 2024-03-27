using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.ViewModel.Users
{
    public class MsgListResult
    {
        public int id { get; set; }
        public string MessageTitle { get; set; }
        public string MessageSummary { get; set; }
        public string MessageBody { get; set; }
        public bool ReadFlag { get; set; }
        public DateTime ReceiveDate { get; set; }
        public DateTime? ReadDate { get; set; }
    }

    public class RootMsgh
    {
        public string StatusPhrase { get; set; }
        public int Status { get; set; }
        public List<MsgListResult> MsgListResults { get; set; }
    }
}
