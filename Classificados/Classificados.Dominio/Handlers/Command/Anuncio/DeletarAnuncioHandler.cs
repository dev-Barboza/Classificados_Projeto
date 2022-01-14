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
    public class DeletarAnuncioHandler : Notifiable, IHandlerCommand<DeletarAnuncioCommand>
    {
        private  IAnuncioRepository _anuncioRepository { get; set; }
        public DeletarAnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
        public ICommandResult Handle(DeletarAnuncioCommand command)
        {
            var anuncio = _anuncioRepository.BuscarPorId(command.IdAnuncio);

            if (anuncio == null)
                return new GenericCommandResult(false, "Anuncio não encontrado", null);

            _anuncioRepository.Deletar(anuncio.Id);

            return new GenericCommandResult(true, "Anuncio deletado com sucesso", null);
        }
    }
}
