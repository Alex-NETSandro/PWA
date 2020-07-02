namespace PWABlog.ViewModels.Admin.autor
{
    public class AutorDetailsViewModel:ViewModelAdminArea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public AutorDetailsViewModel()
        {
            TitlePage = "Details Author";
        }
    }
}