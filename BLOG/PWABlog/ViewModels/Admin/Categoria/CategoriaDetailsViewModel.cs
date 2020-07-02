namespace PWABlog.ViewModels.Admin.Categoria
{
    public class CategoriaDetailsViewModel:ViewModelAdminArea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public CategoriaDetailsViewModel()
        {
            TitlePage = "Details Category";
        }
    }
}