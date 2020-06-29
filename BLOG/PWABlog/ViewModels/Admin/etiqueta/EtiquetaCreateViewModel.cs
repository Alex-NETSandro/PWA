using System.Collections.Generic;

namespace PWABlog.ViewModels.Admin.etiqueta
{
    public class EtiquetaCreateViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public ICollection<EtiquetaCategoriaCreate> Categoria { get; set; }

        public EtiquetaCreateViewModel()
        {
            Categoria = new List<EtiquetaCategoriaCreate>();
        }
    }
    
    public class EtiquetaCategoriaCreate{
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}