using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using NHttp;
using PWABlog.Models.Blog.Autor;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;
using PWABlog.Models.Blog.Postagem.Revisao;

namespace PWABlog.ViewModels.Admin.postagem
{
    public class PostagemCreateViewModel
    {
        public string Title { get; set; }
        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataHoraPostagem { get; set; }

        public ICollection<AutorCreate> Autor { get; set; }

        public ICollection<CategoriaCreate> Categoria { get; set; }

        public ICollection<EtiquetaIndex> PostagensEtiqueta { get; set; }

        public PostagemCreateViewModel()
        {
            Autor = new List<AutorCreate>();
            Categoria = new List<CategoriaCreate>();
            PostagensEtiqueta = new List<EtiquetaIndex>();
        }
    }

}
public class AutorCreate
{
    public int Id { get; set; }

    public string Nome { get; set; }
}

public class CategoriaCreate{
    public int Id { get; set; }

    public string Nome { get; set; }
    
    public ICollection<EtiquetaIndex> etiquetaIndex { get; set; }

    public CategoriaCreate()
    {
        etiquetaIndex = new List<EtiquetaIndex>();
    }
}

public class EtiquetaIndex
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public CategoriaEntity Categoria { get; set; }
}
