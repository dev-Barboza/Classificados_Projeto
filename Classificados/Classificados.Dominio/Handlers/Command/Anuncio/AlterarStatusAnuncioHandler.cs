using Classificados.Comum.Commands;
using Classificados.Comum.Handlers;
using Classificados.Dominio.Commands.Anuncios;
using Classificados.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Command.Anuncio
{
    public class AlterarStatusAnuncioHandler : Notifiable, IHandlerCommand<AlterarStatusAnuncioCommand>
    {
        private readonly IAnuncioRepository _repositorio;

        public AlterarStatusAnuncioHandler(IAnuncioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public ICommandResult Handle(AlterarStatusAnuncioCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se existe pacote
            var anuncio = _repositorio.BuscarPorId(command.IdAnuncio);

            if (anuncio == null)
                return new GenericCommandResult(false, "Anúncio não encontrado", null);

            anuncio.AlterarStatus(command.Status);

            if (anuncio.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", anuncio.Notifications);

            //Altera pacote banco
            _repositorio.Alterar(anuncio);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Anúncio alterado", null);
        }
    }
}
