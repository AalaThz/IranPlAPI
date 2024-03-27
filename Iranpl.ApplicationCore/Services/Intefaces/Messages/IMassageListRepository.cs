﻿using Iranpl.Domain.Models.Message;
using Iranpl.Domain.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Messages
{
    public interface IMassageListRepository
    {
       Task<List<MsgListResult>> GetAllMsgList(string token);
    }
}
