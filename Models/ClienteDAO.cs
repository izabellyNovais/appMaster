using AppWeb.Configs;
using AppWeb.Models;
using System;
using System.Data.Common; 

namespace AppWeb.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;

        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Cliente> ListarTodos()
        {
            var lista = new List<Cliente>();

          
            var comando = _conexao.CreateCommand("SELECT * FROM cliente_completo;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var cliente = new Cliente();
                cliente.Id = leitor.GetInt32("id_cliente");
                cliente.Nome = DAOHelper.GetString(leitor, "nome");
                cliente.DataNascimento = DAOHelper.GetDateTime(leitor, "data_nascimento"); 
                cliente.Sexo = DAOHelper.GetString(leitor, "sexo");
                cliente.Telefone = DAOHelper.GetString(leitor, "telefone");
                cliente.Email = DAOHelper.GetString(leitor, "email");

                cliente.Endereco = new Endereco
                {
                    Rua = DAOHelper.GetString(leitor, "rua"),
                    Numero = leitor.GetInt32("numero"),
                    Bairro = DAOHelper.GetString(leitor, "bairro"),
                    CEP = DAOHelper.GetString(leitor, "cep"),
                    Cidade = DAOHelper.GetString(leitor, "cidade"),
                    Estado = DAOHelper.GetString(leitor, "estado")
                };

                lista.Add(cliente);
            }

            return lista;
        }

        public void Inserir(Cliente cliente)
        {
            try
            {
            
                var comando = _conexao.CreateCommand(
                    "INSERT INTO cliente (nome, data_nascimento, sexo, telefone, email, rua, numero, bairro, cep, cidade, estado) " +
                    "VALUES (@nome, @dt_nasc, @sexo, @telefone, @email, @rua, @numero, @bairro, @cep, @cidade, @estado)"
                );

                
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@dt_nasc", cliente.DataNascimento);
                comando.Parameters.AddWithValue("@sexo", cliente.Sexo);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@email", cliente.Email);

                comando.Parameters.AddWithValue("@rua", cliente.Endereco.Rua);
                comando.Parameters.AddWithValue("@numero", cliente.Endereco.Numero);
                comando.Parameters.AddWithValue("@bairro", cliente.Endereco.Bairro);
                comando.Parameters.AddWithValue("@cep", cliente.Endereco.CEP);
                comando.Parameters.AddWithValue("@cidade", cliente.Endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", cliente.Endereco.Estado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro ao inserir cliente.", ex);
            }
        }
    }
}