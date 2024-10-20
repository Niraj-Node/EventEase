using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EventEase.Web.Models;

namespace EventEase.Web.Interfaces
{
    public interface IAccountPageService
    {
        Task<IdentityResult> CreateUser(SignUpViewModel signUpViewModel);

        Task<SignInResult> LoginUser(LoginViewModel loginViewModel);

        Task SignOut();
        string GetEmail(string organiser);
    }
}
