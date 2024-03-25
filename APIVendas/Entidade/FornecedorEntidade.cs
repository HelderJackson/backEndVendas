using System.ComponentModel.DataAnnotations;

namespace APIVendas.Entidade
{
    public class FornecedorEntidade
    {
        [Key]
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string UF { get; set; }
        public string EmailDeContato { get; set; }
        public string NomeDoContato { get; set; }

        //public DateTime DataDoCadastro { get; set; } = DateTime.Now.ToLocalTime();
    }
}