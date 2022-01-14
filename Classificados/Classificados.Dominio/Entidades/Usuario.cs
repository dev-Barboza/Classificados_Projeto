using Classificados.Comum.Entidades;
using Classificados.Comum.Enum;
using Classificados.Dominio.Commands;
using Flunt.Br.Extensions;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Classificados.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public Usuario(string nome, string email, string senha, string cPF, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(nome, 40, "Nome", "Nome deve conter no máximo 40 caracteres.")
                .IsEmail(email, "Email", "Informe um e-mail válido")
                .HasMinLen(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres.")
                .HasMinLen(cPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
                .HasMaxLen(cPF, 14, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
            );

            if (Valid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;

                CPF = cPF;
                TipoUsuario = tipoUsuario;
            }
        }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public string Senha { get;  set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public EnTipoUsuario TipoUsuario { get;  set; }
        //public IReadOnlyCollection<name> name { get; set; }
        public List<Anuncio> Anuncios { get; set; }

        public void AdicionarTelefone(string telefone)
        {

            AddNotifications(new Contract()
                .Requires()
                .IsNewFormatCellPhone(telefone, "Telefone", "Informe um telefone válido")
            );
            if (Valid)
                Telefone = telefone;
        }
        public void AlterarSenha(string senha)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(senha, 6, "Senha", "Senha deve ter no minímo 6 caracteres.")
                .HasMaxLen(senha, 12, "Senha", "Senha deve ter no máximo 12 caracteres.")
        );
            if (Valid)
                Senha = senha;
        }
        public void AlterarUsuario(string nome, string email)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(nome, 3, "Nome", "Nome deve conter pelo menos 3 caracteres.")
                .HasMaxLen(nome, 40, "Nome", "Nome deve conter no máximo 40 caracteres.")
                .IsEmail(email, "Email", "Informe um e-mail válido")

        );
            if (Valid)
            {
                Nome = nome;
                Email = email;
            }
        }
        public void AlterarCpf(string cPF)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(cPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
                .HasMaxLen(cPF, 11, "CPF", "O seu numero de CPF deve conter no minimo e no maximo 11 digitos.")
        );
            if (Valid)
            {
                CPF = cPF;
            }
        }
    }
}
