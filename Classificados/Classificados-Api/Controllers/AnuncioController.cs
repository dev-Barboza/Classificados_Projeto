
using Classificados.Comum.Commands;
using Classificados.Comum.Enum;
using Classificados.Comum.Query;
using Classificados.Dominio.Commands.Anuncios;
using Classificados.Dominio.Handlers;
using Classificados.Dominio.Handlers.Command;
using Classificados.Dominio.Handlers.Command.Anuncio;
using Classificados.Dominio.Handlers.Queries.Anuncio;
using Classificados.Dominio.Queries.Anuncios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Classificados_Api.Controllers
{
    [Route("v1/annoucement")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public GenericCommandResult CreateAnnoucement(CriarAnuncioCommand command, [FromServices] CriarAnuncioHandler handler)
        {

            var usuarioid = HttpContext.User.Claims.FirstOrDefault(
                                c => c.Type == JwtRegisteredClaimNames.Jti
                            );
            command.IdUsuario = new Guid(usuarioid.Value);

            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("update-annoucement")]
        [HttpPut]
        [Authorize]
        public GenericCommandResult UpdateAnnoucement(Guid id,
           [FromBody] AlterarAnuncioCommand command,
           [FromServices] AlterarAnuncioHandler handler)
        {
             if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id do Anuncio", "");

            command.IdAnuncio = id;

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("{id}/status")]
        [Authorize]
        public GenericCommandResult UpdateStatusAnnoucement(Guid id,
           [FromBody] AlterarStatusAnuncioCommand command,
           [FromServices] AlterarStatusAnuncioHandler handler
       )
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id do Anuncio", "");

            command.IdAnuncio = id;

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet("list-anoucemment")]
        public GenericQueryResult GetAll([FromServices] ListarAnuncioHandler handle)
        {
            ListarAnuncioQuery query = new ListarAnuncioQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        [HttpGet("{titulo}/annoucement")]
        public GenericQueryResult GetAnnoucementTitle([FromServices] BuscarAnuncioTituloHandler handle)
        {
            BuscarAnuncioTituloQuery query = new BuscarAnuncioTituloQuery();

            return (GenericQueryResult)handle.Handle(query);
        }

        [HttpPut("{id}/image")]
        [Authorize]
        public GenericCommandResult UpdateImage(Guid id,
           [FromBody] AlterarImagemAnuncioCommand command,
           [FromServices] AlterarImagemAnuncioHandler handler
       )
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id do Anuncio", "");

            command.IdAnuncio = id;

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("{id}/titulo")]
        [Authorize]
        public GenericCommandResult UpdateTitle(Guid id,
           [FromBody] AlterarTituloAnuncioCommand command,
           [FromServices] AlterarTituloAnuncioHandler handler
       )
        {
            if (id == Guid.Empty)
                return new GenericCommandResult(false, "Informe o Id do Anuncio", "");

            command.IdAnuncio = id;

            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpDelete("deletar-anuncio")]
        //[Authorize]
        public GenericCommandResult DeleteAnnoucement(Guid id,
                    [FromBody] DeletarAnuncioCommand command,
                                    [FromServices] DeletarAnuncioHandler handler
      )
        {

            return (GenericCommandResult)handler.Handle(command);
        }
    }

    

}
