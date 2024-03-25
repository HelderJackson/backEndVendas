using APIVendas.Entidade;
using APIVendas.Service.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IService<PedidoEntidade> _pedidoInterface;

        public PedidoController(IService<PedidoEntidade> pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PedidoEntidade>>>> Selecionar()
        {
            return Ok(await _pedidoInterface.Selecionar());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PedidoEntidade>>> SelecionarPorID(int id)
        {
            return Ok(await _pedidoInterface.SelecionarPorID(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<PedidoEntidade>>>> Incluir(PedidoEntidade entPedido)
        {
            return Ok(await _pedidoInterface.Incluir(entPedido));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<PedidoEntidade>>>> Alterar(PedidoEntidade entPedido)
        {
            return Ok(await _pedidoInterface.Alterar(entPedido));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<ProdutoEntidade>>>> Excluir(int pedidoID)
        {
            return Ok(await _pedidoInterface.Excluir(pedidoID));
        }
    }
}