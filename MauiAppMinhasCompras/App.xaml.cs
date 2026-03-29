using MauiAppMinhasCompras.Helpers;

namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;

        //criando conexão com o BD
        public static SQLiteDatabaseHelper Db
        {
            get
            { 

                //comando para saber se o banco está aberto
                if (_db == null)
                {
                    string path = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), "banco_sqlite.compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }

        //pequena mainpage
        public App()
        {
            InitializeComponent();

            //alterando estrutura geral do app para pr-BR (linguagem, moeda, data, etc)
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
