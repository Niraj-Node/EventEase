using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EventEase.Core.Entities;

namespace EventEase.Core.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUp user);
        Task<SignInResult> LoginUser(Login user);
        Task SignOut();
        string GetEmail(string organiser);
    }
}
