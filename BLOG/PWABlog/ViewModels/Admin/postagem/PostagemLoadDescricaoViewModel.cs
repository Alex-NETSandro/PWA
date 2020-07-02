namespace PWABlog.ViewModels.Admin.postagem
{
    public class PostagemLoadDescricaoViewModel:ViewModelAdminArea
    {
        public string Descricao { get; set; }

        public PostagemLoadDescricaoViewModel()
        {
            TitlePage = "Description";
        }
    }
}