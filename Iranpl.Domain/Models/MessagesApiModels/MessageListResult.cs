using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Domain.Models.Message
{
    public class MessageListResult
    {
        public string StatusPhrase { get; set; }
        public int Status { get; set; }
        public List<MessageContainer> MessageContainers { get; set; }
    }
}
