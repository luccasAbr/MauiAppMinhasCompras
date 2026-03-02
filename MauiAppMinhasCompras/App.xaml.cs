namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public App()
        {
            //atualizando breviamente a página inicial

            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
