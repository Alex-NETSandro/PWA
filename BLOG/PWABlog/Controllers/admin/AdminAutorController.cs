using System;
using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.RequestModels.autor;
using PWABlog.ViewModels.Admin.autor;
// ReSharper disable All

namespace PWABlog.Controllers.admin
{
    public class AdminAutorController : Controller
    {
        private readonly AutorOrmService _autorOrmService;

        public AdminAutorController(AutorOrmService autorOrmService)
        {
            _autorOrmService = autorOrmService;
        }
        
       [Route("admin/autor/index")]
       [Route("admin/autor")]
        public IActionResult Index()
        {
            var model = new AutorIndexViewModel();
            var autores = _autorOrmService.ObterAutores();

            foreach (var autor in autores)
            {
                var author = new AutorIndex();
                author.Id = autor.Id;
                author.Nome = autor.Nome;
                model.Autores.Add(author);
            }
            
            return View(model);
        }

        [HttpGet]
        [Route("admin/autor/create")]
        public IActionResult Create()
        {
            var model = new AutorCreateViewModel();
            model.Title = "Adicionar Autor";
            return View(model);
        }

        [HttpPost]
        [Route("admin/autor/create/{id?}")]
        public IActionResult Create(AdminAutorCriarRequestModel request)
        {
            var nome = request.Nome;
            var model = new AutorIndexViewModel();
            try
            {
                _autorOrmService.AddAutor(nome);
                model.Message = "Criado com sucesso!!";
                model.Tipo = "Criar";
            }
            catch(Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Create");
            }
            return RedirectToAction("Index",new{message = model.Message,tipo = model.Tipo});
           
        }

        [Route("admin/autor/edit/{id?}")]
        public IActionResult Edit(int id)
        {
            var author = _autorOrmService.ObterAutorPorId(id);
            var model = new AutorEditViewModel();
            model.Id = author.Id;
            model.Nome = author.Nome;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(AdminAutorUpdateRequestModel request)
        {
            var nome = request.Nome;
            var id = request.Id;
            var model = new AutorIndexViewModel();
            try
            {
                var author = new AutorEntity{Id=id,Nome = nome};
                _autorOrmService.UpdateAutor(author);
                model.Message = "Atualizado com sucesso!!";
                model.Tipo = "Update";
            }
            catch(Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Update");
            }
            return RedirectToAction("Index",new{message = model.Message,tipo = model.Tipo});
        }
        
        [Route("admin/autor/remove/{id?}")]
        public IActionResult Remove(AdminAutorDeleteRequestModel request)
        {
            var id = request.Id;
            var model = new AutorIndexViewModel();
            try
            {
                _autorOrmService.RemoveAutor(id);
                model.Message = "Deletado com sucesso!!";
                model.Tipo = "Deletar";
            }catch(Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index",new{message = model.Message,tipo = model.Tipo});
        }

        [Route("admin/autor/view/{id?}")]
        public IActionResult Details(int id)
        {
            var model = new AutorDetailsViewModel();
            var categoria = _autorOrmService.ObterAutorPorId(id);
            model.Id = categoria.Id;
            model.Nome = categoria.Nome;
            return View(model);
        }
    }
}