using Iranpl.Domain.ViewModel.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories.Users
{
    public class GetUserProfileRepository
    {
        public async Task<UserInfoViewModel> GetUserInfo(string token)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var req = new HttpRequestMessage
                (HttpMethod.Get, "https://najm.samanpl.ir/api/userStuff/IranplUserProfile");

            using var res = await client.SendAsync(req);

            var root = new UserInfoViewModel();

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<UserInfoViewModel>(jsonString);
            }
            return root;
        }
    }
}
