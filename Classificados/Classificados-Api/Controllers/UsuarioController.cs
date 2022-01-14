using Classificados.Comum.Commands;
using Classificados.Comum.Query;
using Classificados.Dominio.Commands.Usuarios;
using Classificados.Dominio.Entidades;
using Classificados.Dominio.Handlers.Command.Usuario;
using Classificados.Dominio.Handlers.Queries.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Classificados_Api.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [Route("signup")]
        [HttpPost]
        // Aqui nós passamos como parametro os Command e Handler
        public GenericCommandResult Signup(CriarContaCommand command,
                                                // Definimos que o CriarContaHanlde é um serviço
                                                [FromServices] CriarContaHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("signin")]
        [HttpPost]
        public GenericCommandResult SignIn(LogarCommand command, [FromServices] LogarHandler handler)
        {
            var resultado = (GenericCommandResult)handler.Handle(command);

            if (resultado.Sucesso)
            {
                var token = GerarJSONWebToken((Usuario)resultado.Data);

                return new GenericCommandResult(resultado.Sucesso, resultado.Mensagem, new { token = token });
            }

            return new GenericCommandResult(false, resultado.Mensagem, resultado.Data);
        }

        [HttpGet("list-users")]
        public GenericQueryResult GetUsers([FromServices] ListarUsuarioHandler handle)
        {
            ListarUsuarioQuery query = new ListarUsuarioQuery();

            return (GenericQueryResult)handle.Handle(query);
        }


        // Criamos nosso método que vai gerar nosso Token
        private string GerarJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaClassificadosApi"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.FamilyName, userInfo.Nome),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.CPF),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString()),
                new Claim(ClaimTypes.Role, userInfo.TipoUsuario.ToString()),
                new Claim("role", userInfo.TipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, userInfo.Id.ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    "classificados",
                    "classificados",
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
