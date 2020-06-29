using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PWABlog.Models.AcessControl
{
    public class ControlAcessService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ControlAcessService(UserManager<User>userManager,SignInManager<User>signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task AuthenticationUser(string user, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(user, password,false,false);
            if (!result.Succeeded)
            {
                throw new Exception("User or passaword disabled");
            }
        }

        public async Task RegisterUser(string email, string password, string nickName)
        {
            var user = new User
            {
                UserName = email,
                Email = email,
                Apelido = nickName
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new RegisterUserExeception(result.Errors);
            }
        }

        public void LogoutUser()
        {
            _signInManager.SignOutAsync();
        }
    }
}