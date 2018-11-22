using CampusADO.UI.Web.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CampusADO.UI.Web.Data
{

    public class DALProduto : IGerenciaCRUD<Produto>
    {
        // string de conexao
        // string conexao = WebConfigurationManager.ConnectionStrings["BancoContexto"].ConnectionString;

        private readonly string conexao = 
            "Server=(localDB)\\MSSQLLocalDB;Database=CampusADO;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void Atualiza(Produto obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "UPDATE Produtoes SET Nome=@nome, Preco=@preco, Estoque=@estoque Where ProdutoID=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", obj.ProdutoID);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco", obj.Preco);
                cmd.Parameters.AddWithValue("@estoque", obj.Estoque);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Cadastra(Produto obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "INSERT INTO Produtoes (Nome, Preco, Estoque) VALUES (@nome, @preco, @estoque)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@preco", obj.Preco);
                cmd.Parameters.AddWithValue("@estoque", obj.Estoque);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void Exclui(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Produto> Get()
        {
            string sql = "Select * FROM Produtoes ORDER BY Nome";
            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Produto> dados = new List<Produto>();
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Produto();
                            p.ProdutoID = (int) reader["ProdutoID"];
                            p.Nome = reader["Nome"].ToString();
                            p.Preco = (decimal) reader["Preco"];
                            p.Estoque = (int) reader["Estoque"];
                            dados.Add(p);
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }

                return dados;
            }
        }

        public Produto GetById(int ? id )
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "Select * FROM Produtoes WHERE ProdutoID=@cod";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cod", id);
                Produto p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Produto();
                                p.ProdutoID = (int)reader["ProdutoID"];
                                p.Nome = reader["Nome"].ToString();
                                p.Preco = (decimal)reader["Preco"];
                                p.Estoque = (int)reader["Estoque"];
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return p;
            }   
        }
    }
}
