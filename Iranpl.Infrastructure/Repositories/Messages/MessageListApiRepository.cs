using AutoMapper;
using Iranpl.Domain.Models.Message;
using Iranpl.Infrastructure.Data.IranplContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iranpl.Domain.Models.Message;
using Iranpl.Infrastructure.Data.IranplContext;
using Iranpl.ApplicationCore.Services.Intefaces.Messages;
using Iranpl.Domain.Models.Library;
using Iranpl.Domain.ViewModel.Users;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Iranpl.Infrastructure.Repositories.Message
{
    public class MessageListApiRepository : IMassageListRepository
    {
        private readonly SearchListsApiContext _apiContext;
        public MessageListApiRepository(SearchListsApiContext apiContext)
        {
            _apiContext = apiContext;

        }



        public async Task<List<MsgListResult>> GetAllMsgList(string token)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var req = new HttpRequestMessage
                (HttpMethod.Get, "https://najm.samanpl.ir/api/userStuff/MsgList");

            using var res = await client.SendAsync(req);

            var root = new RootMsgh();

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<RootMsgh>(jsonString);
            }
            return root.MsgListResults.ToList();


            //List<MessageContainer> lstMessageCintainer = new List<MessageContainer>();
            //{
            //    var list = _apiContext.Messages.Where(m => m.UserId == UserId && m.IsDeleted == false)
            //        .OrderByDescending(o => o.Id).Take(200).ToList();
            //    foreach (var messages in list)
            //    {
            //        var model = new MessageContainer
            //        {
            //            Id = messages.Id,
            //            MessageTitle = messages.MessageTitle,
            //            MessageSummary = messages.MessageSummary,
            //            MessageBody = messages.MessageBody,
            //            ReadFlag = messages.ReadFlag,
            //            ReceiveDate = messages.ReceiveDate,
            //            ReadDate = messages.ReadDate,
            //        };
            //        lstMessageCintainer.Add(model);
            //    }
            //}
            //return lstMessageCintainer;
        }

       


    }
}
