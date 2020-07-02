namespace PWABlog.ViewModels.Admin.autor
{
    public class AutorEditViewModel:ViewModelAdminArea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public AutorEditViewModel()
        {
            TitlePage = "Edit Author";
        }
    }
}