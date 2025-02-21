using GestaoSupermercado.Core.Autenticacao;
using GestaoSupermercado.Core.Servicos.Interface;
using GestaoSupermercado.Infraestrutura.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoSupermercado.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioServicos _usuarioServicos;
        private readonly JwtServicosAutenticacao _jwtServicosAutenticacao;

        public AutenticacaoController(IUsuarioServicos usuarioServicos, JwtServicosAutenticacao jwtServicosAutenticacao)
        {
            _usuarioServicos = usuarioServicos;
            _jwtServicosAutenticacao = jwtServicosAutenticacao;
        }

        [HttpPut("token")]
        public async Task<IActionResult> ObterToken([FromBody] Usuario usuario)
        {
            var dadosUsuario = await _usuarioServicos.ObterUsuario(usuario.Email);

            if (dadosUsuario == null) return Unauthorized();

            if(!_usuarioServicos.ValidarSenha(usuario.Senha, dadosUsuario.Senha))
                return Unauthorized();

            var token = _jwtServicosAutenticacao.GenerateToken(dadosUsuario.Email);

            return Ok(token);
        }

        [HttpPost("cadastrar")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] Usuario usuario)
        {
            if(string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
                return BadRequest("Dados incorretos!");

            var retorno = await _usuarioServicos.CadastrarUsuario(usuario);

            if (retorno.Sucesso)
                return Created();

            return BadRequest(retorno.Mensagem);
        }
    }
}
