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
    public class LogarCommand : Notifiable, ICommand
    {
        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
             .Requires()
             .IsEmail(Email, "Email", "Informe um e-mail válido")
             .HasMinLen(Senha, 6, "Nome", "A senha deve ter pelo menos 6 caracteres")
                );
        }

    }
}
