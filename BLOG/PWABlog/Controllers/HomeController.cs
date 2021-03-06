﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PWABlog.Models;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;
using PWABlog.ViewModels.Home;

namespace PWABlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly PostagemOrmService _postagemOrmService;

        public HomeController(
            ILogger<HomeController> logger,
            CategoriaOrmService categoriaOrmService,
            PostagemOrmService postagemOrmService
        ){
            _logger = logger;
            _categoriaOrmService = categoriaOrmService;
            _postagemOrmService = postagemOrmService;
        }
        
        [Route("Home")]
        [Route("Home/Index")]
        [Route("Home/Index/{id?}")]
        public IActionResult Index()
        {   
            // Instanciar a ViewModel
            var model = new HomeIndexViewModel();

            // Alimentar a lista de postagens que serão exibidas na view
            var listaPostagens = _postagemOrmService.ObterPostagens();
            
            foreach (var postagem in listaPostagens)
            {
                var postagemHomeIndex = new PostagemHomeIndex();
                postagemHomeIndex.Titulo = postagem.Titulo;
                postagemHomeIndex.Descricao = postagem.Descricao;
                postagemHomeIndex.Categoria = postagem.Categoria.Nome;
                postagemHomeIndex.NumeroComentarios = postagem.Comentarios.Count.ToString();
                postagemHomeIndex.PostagemId = postagem.Id.ToString();
                
                // Obter última revisão
                var ultimaRevisao = postagem.Revisoes.OrderByDescending(o => o.DataCriacao).FirstOrDefault();
                if (ultimaRevisao != null)
                {
                    postagemHomeIndex.Data = ultimaRevisao.DataCriacao.ToLongDateString();
                }
                
                model.Postagens.Add(postagemHomeIndex);
            }
          
            // Alimentar a lista de categorias que serão exibidas na view
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            foreach (var categoria in listaCategorias)
            {
                var categoriaHomeIndex = new CategoriaHomeIndex();
                categoriaHomeIndex.Nome = categoria.Nome;
                categoriaHomeIndex.CategoriaId = categoria.Id.ToString();
                
                model.Categorias.Add(categoriaHomeIndex);
            
                // Alimentar a lista de etiquetas que serão exibidas na view, a partir das etiquetas da categoria
                foreach (var etiqueta in categoria.Etiquetas)
                {
                    var etiquetaHomeIndex = new EtiquetaHomeIndex();
                    etiquetaHomeIndex.Nome = etiqueta.Nome;
                    etiquetaHomeIndex.EtiquetaId = etiqueta.Id.ToString();
                
                    model.Etiquetas.Add(etiquetaHomeIndex);
                }
            }


            // Alimentar a lista de postagens populares que serão exibidas na view
            // TODO Obter lista de postagens populares
            var listaPostagensPopulares = _postagemOrmService.ObterPostagensPopulares();
            foreach (var postagemPopular in listaPostagensPopulares)
            {
                var postagemPopularHomeIndex = new PostagemPopularHomeIndex();
                postagemPopularHomeIndex.Titulo = postagemPopular.Titulo;
                postagemPopularHomeIndex.PostagemId = postagemPopular.Id;
                postagemPopularHomeIndex.Categoria = postagemPopular.Categoria.Nome;

                model.PostagensPopulares.Add(postagemPopularHomeIndex);
            }


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}