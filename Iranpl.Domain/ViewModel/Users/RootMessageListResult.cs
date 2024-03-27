using Iranpl.Domain.Models.Message;

namespace Iranpl.Domain.ViewModel.Users
{
    public class RootMessageListResult
    {
        public string StatusPhrase { get; set; }
        public int Status { get; set; }
        public List<MessageContainer> MsgListResults { get; set; }
    }
}
