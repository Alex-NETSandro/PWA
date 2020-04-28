using System;
using System.Collections.Generic;
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

        public DateTime DataHoraPostagem { get; set; }

        public AutorEntity Autor { get; set; }
        
        public CategoriaEntity Categoria { get; set; }

        public List<PostagemEtiquetaEntity> PostagensEtiquetas { get; set; }

        public ICollection<RevisaoEntity> Revisoes { get; set; }
    }
}