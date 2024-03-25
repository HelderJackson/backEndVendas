using APIVendas.Entidade;
using APIVendas.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IService<ProdutoEntidade> _produtoInterface;

        public ProdutoController(IService<ProdutoEntidade> produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProdutoEntidade>>>> Selecionar()
        {
            return Ok(await _produtoInterface.Selecionar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProdutoEntidade>>> SelecionarPorID(int id)
        {
            return Ok(await _produtoInterface.SelecionarPorID(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FornecedorEntidade>>>> Incluir(ProdutoEntidade fornecedor)
        {
            return Ok(await _produtoInterface.Incluir(fornecedor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<ProdutoEntidade>>>> Alterar(ProdutoEntidade fornecedor)
        {
            return Ok(await _produtoInterface.Alterar(fornecedor));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProdutoEntidade>>>> Excluir(int id)
        {
            return Ok(await _produtoInterface.Excluir(id));
        }
    }
}
