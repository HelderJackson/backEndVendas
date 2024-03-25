using APIVendas.Entidade;

namespace APIVendas.Service.ServiceInterface
{
    public interface IService<T>
    {   
        /// <summary>
        /// Seleciona todos os Funcionários.
        /// </summary>
        /// <returns></returns>
        Task<ServiceResponse<List<T>>> Selecionar();

        /// <summary>
        /// Seleciona por ID o Fornecedor.
        /// </summary>
        /// <param name="fornecedorID"></param>
        /// <returns></returns>
        Task<ServiceResponse<T>> SelecionarPorID(int id);

        /// <summary>
        /// Inclusão do Funcionários.
        /// </summary>
        /// <param name="mdFornecedor"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<T>>> Incluir(T entT);

        /// <summary>
        /// Altera o Fornecedor.
        /// </summary>
        /// <param name="mdFornecedor"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<T>>> Alterar(T entT);

        /// <summary>
        /// Exclui um Fornecedor.
        /// </summary>
        /// <param name="fornecedorID"></param>
        /// <returns></returns>
        Task<ServiceResponse<List<T>>> Excluir(int entT);
    }
}