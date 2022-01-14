using Classificados.Comum.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Usuarios
{
    public class ResetarSenhaCommand : Notifiable, ICommand
    {
        public ResetarSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um email válido")
                );
        }
    }
}
