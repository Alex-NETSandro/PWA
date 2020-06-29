using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWABlog.ViewModels.Admin.Categoria
{
    public class CategoriaIndexViewModel:ViewModelAdminArea
    {
        public ICollection<CategoriaIndex> Categorias { get; set; }
        public string Message { get; set; }
        public string Tipo    { get; set; }

        public CategoriaIndexViewModel()
        {
            Categorias = new List<CategoriaIndex>();
            TitlePage = "Categories";
        }
    }


    public class CategoriaIndex
    {
        public string Nome { get; set; }
        public int CategoriaId { get; set; }
    }
}
