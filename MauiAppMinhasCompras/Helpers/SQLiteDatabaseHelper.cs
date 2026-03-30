using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        //comando para criar a tabela a partir da model
        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        //inserindo CRUD

        public Task<List<Produto>> GetRecentes()
        {
            return _conn.Table<Produto>()
                .OrderByDescending(p => p.DataCriacao)
                .Take(20)
                .ToListAsync();
        }

        //insert
        public Task<int> Insert(Produto p) 
        {
            p.DataCriacao = DateTime.Now;
            return _conn.InsertAsync(p);
        }

        //update
        public Task<List<Produto>> Update(Produto p) 
        {
            p.DataCriacao = DateTime.Now;

            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        //delete
        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }

        //listagem
        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        //pesquisa
        public Task<List<Produto>> Search(string q) 
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }

        public Task<List<Produto>> SearchByDate(DateTime data)
        {
            // Criamos o início e o fim do dia para filtrar no banco
            DateTime inicioDia = data.Date;
            DateTime fimDia = data.Date.AddDays(1).AddTicks(-1);

            return _conn.Table<Produto>()
                        .Where(p => p.DataCriacao >= inicioDia && p.DataCriacao <= fimDia)
                        .ToListAsync();
        }
    }
}
