using Iranpl.ApplicationCore.Services.DTO.Users;
using Iranpl.Domain.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iranpl.ApplicationCore.Services.Intefaces.Logins
{
    public interface ILoginRepository
    {
        Task<string> Login(string username, string password);
        Task<Results> GetUserInfo(string token);
    }
}
