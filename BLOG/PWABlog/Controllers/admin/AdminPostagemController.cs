using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NHttp;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;
using PWABlog.RequestModels.postagem;
using PWABlog.ViewModels.Admin.postagem;

namespace PWABlog.Controllers.admin
{
    public class AdminPostagemController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly AutorOrmService _autorOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly EtiquetaOrmService _etiquetaOrmService;
        private readonly DatabaseContext _databaseContext;

        public AdminPostagemController(PostagemOrmService postagemOrmService,DatabaseContext databaseContext)
        {
            _postagemOrmService = postagemOrmService;
            _databaseContext = databaseContext;
        }
        
        [Route("admin/postagem/index")]
        [Route("admin/postagem")]
        public IActionResult Index()
        {
            var model = new PostagemIndexViewModel();
            model.Title = "Postagens";
            var postagens = _postagemOrmService.ObterPostagens();

            foreach (var postagem in postagens)
            {
                var post = new PostagemIndex();
                post.Id = postagem.Id;
                post.Autor = postagem.Autor.Nome;
                post.Categoria = postagem.Categoria.Nome;
                post.Descricao = post.Descricao;
                post.Revisoes = postagem.Revisoes;
                post.Titulo = postagem.Titulo;
                post.PostagensEtiquetas = postagem.PostagensEtiquetas;
                post.DataHoraPostagem = postagem.DataHoraPostagem;
                model.Postagens.Add(post);
            }
            return View(model);
        }
        
        [HttpGet]
        [Route("admin/postagem/create")]
        public IActionResult Create()
        {
            var modal = new PostagemCreateViewModel();
            modal.Title = "Nova Postagem";
            var _autorOrmService = new AutorOrmService(_databaseContext);
            var autores = _autorOrmService.ObterAutores();
            
            var _categoriaOrmService = new CategoriaOrmService(_databaseContext);
            var categorias = _categoriaOrmService.ObterCategorias();
            
            var _etiquetaOrmService = new EtiquetaOrmService(_databaseContext);
            var etiquetas = _etiquetaOrmService.ObterEtiqueta();
            
            foreach (var autor in autores)
            {
                var author = new AutorCreate();
                author.Id = autor.Id;
                author.Nome = autor.Nome;
                modal.Autor.Add(author);
            }

            foreach (var cat in categorias)
            {
                var category = new CategoriaCreate();
                category.Id = cat.Id;
                category.Nome = cat.Nome;
                foreach (var tag in cat.Etiquetas)
                {
                    var tagIndex = new EtiquetaIndex();
                    tagIndex.Categoria = tag.Categoria;
                    tagIndex.Id = tag.Id;
                    tagIndex.Nome = tag.Nome;
                    category.etiquetaIndex.Add(tagIndex);
                }
                
                modal.Categoria.Add(category);
            }

            foreach (var et in etiquetas)
            {
                var tag = new EtiquetaIndex();
                tag.Id = et.Id;
                tag.Nome = et.Nome;
                tag.Categoria = et.Categoria;
                modal.PostagensEtiqueta.Add(tag);
            }
            return View(modal);
        }
        
        [HttpPost]
        [Route("admin/postagem/create")]
        public IActionResult Create(AdminPostagemCriarRequestModel request)
        {
            var postagem = new PostagemEntity();
            var categoriaId = request.listCategorias;
            var autorId = request.listAutores;
            var etiquetaId = request.listEtiquetas;

            var _autorOrmService = new AutorOrmService(_databaseContext);
            var _categoriaOrmService = new CategoriaOrmService(_databaseContext);
            var _etiquetaOrmService = new EtiquetaOrmService(_databaseContext);

            var categoria = _categoriaOrmService.ObterCategoriaPorId(categoriaId);
            var autor = _autorOrmService.ObterAutorPorId(autorId);
            var etiqueta = _etiquetaOrmService.ObterEtiquetaPorId(etiquetaId);
            postagem.Autor = autor;
            postagem.Categoria = categoria;
            postagem.Descricao = request.Descricao;
            postagem.Titulo = request.Titulo;
            postagem.DataHoraPostagem = request.DataHoraPostagem;

            var model = new PostagemIndexViewModel();
            try
            {
                _postagemOrmService.AddPostagem(postagem);
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

        [HttpGet]
        [Route("admin/postagem/edit/{id?}")]
        public IActionResult Edit(int id)
        {
            return View();
        }
        
        [HttpPost]
        [Route("admin/postagem/edit")]
        public IActionResult Update(AdminPostagemUpdateRequestModel request)
        {
            return RedirectToAction("Index");
        }
        
        [Route("admin/postagem/remove/{id?}")]
        public IActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }
        
        [Route("admin/postagem/details/{id?}")]
        public IActionResult Details(int id)
        {
            return View();
        }
        
        [Route("admin/postagem/listRevisoes/{id?}")]
        public IActionResult ListRevisao(int id)
        {
            return View();
        }
        
        [Route("admin/postagem/listEtiquetas/{id?}")]
        public IActionResult ListEtiqueta(int id)
        {
            return View();
        }


        [Route("admin/postagem/descricao/{id?}")]
        public IActionResult LoadDescricao(int id)
        {
            var postagem = _postagemOrmService.ObterPostagemPorId(id);
            var model = new PostagemLoadDescricaoViewModel();
            model.Descricao = postagem.Descricao;
            return View(model);
        }
    }
}