using System.ComponentModel.DataAnnotations;

namespace APIVendas.Entidade
{
    public class ProdutoEntidade
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDoCadastro { get; set; } = DateTime.Now.ToLocalTime();
        public decimal Valor { get; set; }
    }
}