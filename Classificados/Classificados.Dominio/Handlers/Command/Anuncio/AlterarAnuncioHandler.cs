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

namespace Classificados.Dominio.Handlers.Command
{
    public class AlterarAnuncioHandler : Notifiable, IHandlerCommand<AlterarAnuncioCommand>
    {
        private readonly IAnuncioRepository _repositorio;

        public AlterarAnuncioHandler(IAnuncioRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public ICommandResult Handle(AlterarAnuncioCommand command)
        {
            //Fail Fast Validation
            //Aplicar as validações
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var anuncio = _repositorio.BuscarPorId(command.IdAnuncio);

            if (anuncio == null)
                return new GenericCommandResult(false, "Anúncio não encontrado", null);

            anuncio.AlterarAnuncio(command.Titulo, command.Imagem, command.Descricao, command.Telefone, command.Preco, command.Categoria, command.Disponibilidade);

            if (!string.IsNullOrEmpty(command.Endereco))
                anuncio.AdicionarEndereco(command.Endereco);

            if (anuncio.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", anuncio.Notifications);

            //Salvar usuario banco
            _repositorio.Alterar(anuncio);


            return new GenericCommandResult(true, "Anuncio alterado com Sucesso", null);
        }
    }
}

