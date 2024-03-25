using APIVendas.DataContext;
using APIVendas.Entidade;
using APIVendas.Service.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace APIVendas.Service.Service
{
    public class ProdutoService : IService<ProdutoEntidade>
    {
        private readonly ApplicationDbContext _context;

        public ProdutoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProdutoEntidade>>> Selecionar()
        {
            ServiceResponse<List<ProdutoEntidade>> serviceResponse = new ServiceResponse<List<ProdutoEntidade>>();

            try
            {
                serviceResponse.Dados = _context.Produtos.ToList();

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

        public async Task<ServiceResponse<ProdutoEntidade>> SelecionarPorID(int produtoID)
        {
            ServiceResponse<ProdutoEntidade> serviceResponse = new ServiceResponse<ProdutoEntidade>();

            try
            {
                ProdutoEntidade entProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.ID == produtoID);

                if (entProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = entProduto;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoEntidade>>> Incluir(ProdutoEntidade entProduto)
        {
            ServiceResponse<List<ProdutoEntidade>> serviceResponse = new ServiceResponse<List<ProdutoEntidade>>();

            try
            {
                if (entProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Produtos.Add(entProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<ProdutoEntidade>>> Alterar(ProdutoEntidade entProduto)
        {
            ServiceResponse<List<ProdutoEntidade>> serviceResponse = new ServiceResponse<List<ProdutoEntidade>>();

            try
            {
                ProdutoEntidade entProduto_Original = _context.Produtos.AsNoTracking().FirstOrDefault(f => f.ID == entProduto.ID);

                if (entProduto_Original == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Produtos.Update(entProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ProdutoEntidade>>> Excluir(int produtoID)
        {
            ServiceResponse<List<ProdutoEntidade>> serviceResponse = new ServiceResponse<List<ProdutoEntidade>>();

            try
            {
                ProdutoEntidade entProduto = _context.Produtos.FirstOrDefault(f => f.ID == produtoID);

                if (entProduto == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Produto não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Produtos.Remove(entProduto);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Produtos.ToList();
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