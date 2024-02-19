using AutoMapper;
using Iranpl.ApplicationCore.Security;
using Iranpl.ApplicationCore.Services.Intefaces;
using Iranpl.Domain.Dto.Login;
using Iranpl.Domain.ViewModel.Login;

namespace Iranpl.ApplicationCore.Services.Implementations
{
    //throw new NotImplementedException();
    public class LoginService : ILoginService
    {
        #region Fields
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public LoginService(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Login(LoginViewModel loginViewModel)
        {
            var login = _mapper.Map<LoginDto>(loginViewModel);

            login.UserName = loginViewModel.UserName.CheckText();
            login.Password = loginViewModel.Password.CheckText();

            var values = new Dictionary<string, string>();
            values.Add("grant_type", "password");
            values.Add("username", login.UserName);
            values.Add("password", login.Password);

            using var client = new HttpClient();
            using var req = new HttpRequestMessage(HttpMethod.Post, "https://najm.samanpl.ir/oauth/token") { Content = new FormUrlEncodedContent(values) };
            using var res = await client.SendAsync(req);

            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
