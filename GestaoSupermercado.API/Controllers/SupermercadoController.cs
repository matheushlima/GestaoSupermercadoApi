using AutoMapper;
using GestaoSupermercado.API.Models;
using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Infraestrutura.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoSupermercado.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SupermercadoController : ControllerBase
    {
        private readonly IProdutoServicos _produtoServicos;
        private readonly IMapper _mapper;

        public SupermercadoController(IProdutoServicos produtoServicos, IMapper mapper)
        {
            _produtoServicos = produtoServicos;
            _mapper = mapper;
        }

        [HttpGet("produtos")]
        public async Task<IActionResult> ObterProdutos()
        {
            var produtos = await _produtoServicos.ObterProdutos();

            if(produtos is null)
                return NoContent();

            var produtosModel = _mapper.Map<List<ProdutoModelSaida>>(produtos);

            return Ok(produtosModel);
        }

        [HttpGet("produto/{id}")]
        public async Task<IActionResult> ObterProdutoId(int id)
        {
            var produto = await _produtoServicos.ObterProdutoPorId(id);

            if (produto is null)
                return NoContent();

            var produtosModel = _mapper.Map<ProdutoModelSaida>(produto);

            return Ok(produtosModel);
        }

        [HttpPost("produto")]
        public async Task<IActionResult> InserirProduto([FromBody] ProdutoModelEntrada produtoModel)
        {
            var produto = _mapper.Map<ProdutoDto>(produtoModel);

            var retorno = await _produtoServicos.CadastrarProduto(produto);

            if (retorno.Sucesso)
                return Created();

            return BadRequest(retorno.Mensagem);
        }

        [HttpPut("produto/{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, [FromBody] ProdutoModelEntrada produtoModel)
        {
            var produto = _mapper.Map<ProdutoDto>(produtoModel);

            var retorno = await _produtoServicos.AtualizarProduto(id, produto);

            if (retorno.Sucesso)
                return Ok();

            return BadRequest(retorno.Mensagem);
        }

        [HttpDelete("produto/{id}")]
        public async Task<IActionResult> DeletarProduto(int id)
        {
            if (id < 1)
                return BadRequest("ID do produto invalido.");

            var retorno = await _produtoServicos.DeletarProduto(id);

            if (retorno.Sucesso)
                return Ok();

            return BadRequest(retorno.Mensagem);
        }
    }
}
