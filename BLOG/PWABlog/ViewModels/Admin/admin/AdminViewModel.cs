namespace PWABlog.ViewModels.Admin.admin
{
    public class AdminViewModel:ViewModelAdminArea
    {
        public int Author { get; set; }        
        public int Posts { get; set; }        
        public int Tags { get; set; }        
        public int Category { get; set; }        
        public AdminViewModel()
        {
            TitlePage = "Painel";
            Layout = "_Layout";
        }
    }
}