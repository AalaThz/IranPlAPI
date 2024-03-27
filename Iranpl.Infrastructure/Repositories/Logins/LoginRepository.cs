using Iranpl.ApplicationCore.Security;
using Iranpl.ApplicationCore.Services.DTO.Users;
using Iranpl.ApplicationCore.Services.Intefaces.Logins;
using Iranpl.Domain.ViewModel.Users;
using Iranpl.Infrastructure.Data.IranplContext;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.Infrastructure.Repositories.Logins
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SearchListsApiContext _apiContext;

        public LoginRepository(SearchListsApiContext apiContext)
        {
            _apiContext = apiContext;
        }
        

        public async Task<string> Login(string userName, string password)
        {
            var values = new Dictionary<string, string>();
            values.Add("grant_type", "password");
            values.Add("username", userName.Trim());
            values.Add("password", password);

            using var client = new HttpClient();
            using var req = new HttpRequestMessage
                (HttpMethod.Post, "https://najm.samanpl.ir/oauth/token")
            { Content = new FormUrlEncodedContent(values) };

            using var res = await client.SendAsync(req);

            var token = "";
            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TokenViewModel>(jsonString);
                token = response.access_token;
            }
            return token;
        }

        public async Task<Results> GetUserInfo(string token)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            using var req = new HttpRequestMessage
                (HttpMethod.Get, "https://najm.samanpl.ir/api/userStuff/IranplUserProfile");

            using var res = await client.SendAsync(req);

            var root = new Root();

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                root = JsonConvert.DeserializeObject<Root>(jsonString);
            }
            return root.results;
        }
    }
}
