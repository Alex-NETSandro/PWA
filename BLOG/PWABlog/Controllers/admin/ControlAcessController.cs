using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PWABlog.Models.AcessControl;
using PWABlog.ViewModels.ControlAcess;

namespace PWABlog.Controllers.admin
{
    public class ControlAcessController : Controller
    {
        private readonly ControlAcessService _controlAcessService;

        public ControlAcessController(ControlAcessService controlAcessService)
        {
            _controlAcessService = controlAcessService;
        }
        [Route("")]
        [Route("login")]
        public IActionResult Login()
        {
            var model = new ControlAcessLoginViewModel();
            model.RegisterMenssage = (string) TempData["msg-register"];
            model.LoginMenssage = (string) TempData["msg-login"];
            return View(model);
        }

        [HttpPost]
        [Route("/login")]
        public async Task<RedirectResult> Login(ControlAcessLoginRequestModel request)
        {
            var user = request.Email;
            var password = request.Password;
            if (user == null)
            {
                TempData["msg-login"] = "Please enter with username";
                RedirectToAction("Login");
            }

            if (password == null)
            {
                TempData["msg-login"] = "Please enter with password";
                RedirectToAction("Login");
            }

            try
            {
                await _controlAcessService.AuthenticationUser(user, password);
                return Redirect("/Home");
            }
            catch (Exception e)
            {
                TempData["msg-login"] = e.Message;
                return Redirect("Login");
            }
        }

        public IActionResult Logout()
        {
            _controlAcessService.LogoutUser();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Register()
        {
            var model = new ControlAcessRegisterViewModel();
            //model.RegisterError = (string) TempData["register-error"];
            model.Error = (string) TempData["msg-error"];
            return View(model);
        }

        [HttpPost]
        [Route("/register/add")]
        public async Task<RedirectToActionResult> RegisterPost(ControlAcessRegisterRequestModel request)
        {
            var email = request.Email;
            var password = request.Password;
            var token = request.Token;
            var nickName = request.NickName;

            if (email == null)
            {
                TempData["msg-error"] = "Please, enter with email";
                return RedirectToAction("Register");
            }
            if (password == null)
            {
                TempData["msg-error"] = "Please, enter with password";
                return RedirectToAction("Register");
            }
            if (nickName == null)
            {
                TempData["msg-error"] = "Please, enter with nickname";
                return RedirectToAction("Register");
            }
            if (!token.Equals("BLOG-PWA-2020"))
            {
                TempData["msg-error"] = "Token disabled";
                return RedirectToAction("Register");
                
            }

            try
            {
                await _controlAcessService.RegisterUser(email, password, nickName);
                TempData["msg-register"] = "Registered user";
                return RedirectToAction("Login");
            }
            catch (RegisterUserExeception e)
            {
                var ListError = new List<string>();

                foreach (var error in e.Error)
                {
                    ListError.Add(error.Description);
                }

                TempData["register-error"] = ListError;
                return RedirectToAction("Register");
            }

            return null;
        }
    }
}