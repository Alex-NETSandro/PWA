using System.Collections.Generic;
using PWABlog.Models.Blog.Categoria;

namespace PWABlog.ViewModels.Admin.etiqueta
{
    public class EtiquetaIndexViewModel:ViewModelAdminArea
    {
        public ICollection<EtiquetaIndex> Etiquetas { get; set; }
        public string Message { get; set; }
        public string Tipo    { get; set; }

        public EtiquetaIndexViewModel()
        {
            Etiquetas = new List<EtiquetaIndex>();
            TitlePage = "Tags";
        }
    }


    public class EtiquetaIndex
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public CategoriaEntity Categoria { get; set; }
        
    }
}
