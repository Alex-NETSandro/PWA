using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using NHttp;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;

namespace PWABlog.RequestModels.postagem
{
    public class AdminPostagemCriarRequestModel
    {
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public string Descricao { get; set; }

        public string Data { get; set; }
        public string Hora { get; set; }

        public int listAutores { get; set; }
        
        public int listCategorias { get; set; }
        public int listEtiquetas { get; set; }
    }
}