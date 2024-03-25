using APIVendas.DataContext;
using APIVendas.Service.ServiceInterface;

namespace APIVendas.Negocio
{
    public class ProdutoNegocio
    {
        private readonly ApplicationDbContext _context;

        public ProdutoNegocio(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal SelecionarValorDoProduto(int produtoID)
        {
            decimal valor;
            try
            {
                valor = _context.Produtos.Where(p => p.ID == produtoID).Select(p => p.Valor).FirstOrDefault();
            }
            catch (Exception ex )
            {
                throw new Exception("Valor não encontrado para esse Produto.");
            }
           
            return valor;
        }

        public string SelecionarNomeFornecedor(int fornecedorID)
        {
            string nomeDoFornecedor;
            try
            {
                nomeDoFornecedor = _context.Fornecedores.Where(f => f.ID == fornecedorID).Select(p => p.NomeDoContato).FirstOrDefault();

                if (string.IsNullOrEmpty(nomeDoFornecedor))
                {
                    throw new Exception("Valor não encontrado para esse Produto.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Valor não encontrado para esse Produto.");
            }

            return nomeDoFornecedor;
        }

        public string SelecionarNomeProduto(int produtoID)
        {
            string nomeDoFornecedor;
            try
            {
                nomeDoFornecedor = _context.Produtos.Where(f => f.ID == produtoID).Select(p => p.Nome).FirstOrDefault();

                if (string.IsNullOrEmpty(nomeDoFornecedor))
                {
                    throw new Exception("Valor não encontrado para esse Produto.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Valor não encontrado para esse Produto.");
            }

            return nomeDoFornecedor;
        }
    }
}