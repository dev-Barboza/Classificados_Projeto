using Classificados.Comum.Commands;
using Classificados.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Usuarios
{
    public class CriarContaCommand : Notifiable, ICommand
    {
        public CriarContaCommand()
        {

        }
        public CriarContaCommand(string nome, string email, string senha, string telefone, string cPF, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            CPF = cPF;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public EnTipoUsuario TipoUsuario { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(Nome, 40, "Nome", "Nome deve conter no máximo 40 caracteres.")
                .IsEmail(Email, "Email", "Informe um e-mail válido")
                .HasMinLen(Senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres.")
                .HasMinLen(CPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
                .HasMaxLen(CPF, 15, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
            );
        }
    }
}
