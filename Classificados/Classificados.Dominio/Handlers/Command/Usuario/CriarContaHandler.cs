using Classificados.Comum.Commands;
using Classificados.Comum.Handlers;
using Classificados.Comum.Util;
using Classificados.Dominio.Commands.Usuarios;
using Classificados.Dominio.Repositories;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Command.Usuario
{
    public class CriarContaHandler : Notifiable, IHandlerCommand<CriarContaCommand>
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public CriarContaHandler(IUsuarioRepository usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(CriarContaCommand command)
        {
            // Validar Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do usuário Inválidos", command.Notifications);

            //Verifica se email existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);


            //Criptografar Senha 
            command.Senha = Senha.Criptografar(command.Senha);

            //Salvar Usuário
            var usuario = new Entidades.Usuario(command.Nome, command.Email, command.Senha, command.CPF, command.TipoUsuario);
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if (usuario.Invalid)
                return new GenericCommandResult(false, "Usuário Inválido", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);
            //Enviar Email de Boas Vindas
            //Send Grid

            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
