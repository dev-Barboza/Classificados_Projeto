using Classificados.Comum.Commands;
using Classificados.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands.Anuncios
{
    public class AlterarAnuncioCommand : Notifiable, ICommand
    {
        public AlterarAnuncioCommand()
        {

        }

        public Guid IdAnuncio { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Descricao { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public float Preco { get; set; }
        public string Categoria { get; set; }
        //public Guid IdUsuario { get; private set; }
        //public virtual Usuario Usuario { get; private set; }
        public EnDisponibilidade Disponibilidade { get; set; }

        public void Validar()
        {
            AddNotifications(new Contract()
             .Requires()
             .HasMinLen(Titulo, 3, "Titulo", "O nome deve ter pelo menos 3 caracteres")
             .HasMaxLen(Titulo, 40, "Titulo", "O nome deve ter no máximo 40 caracteres")
             .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do produto")
             .HasMaxLen(Descricao, 200, "Descricao", "Informe o Descrição do anuncio")
             .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a descricao do produto")
             .IsNotNullOrEmpty(Categoria, "Categoria", "Informe uma categoria ao produto")
             .IsNotNullOrEmpty(Telefone, "Telefone", "Informe um contato")
             .HasMinLen(Telefone, 11, "Titulo", "O telefone deve ter pelo menos 11 caracteres")
             );
        }
    }
}
