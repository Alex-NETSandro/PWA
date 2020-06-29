using System;
using System.Collections.Generic;
using System.Security.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PWABlog.Models.Blog.Categoria;
using PWABlog.RequestModels;
using PWABlog.ViewModels.Admin.Categoria;

namespace PWABlog.Controllers.admin
{
    public class AdminCategoriaController : Controller
    {
        /* Instacia as ações em que as actions realizarão no banco */
        
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminCategoriaController(CategoriaOrmService categoriaOrmService)
        {
            _categoriaOrmService = categoriaOrmService;
        }

        /* Página inicial da categoria com suas rotas*/
        
        [Route("admin/categoria/index")]
        [Route("admin/categoria")]
        public IActionResult Index(string message,string tipo)
        {
            ViewBag.Title = "Index";
            var model = new CategoriaIndexViewModel();
            model.Message = message;
            model.Tipo = tipo;
            var categorias = _categoriaOrmService.ObterCategorias();
            foreach (var categoria in categorias)
            {
                var categoriaIndex = new CategoriaIndex();
                categoriaIndex.CategoriaId = categoria.Id;
                categoriaIndex.Nome = categoria.Nome;
                model.Categorias.Add(categoriaIndex);
            }
            return View(model);
        }
        
        /*Retorn a view Create para colocar os dados*/
        
        [HttpGet]
        [Route("admin/categoria/create")]
        public IActionResult Create()
        {
            return View();
        }
        
        /* Realiza a ação de insert no banco */
        
        [HttpPost]
        [Route("admin/categoria/create")]
        public IActionResult Create(AdminCategoriaCriarRequestModel request)
        {
            var nome = request.Nome;
            var model = new CategoriaIndexViewModel();
            try
            {
                _categoriaOrmService.AddCategoria(nome);
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
        
        /* Edita os dados , nome, da categoria*/
        
        [HttpGet]
        [Route("admin/categoria/edit")]
        public IActionResult Edit(int id)
        {
            var categoria = _categoriaOrmService.ObterCategoriaPorId(id);
            var model = new CategoriaEditViewModel();
            model.Etiquetas = categoria.Etiquetas;
            model.Postagens = categoria.Postagens;
            model.Id = categoria.Id;
            model.Nome = categoria.Nome;
            return View(model);
        }
        
        /* Realiza o update dos dados*/
        
        [HttpPost]
        [Route("admin/categoria/edit")]
        public IActionResult Update(AdminCategoriaUpdateRequestModel request)
        {
            var nome = request.Nome;
            var id = request.Id;
            var model = new CategoriaIndexViewModel();
            try
            {
                var categoria = new CategoriaEntity{Id=id,Nome = nome};
                _categoriaOrmService.UpdateCategoria(categoria);
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
        
        /* Realiza a removção dos dados no banco e na aplicação*/
        
        [Route("admin/categoria/remove/{id}")]
        public IActionResult Remove(AdminCategoriaDeletarRequestModel request)
        {
            var id = request.Id;
            var model = new CategoriaIndexViewModel();
            try
            {
                _categoriaOrmService.removeCategoria(id);
                model.Message = "Deletado com sucesso!!";
                model.Tipo = "Deletar";
            }catch(Exception e)
            {
                TempData["erro-msg"] = e.Message;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index",new{message = model.Message,tipo = model.Tipo});
        }
        
        /* Visualização de todos os detalhes */
        
        [Route("admin/categoria/view/{id?}")]
        public IActionResult Details(int id)
        {
            var model = new CategoriaDetailsViewModel();
            var categoria = _categoriaOrmService.ObterCategoriaPorId(id);
            model.Id = categoria.Id;
            model.Nome = categoria.Nome;
            return View(model);
        }
    }
}