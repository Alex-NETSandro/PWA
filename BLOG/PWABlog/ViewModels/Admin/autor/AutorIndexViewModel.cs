using System.Collections.Generic;

namespace PWABlog.ViewModels.Admin.autor
{
    public class AutorIndexViewModel
    {
        public ICollection<AutorIndex> Autores { get; set; }
        public string Title { get; set; }
        public string Tipo { get; set; }

        public string Message { get; set; }
        public AutorIndexViewModel()
        {
            Autores = new List<AutorIndex>();
        }
    }
}

public class AutorIndex
{
    public int Id { get; set; }
    public string Nome { get; set; }
}