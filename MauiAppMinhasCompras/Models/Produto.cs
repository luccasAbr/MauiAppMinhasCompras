using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {

        //identificadores únicos
        [PrimaryKey, AutoIncrement]

        //atributos de produtos
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade {  get; set; }
        public double Preco {  get; set; }

        public double Total { get => Quantidade * Preco; }
    }
}
