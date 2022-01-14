using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Reservas
{
    public class CadastrarReservaCommand : Notifiable, ICommand
    {
        public CadastrarReservaCommand()
        {

        }

        public CadastrarReservaCommand(Guid idUsuario, Guid idAnuncio)
        {
            IdUsuario = idUsuario;
            IdAnuncio = idAnuncio;
        }

        public Guid IdUsuario { get; set; }
        public Guid IdAnuncio { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário do comentário")
                .AreNotEquals(IdAnuncio, Guid.Empty, "IdPacote", "Informe o Id do Pacote do comentário")
            );
        }
    }

}
