namespace PWABlog.ViewModels.Admin.Categoria
{
    public class CategoriaCreateViewModel:ViewModelAdminArea
    {
        public string Nome { get; set; }            
        public CategoriaCreateViewModel()
        {
            TitlePage = "Add Category";
        }
    }
}