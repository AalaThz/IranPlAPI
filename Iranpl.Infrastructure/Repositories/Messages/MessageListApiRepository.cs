using AutoMapper;
using Iranpl.Infrastructure.Data.IranplContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iranpl.Infrastructure.Data.IranplContext;
using Iranpl.ApplicationCore.Services.Intefaces.Messages;
using Iranpl.Domain.Models.Library;
using Iranpl.Domain.ViewModel.Users;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Iranpl.Domain.ViewModel.Users;

namespace Iranpl.Infrastructure.Repositories.Message
{
    public class MessageListApiRepository : IMassageListRepository
    {
        private readonly SearchListsApiContext _apiContext;
        public MessageListApiRepository(SearchListsApiContext apiContext)
        {
            _apiContext = apiContext;

        }

        public async Task<List<MessageContainer>> GetAllMsgList(string token)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var req = new HttpRequestMessage
                (HttpMethod.Get, "https://najm.samanpl.ir/api/userStuff/MsgList");

            using var res = await client.SendAsync(req);

            var root = new RootMessageListResult();

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<RootMessageListResult>(jsonString);
            }
            return root.MsgListResults.ToList();
        }

    }
}
