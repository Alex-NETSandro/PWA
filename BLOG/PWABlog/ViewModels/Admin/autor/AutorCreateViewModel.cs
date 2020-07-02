namespace PWABlog.ViewModels.Admin.autor
{
    public class AutorCreateViewModel:ViewModelAdminArea
    {
        public string Title { get; set; }
        public string Tipo { get; set; }
        public string Message { get; set; }
        
        public string Nome { get; set; }

        public AutorCreateViewModel()
        {
            TitlePage = "Add Author";
        }
    }
}