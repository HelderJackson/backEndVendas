using APIVendas.DataContext;
using APIVendas.Entidade;
using APIVendas.Negocio;
using APIVendas.Service.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace APIVendas.Service.Service
{
    public class PedidoService : IService<PedidoEntidade>
    {
        private readonly ApplicationDbContext _context;

        public PedidoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PedidoEntidade>>> Selecionar()
        {
            ServiceResponse<List<PedidoEntidade>> serviceResponse = new ServiceResponse<List<PedidoEntidade>>();

            try
            {
                serviceResponse.Dados = _context.Pedidos.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<PedidoEntidade>> SelecionarPorID(int pedidoID)
        {
            ServiceResponse<PedidoEntidade> serviceResponse = new ServiceResponse<PedidoEntidade>();

            try
            {
                PedidoEntidade entPedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.ID == pedidoID);

                if (entPedido == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pedido não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = entPedido;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PedidoEntidade>>> Incluir(PedidoEntidade entPedido)
        {
            ServiceResponse<List<PedidoEntidade>> serviceResponse = new ServiceResponse<List<PedidoEntidade>>();

            try
            {
                var negProdtuo = new ProdutoNegocio(_context);

                var produtoID = Convert.ToInt32(entPedido.NomeProduto);
                var fornecedorID = Convert.ToInt32(entPedido.NomeFornecedor);

                var valorDoProduto = negProdtuo.SelecionarValorDoProduto(produtoID);
                entPedido.ValorTotal = entPedido.Quantidade * valorDoProduto;

                var nomeDoFornecedor = negProdtuo.SelecionarNomeFornecedor(fornecedorID);
                entPedido.NomeFornecedor = nomeDoFornecedor;

                var nomeDoProduto = negProdtuo.SelecionarNomeProduto(produtoID);
                entPedido.NomeProduto = nomeDoProduto;

                if (entPedido == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Pedidos.Add(entPedido);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PedidoEntidade>>> Alterar(PedidoEntidade entPedido)
        {
            ServiceResponse<List<PedidoEntidade>> serviceResponse = new ServiceResponse<List<PedidoEntidade>>();

            try
            {
                PedidoEntidade entPedido_Original = _context.Pedidos.AsNoTracking().FirstOrDefault(f => f.ID == entPedido.ID);


                if (entPedido.Quantidade != entPedido_Original.Quantidade || entPedido.NomeFornecedor != entPedido_Original.NomeFornecedor
                    || entPedido.NomeProduto != entPedido_Original.NomeProduto)
                {
                    var negProdtuo = new ProdutoNegocio(_context);

                    var produtoID = Convert.ToInt32(entPedido.NomeProduto);
                    var fornecedorID = Convert.ToInt32(entPedido.NomeFornecedor);

                    var valorDoProduto = negProdtuo.SelecionarValorDoProduto(produtoID);
                    entPedido.ValorTotal = entPedido.Quantidade * valorDoProduto;

                    var nomeDoFornecedor = negProdtuo.SelecionarNomeFornecedor(fornecedorID);
                    entPedido.NomeFornecedor = nomeDoFornecedor;

                    var nomeDoProduto = negProdtuo.SelecionarNomeProduto(produtoID);
                    entPedido.NomeProduto = nomeDoProduto;
                }

                if (entPedido_Original == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pedido não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Pedidos.Update(entPedido);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<PedidoEntidade>>> Excluir(int pedidoID)
        {
            ServiceResponse<List<PedidoEntidade>> serviceResponse = new ServiceResponse<List<PedidoEntidade>>();

            try
            {
                PedidoEntidade entPedido = _context.Pedidos.FirstOrDefault(f => f.ID == pedidoID);

                if (entPedido == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Pedido não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Pedidos.Remove(entPedido);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Pedidos.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }
    }
}