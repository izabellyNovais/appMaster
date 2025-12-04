namespace AppWeb.Models
{
    public class Fornecedor
    {
      
            public int Id { get; set; }
            public string RazaoSocial { get; set; }
            public string NomeFantasia { get; set; }
            public string CNPJ { get; set; }
            public string NomeContato { get; set; }
            public string Telefone { get; set; }
            public string Email { get; set; }
            public string Website { get; set; }
            public Endereco Endereco { get; set; } 
    }
    

}
