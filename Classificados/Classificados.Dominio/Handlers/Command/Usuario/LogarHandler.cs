using Classificados.Comum.Commands;
using Classificados.Comum.Handlers;
using Classificados.Comum.Util;
using Classificados.Dominio.Commands.Usuarios;
using Classificados.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Command.Usuario
{
    public class LogarHandler : IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public LogarHandler(IUsuarioRepository repositorio)
        {
            _usuarioRepositorio = repositorio;
        }
        public ICommandResult Handle(LogarCommand command)
        {
            //Comand é valido
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Buscar usuario pelo email
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            //Usuario existe
            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Validar Senha
            if (!Senha.ValidarSenha(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            //retorna true com os dados do usuário
            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
