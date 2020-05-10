using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;

namespace PWABlog.ViewModels.Admin.postagem
{
    public class PostagemIndexViewModel
    {
        public ICollection<PostagemIndex> Postagens { get; set; }

        public string Tipo { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        
        public PostagemIndexViewModel(){
            Postagens = new List<PostagemIndex>();
        }
    }

    

    public class PostagemIndex
    {
        public int Id { get; set; }
        
        public string Titulo { get; set; }
        
        public string Descricao { get; set; }

        public string Data { get; set; }
        public string Time { get; set; }
        public string Autor { get; set; }
        
        public string Categoria { get; set; }

        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        public ICollection<RevisaoEntity> Revisoes { get; set; }

    }
}