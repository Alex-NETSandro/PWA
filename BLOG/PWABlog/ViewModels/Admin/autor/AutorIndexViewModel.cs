using System.Collections.Generic;

namespace PWABlog.ViewModels.Admin.autor
{
    public class AutorIndexViewModel:ViewModelAdminArea
    {
        public ICollection<AutorIndex> Autores { get; set; }
        public string Tipo { get; set; }

        public string Message { get; set; }
        public AutorIndexViewModel()
        {
            Autores = new List<AutorIndex>();
            TitlePage = "Autores";
        }
    }
}

public class AutorIndex
{
    public int Id { get; set; }
    public string Nome { get; set; }
}