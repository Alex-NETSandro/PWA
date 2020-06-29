using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PWABlog.ViewModels.Admin.admin;

namespace PWABlog.Controllers.admin
{
    [Authorize]
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("admin")]
        public IActionResult Index()
        {
            var model = new AdminViewModel();
            return View(model);
        }
    }
}