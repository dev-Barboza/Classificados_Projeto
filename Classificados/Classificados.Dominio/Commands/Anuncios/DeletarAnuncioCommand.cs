using Classificados.Comum.Commands;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Anuncios
{
    public class DeletarAnuncioCommand : Notifiable, ICommand
    {
        public void Validar()
        {
            
        }

        public Guid IdAnuncio { get; set; }


    }
}
