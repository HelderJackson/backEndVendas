using APIVendas.DataContext;
using APIVendas.Entidade;
using APIVendas.Service.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace APIVendas.Service.FornecedorService
{
    public class FornecedorService : IService<FornecedorEntidade>
    {
        private readonly ApplicationDbContext _context;

        public FornecedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FornecedorEntidade>>> Selecionar()
        {
            ServiceResponse<List<FornecedorEntidade>> serviceResponse = new ServiceResponse<List<FornecedorEntidade>>();

            try
            {
                serviceResponse.Dados = _context.Fornecedores.ToList();

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

        public async Task<ServiceResponse<FornecedorEntidade>> SelecionarPorID(int fornecedorID)
        {
            ServiceResponse<FornecedorEntidade> serviceResponse = new ServiceResponse<FornecedorEntidade>();

            try
            {
                FornecedorEntidade fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(f => f.ID == fornecedorID);

                if (fornecedor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Fornecedor não localizado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = fornecedor;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public  async Task<ServiceResponse<List<FornecedorEntidade>>> Incluir(FornecedorEntidade entFornecedor)
        {
            ServiceResponse<List<FornecedorEntidade>> serviceResponse = new ServiceResponse<List<FornecedorEntidade>>();

            try
            {
                if (entFornecedor == null) 
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                 _context.Fornecedores.Add(entFornecedor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Fornecedores.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FornecedorEntidade>>> Alterar(FornecedorEntidade entFornecedor)
        {
            ServiceResponse<List<FornecedorEntidade>> serviceResponse = new ServiceResponse<List<FornecedorEntidade>>();

            try
            {
                FornecedorEntidade fornecedor = _context.Fornecedores.AsNoTracking().FirstOrDefault(f => f.ID == entFornecedor.ID);

                if (fornecedor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Fornecedor não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Fornecedores.Update(entFornecedor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Fornecedores.ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false; ;
            }

            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<FornecedorEntidade>>> Excluir(int fornecedorID)
        {
            ServiceResponse<List<FornecedorEntidade>> serviceResponse = new ServiceResponse<List<FornecedorEntidade>>();

            try
            {
                FornecedorEntidade fornecedor = _context.Fornecedores.FirstOrDefault(f => f.ID == fornecedorID);

                if (fornecedor == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Fornecedor não localizado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Fornecedores.ToList();
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