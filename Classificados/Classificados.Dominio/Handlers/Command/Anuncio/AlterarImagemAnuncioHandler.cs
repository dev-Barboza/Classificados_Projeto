using Classificados.Comum.Commands;
using Classificados.Comum.Handlers;
using Classificados.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Command.Anuncio
{
    public class AlterarImagemAnuncioHandler : Notifiable, IHandlerCommand<AlterarImagemAnuncioCommand>
    {
        private readonly IAnuncioRepository _repositorio;

        public AlterarImagemAnuncioHandler(IAnuncioRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(AlterarImagemAnuncioCommand command)
        {
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var anuncio = _repositorio.BuscarPorId(command.IdAnuncio);

            if (anuncio == null)
                return new GenericCommandResult(false, "Anuncio não encontrado", null);

            anuncio.AlterarImagem(command.Imagem);

            if (anuncio.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", anuncio.Notifications);

            //Salvar usuario banco
            _repositorio.Alterar(anuncio);

            //Enviar email de boas vindas

            return new GenericCommandResult(true, "Anuncio alterado", null);
        }
    }
}
