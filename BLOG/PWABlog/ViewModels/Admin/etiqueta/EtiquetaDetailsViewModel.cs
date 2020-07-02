namespace PWABlog.ViewModels.Admin.etiqueta
{
    public class EtiquetaDetailsViewModel:ViewModelAdminArea
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EtiquetaDetailsViewModel()
        {
            TitlePage = "Details Tag";
        }
    }
}