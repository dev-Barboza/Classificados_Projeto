using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Anuncios
{
    public class AlterarStatusAnuncioCommand : Notifiable, ICommand
    {
        public AlterarStatusAnuncioCommand()
        {

        }

        public AlterarStatusAnuncioCommand(Guid idAnuncio, bool status)
        {
            IdAnuncio = idAnuncio;
            Status = status;
        }

        public Guid IdAnuncio { get; set; }
        public bool Status { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdAnuncio, Guid.Empty, "IdAnuncio", "Id do anúncio inválido")
           );
        }
    }
}

