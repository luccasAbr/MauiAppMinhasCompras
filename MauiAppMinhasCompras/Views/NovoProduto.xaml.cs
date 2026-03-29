using MauiAppMinhasCompras.Models;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

	//botão vindo do .xaml
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			//pegando os dados digitados
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco.Text)
			};

			//inserindo no bd
			await App.Db.Insert(p);
			await DisplayAlert("Sucesso!", "Registro inserido", "OK");
			await Navigation.PopAsync();

		//catch de erros
		} catch(Exception ex)
		{
			await DisplayAlert("Ops!", ex.Message, "OK");
		}

    }
}