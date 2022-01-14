using Classificados.Comum.Commands;
using Classificados.Comum.Handlers;
using Classificados.Dominio.Commands.Anuncios;
using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers
{
    public class CriarAnuncioHandler : Notifiable, IHandlerCommand<CriarAnuncioCommand>
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public CriarAnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public ICommandResult Handle(CriarAnuncioCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do anúncio Inválidos", command.Notifications);
            //Futuramente Adicionar Moderador de Conteúdo

            //Salvar Anuncio
            var anuncio = new Anuncio(command.Titulo, command.Imagem, command.Descricao, command.Telefone, command.Preco,command.Categoria,command.Disponibilidade,command.Ativo, command.IdUsuario);
            if (!string.IsNullOrEmpty(command.Endereco))
                anuncio.AdicionarEndereco(command.Endereco);

            if (anuncio.Invalid)
                return new GenericCommandResult(false, "Anúncio Inválido", anuncio.Notifications);

            _anuncioRepository.Adicionar(anuncio);

            return new GenericCommandResult(true, "Anúncio Criado", anuncio);
        }
    }
}
