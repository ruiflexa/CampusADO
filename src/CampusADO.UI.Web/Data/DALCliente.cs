using CampusADO.UI.Web.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace CampusADO.UI.Web.Data
{
    public class DALCliente : IGerenciaCRUD<Cliente>
    {
        // string de conexao
        // string conexao = WebConfigurationManager.ConnectionStrings["BancoContexto"].ConnectionString;
        private readonly string conexao =
            "Server=(localDB)\\MSSQLLocalDB;Database=CampusADO;Trusted_Connection=True;MultipleActiveResultSets=true";

        public void Atualiza(Cliente obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "UPDATE Clientes SET Nome=@nome, CPF=@cpf Where ClienteId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", obj.ClienteId);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@cpf", obj.CPF);
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

        public void Cadastra(Cliente obj)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "INSERT INTO Clientes (Nome, CPF) VALUES (@nome, @cpf)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@cpf", obj.CPF);
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

        public List<Cliente> Get()
        {
            string sql = "Select * FROM Clientes ORDER BY Nome";
            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Cliente> dados = new List<Cliente>();
                Cliente c = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            c = new Cliente();
                            c.ClienteId = (int)reader["ClienteId"];
                            c.Nome = reader["Nome"].ToString();
                            c.CPF = reader["CPF"].ToString();
                            
                            dados.Add(c);
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

        public Cliente GetById(int ? id)
        {
            using (var conn = new SqlConnection(conexao))
            {
                string sql = "Select * FROM Clientes WHERE ClienteId = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                Cliente c = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                c = new Cliente();
                                c.ClienteId = (int)reader["ClienteId"];
                                c.Nome = reader["Nome"].ToString();
                                c.CPF = reader["CPF"].ToString();
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
                return c;
            }
        }

    }
}
