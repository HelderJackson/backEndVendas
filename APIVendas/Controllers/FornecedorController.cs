using APIVendas.DataContext;
using APIVendas.Entidade;
using APIVendas.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IService<FornecedorEntidade> _fornecedorInterface;

        public FornecedorController(IService<FornecedorEntidade> fornecedorInterface)
        {
            _fornecedorInterface = fornecedorInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FornecedorEntidade>>>> Selecionar()
        {
            return Ok(await _fornecedorInterface.Selecionar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FornecedorEntidade>>> SelecionarPorID(int id)
        {
            return Ok(await _fornecedorInterface.SelecionarPorID(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FornecedorEntidade>>>> Incluir(FornecedorEntidade fornecedor)
        {
            return Ok(await _fornecedorInterface.Incluir(fornecedor));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FornecedorEntidade>>>> Alterar(FornecedorEntidade fornecedor)
        {
            return Ok(await _fornecedorInterface.Alterar(fornecedor));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FornecedorEntidade>>>> Excluir(int id)
        {
            return Ok(await _fornecedorInterface.Excluir(id));
        }
    }
}