using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;

namespace MauiAppMinhasCompras.Views;

public partial class Relatorio : ContentPage
{
    ObservableCollection<Produto> lista_relatorio = new ObservableCollection<Produto>();

    public Relatorio()
    {
        InitializeComponent();
        lst_relatorio.ItemsSource = lista_relatorio;

        // Inicia com a data de hoje
        dtp_filtro.Date = DateTime.Now;
    }

    private async void dtp_filtro_DateSelected(object sender, DateChangedEventArgs e)
    {
        await CarregarDados(e.NewDate);
    }

    private async Task CarregarDados(DateTime data)
    {
        lista_relatorio.Clear();

        // Buscamos no banco
        var produtos = await App.Db.SearchByDate(data);

        foreach (var p in produtos)
        {
            lista_relatorio.Add(p);
        }

        double total = lista_relatorio.Sum(i => i.Total);
        lbl_soma_dia.Text = $"Total do dia: {total:C}";
    }
}