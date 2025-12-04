using AppWeb.Configs;
using AppWeb.Models;
using System.Data.Common;

namespace AppWeb.Models
{
    public class FornecedorDAO
    {
        private readonly Conexao _conexao;

        public FornecedorDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Fornecedor> ListarTodos()
        {
            var lista = new List<Fornecedor>();

           
            var comando = _conexao.CreateCommand("SELECT * FROM fornecedor_completo;");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var fornecedor = new Fornecedor();
                fornecedor.Id = leitor.GetInt32("id_fornecedor");
                fornecedor.RazaoSocial = DAOHelper.GetString(leitor, "razao_social");
                fornecedor.NomeFantasia = DAOHelper.GetString(leitor, "nome_fantasia");
                fornecedor.CNPJ = DAOHelper.GetString(leitor, "cnpj");
                fornecedor.NomeContato = DAOHelper.GetString(leitor, "nome_contato");
                fornecedor.Telefone = DAOHelper.GetString(leitor, "telefone");
                fornecedor.Email = DAOHelper.GetString(leitor, "email");
                fornecedor.Website = DAOHelper.GetString(leitor, "website");

          
                fornecedor.Endereco = new Endereco
                {
                    Rua = DAOHelper.GetString(leitor, "rua"),
                    Numero = leitor.GetInt32("numero"),
                    Bairro = DAOHelper.GetString(leitor, "bairro"),
                    CEP = DAOHelper.GetString(leitor, "cep"),
                    Cidade = DAOHelper.GetString(leitor, "cidade"),
                    Estado = DAOHelper.GetString(leitor, "estado")
                };

                lista.Add(fornecedor);
            }

            return lista;
        }

        public void Inserir(Fornecedor fornecedor)
        {
            try
            {
              
                var comando = _conexao.CreateCommand(
                    "INSERT INTO fornecedor (razao_social, nome_fantasia, cnpj, nome_contato, telefone, email, website, rua, numero, bairro, cep, cidade, estado) " +
                    "VALUES (@razao, @fantasia, @cnpj, @contato, @telefone, @email, @website, @rua, @numero, @bairro, @cep, @cidade, @estado)"
                );

                comando.Parameters.AddWithValue("@razao", fornecedor.RazaoSocial);
                comando.Parameters.AddWithValue("@fantasia", fornecedor.NomeFantasia);
                comando.Parameters.AddWithValue("@cnpj", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@contato", fornecedor.NomeContato);
                comando.Parameters.AddWithValue("@telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@email", fornecedor.Email);
                comando.Parameters.AddWithValue("@website", fornecedor.Website);

                comando.Parameters.AddWithValue("@rua", fornecedor.Endereco.Rua);
                comando.Parameters.AddWithValue("@numero", fornecedor.Endereco.Numero);
                comando.Parameters.AddWithValue("@bairro", fornecedor.Endereco.Bairro);
                comando.Parameters.AddWithValue("@cep", fornecedor.Endereco.CEP);
                comando.Parameters.AddWithValue("@cidade", fornecedor.Endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", fornecedor.Endereco.Estado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir fornecedor.", ex);
            }
        }
    }
}