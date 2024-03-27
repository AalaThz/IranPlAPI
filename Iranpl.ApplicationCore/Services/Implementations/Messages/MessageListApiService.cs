using Iranpl.ApplicationCore.Services.Intefaces.Messages;
using Iranpl.Domain.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Implementations.Messages
{
    public class MessageListApiService
    {
        private readonly IMassageListRepository _massageRepository;

        public MessageListApiService(IMassageListRepository massageListRepository)
        {
            _massageRepository = massageListRepository;
        }

    }
}
