using Microsoft.AspNetCore.Identity;
using ToDoPlatfor.ViewModels;
using ToDoPlatform.ViewModels;

namespace ToDoPlatform.Services;
public interface IUserService
{
    Task<UserVM> GetloggedUser();
    Task<SignInResult> Login(LoginVM login);
    Task Logout();
}
