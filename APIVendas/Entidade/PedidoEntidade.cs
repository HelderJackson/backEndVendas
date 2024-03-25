using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIVendas.Entidade
{
    public class PedidoEntidade
    {
        [Key]
        public int ID { get; set; }
        public string NomeFornecedor { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataDoPedido { get; set; } = DateTime.Now.ToLocalTime();
        public decimal ValorTotal { get; set; }
    }
}