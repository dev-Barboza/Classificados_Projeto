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
    public class AlterarTituloAnuncioCommand : Notifiable, ICommand
    {
        public AlterarTituloAnuncioCommand()
        {

        }

        public AlterarTituloAnuncioCommand(Guid idAnuncio, string titulo)
        {
            IdAnuncio = idAnuncio;
            Titulo = titulo;
        }

        public Guid IdAnuncio { get; set; }
        public string Titulo  { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdAnuncio, Guid.Empty, "IdAnuncio", "Id do usuário inválido")
               .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o titulo do anuncio")
           );
        }
    }
}
