using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Command.Anuncio
{
    public class AlterarImagemAnuncioCommand : Notifiable, ICommand
    {
        public AlterarImagemAnuncioCommand()
        {

        }

        public AlterarImagemAnuncioCommand(Guid idAnuncio, string imagem)
        {
            IdAnuncio = idAnuncio;
            Imagem = imagem;
        }

        public Guid IdAnuncio { get; set; }
        public string Imagem { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
               .Requires()
               .AreNotEquals(IdAnuncio, Guid.Empty, "IdAnuncio", "Id do usuário inválido")
               .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a imagem do anuncio")
           );
        }
    }
}
