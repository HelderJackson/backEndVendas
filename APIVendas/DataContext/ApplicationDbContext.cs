using APIVendas.Entidade;
using Microsoft.EntityFrameworkCore;

namespace APIVendas.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  { }

        public DbSet<FornecedorEntidade> Fornecedores { get; set; }
        public DbSet<ProdutoEntidade> Produtos { get; set; }
        public DbSet<PedidoEntidade> Pedidos { get; set; }
    }
}