using System.Collections;
using System.Collections.Generic;

namespace PWABlog.ViewModels.ControlAcess
{
    public class ControlAcessRegisterViewModel:ViewModelControlAcess
    {
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
        public IEnumerable RegisterError { get; set; }

        public ControlAcessRegisterViewModel()
        {
            TitlePage = "Register - PWA";
            RegisterError = new List<string>();
        }
    }
}