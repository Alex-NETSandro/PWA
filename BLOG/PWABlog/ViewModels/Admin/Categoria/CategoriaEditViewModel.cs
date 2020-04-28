using System.Collections.Generic;
using System.Collections.ObjectModel;
using PWABlog.Models.Blog.Categoria;
using PWABlog.Models.Blog.Etiqueta;
using PWABlog.Models.Blog.Postagem;

namespace PWABlog.ViewModels.Admin.Categoria
{
    public class CategoriaEditViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<PostagemEntity> Postagens { get; set; }
        public ICollection<EtiquetaEntity> Etiquetas { get; set; }

        public CategoriaEditViewModel()
        {
            Postagens = new List<PostagemEntity>();
            Etiquetas = new List<EtiquetaEntity>();
            
        }
    }
}