using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PWABlog.ViewModels.Admin.admin;

namespace PWABlog.Controllers.admin
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        public AdminController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        [HttpGet]
        [Route("admin")]
        public IActionResult Index()
        {
            var model = new AdminViewModel();
            model.Author = _databaseContext.Autores.ToList().Count;
            model.Category = _databaseContext.Categorias.ToList().Count;
            model.Posts = _databaseContext.Postagens.ToList().Count;
            model.Tags = _databaseContext.Etiquetas.ToList().Count;
            return View(model);
        }
    }
}