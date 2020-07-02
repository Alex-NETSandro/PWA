namespace PWABlog.ViewModels.Admin.etiqueta
{
    public class EtiquetaEditViewModel:ViewModelAdminArea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EtiquetaEditViewModel()
        {
            TitlePage = "Edit Tag";
        }
    }
}