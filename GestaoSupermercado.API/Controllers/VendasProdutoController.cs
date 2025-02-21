using AutoMapper;
using GestaoSupermercado.API.Models;
using GestaoSupermercado.Core.Servicos.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoSupermercado.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class VendasProdutoController : ControllerBase
    {
        private readonly IVendasServicos _vendasServicos;
        private readonly IMapper _mapper;

        public VendasProdutoController(IVendasServicos vendasServicos, IMapper mapper)
        {
            _vendasServicos = vendasServicos;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ObterVendas()
        {
            var vendas = await _vendasServicos.ObterVendas();

            if(vendas is null)
                return NoContent();

            var vendasModel = _mapper.Map<List<VendaProdutoModelSaida>>(vendas);

            return Ok(vendasModel);
        }

        [HttpGet("produto/{id}")]
        public async Task<IActionResult> ObterVendasProduto(int id)
        {
            var vendasProdutos = await _vendasServicos.ObterVendasPorProduto(id);

            var vendasModel = _mapper.Map<List<VendaProdutoModelSaida>>(vendasProdutos);

            return Ok(vendasModel);
        }

        [HttpPut("produto/{id}/quantidade/{quantidade}")]
        public async Task<IActionResult> InserirVenda(int id, int quantidade)
        {
            if (id > 0 && quantidade > 0)
            {
                var retorno = await _vendasServicos.IncluirVenda(id, quantidade);

                if (retorno.Sucesso)
                    return Ok();

                return BadRequest(retorno.Mensagem);
            }

            return BadRequest("Parametros com valores invalidos.");
        }
    }
}
