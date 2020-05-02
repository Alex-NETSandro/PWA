using System;
using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.RequestModels.etiqueta;
using PWABlog.ViewModels.Admin.Categoria;
using PWABlog.ViewModels.Admin.etiqueta;

namespace PWABlog.Controllers.admin
{
    public class AdminEtiquetaController : Controller
    {
        private readonly EtiquetaOrmService _etiquetaOrmService;
        private readonly DatabaseContext _databaseContext;
        private readonly EtiquetaOrmService _categoriaOrmService;

        public AdminEtiquetaController(EtiquetaOrmService etiquetaOrmService,DatabaseContext databaseContext)
        {
            _etiquetaOrmService = etiquetaOrmService;
            _databaseContext = databaseContext;
        }

        /* Página inicial da etiqueta com suas rotas*/
        
        [Route("admin/etiqueta/index")]
        [Route("admin/etiqueta")]
        public IActionResult Index(string message,string tipo)
        {
            ViewBag.Title = "Lista de etiquetas";
            var model = new EtiquetaIndexViewModel();
            model.Message = message;
            model.Tipo = tipo;
            var etiquetas = _etiquetaOrmService.ObterEtiqueta();
            foreach (var tag in etiquetas)
            {
               var etiqueta = new ViewModels.Admin.etiqueta.EtiquetaIndex();
               etiqueta.Id = tag.Id;
               etiqueta.Nome = tag.Nome;
               etiqueta.Categoria = tag.Categoria;
               model.Etiquetas.Add(etiqueta);
            }
            return View(model);
        }
        
        /*Retorn a view Create para colocar os dados*/
        
        [HttpGet]
        [Route("admin/etiqueta/create")]
        public IActionResult Create()
        {
            ViewBag.title = "Adicionar Tag";
            var modal = new EtiquetaCreateViewModel();
            var _categoriaOrmService = new CategoriaOrmService(_databaseContext);
            var categorias = _categoriaOrmService.ObterCategorias();
            
            foreach (var cat in categorias)
            {
                var category = new EtiquetaCategoriaCreate();
                category.Id = cat.Id;
                category.Nome = cat.Nome;
                modal.Categoria.Add(category);
            }
            return View(modal);
        }
        
        /* Realiza a ação de insert no banco */
        
        [HttpPost]
        [Route("admin/etiqueta/create")]
        public IActionResult Create(AdminEtiquetaCriarRequestModel request)
        {
            var nome = request.Nome;
            var categoriaId = request.ListCategorias;
            var _categoriaOrmService = new CategoriaOrmService(_databaseContext);
            var categoria = _categoriaOrmService.ObterCategoriaPorId(categoriaId);
            var model = new EtiquetaIndexViewModel();
            try
            {
                _etiquetaOrmService.AddEtiqueta(nome,categoria);
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
        
        /* Edita os dados , nome, da etiqueta */
        
        [HttpGet]
        [Route("admin/etiqueta/edit")]
        public IActionResult Edit(int id)
        {
            ViewBag.title = "Update tag";
            var etiqueta = _etiquetaOrmService.ObterEtiquetaPorId(id);
            var model = new EtiquetaEditViewModel();
            model.Id = etiqueta.Id;
            model.Nome = etiqueta.Nome;
            return View(model);
        }
        
        /* Realiza o update dos dados*/
        
        [HttpPost]
        [Route("admin/etiqueta/edit")]
        public IActionResult Update(AdminEtiquetaUpdateRequestModel request)
        {
            var nome = request.Nome;
            var id = request.Id;
            var model = new EtiquetaIndexViewModel();
            try
            {
                var tag = new EtiquetaEntity{Id=id,Nome = nome};
                _etiquetaOrmService.UpdateEtiqueta(tag);
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
        
        /* Realiza a removção dos dados no banco e na aplicação */
        
        [Route("admin/etiqueta/remove/{id}")]
        public IActionResult Remove(AdminEtiquetaDeleteRequestModel request)
        {
            var id = request.Id;
            var model = new CategoriaIndexViewModel();
            try
            {
                _etiquetaOrmService.RemoveEtiqueta(id);
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
        
        [Route("admin/etiqueta/view/{id?}")]
        public IActionResult Details(int id)
        {
            ViewBag.title = "Details tag";
            var model = new EtiquetaDetailsViewModel();
            var tag = _etiquetaOrmService.ObterEtiquetaPorId(id);
            model.Id = tag.Id;
            model.Nome = tag.Nome;
            return View(model);
        }
    }
}