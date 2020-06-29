using System.Collections.Generic;

namespace PWABlog.ViewModels.ControlAcess
{
    public class ControlAcessLoginViewModel:ViewModelControlAcess
    {
        public string RegisterMenssage { get; set; }
        public string LoginMenssage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ControlAcessLoginViewModel()
        {
            TitlePage = "Login - Blog PWA";
        }
    }
}