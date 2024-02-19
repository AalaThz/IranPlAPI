using Iranpl.Domain.ViewModel.Login;

namespace Iranpl.ApplicationCore.Services.Intefaces
{
    public interface ILoginService
    {
        Task<bool> Login(LoginViewModel login);
    }
}
