using Microsoft.AspNetCore.Identity;

namespace PWABlog.Models.AcessControl
{
    public class User:IdentityUser<int>
    {
        public string Apelido { get; set; }
    }
}