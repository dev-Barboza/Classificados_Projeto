using Classificados.Comum.Entidades;
using Classificados.Comum.Enum;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Entidades
{
   public class Anuncio : Entidade
    {
        public Anuncio(string titulo, string imagem, string descricao, string telefone, float preco, string categoria, EnDisponibilidade disponibilidade, bool ativo, Guid idUsuario)
        {
            AddNotifications(new Contract()
              .Requires()
              .HasMinLen(titulo, 3, "Titulo", "O nome deve ter pelo menos 3 caracteres")
              .HasMaxLen(titulo, 40, "Titulo", "O nome deve ter no máximo 40 caracteres")
              .IsNotNullOrEmpty(imagem, "Imagem", "Informe o Imagem do produto")
              .HasMaxLen(descricao, 200, "Descricao", "Informe o Descrição do anuncio")
              .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descricao do produto")
              .IsNotNullOrEmpty(categoria, "Categoria", "Informe uma categoria ao produto")
              .IsNotNullOrEmpty(telefone, "Telefone", "Informe um contato")
              .HasMinLen(telefone, 11, "Titulo", "O telefone deve ter pelo menos 11 caracteres")
              );

           if(Valid)
            {
                Titulo = titulo;
                Imagem = imagem;
                Descricao = descricao;
                Telefone = telefone;
                Preco = preco;
                Categoria = categoria;
                Disponibilidade = disponibilidade;
                Ativo = ativo;
                IdUsuario = idUsuario;
            }
        }

        public List<Anuncio> _anuncios { get; }
        public string Titulo{ get; private set; }
        public string Imagem { get; private set; }
        public string Descricao { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
        public float Preco { get; private set; }
        public bool Ativo { get; set; }
        public string Categoria { get; private set; }
        //public Guid IdUsuario { get; private set; }
        //public virtual Usuario Usuario { get; private set; }
        public EnDisponibilidade Disponibilidade { get; private set; }
        public Guid IdUsuario { get;  set; }
        public virtual Usuario Usuario { get; private set; }


        public void AdicionarEndereco(string endereco)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(endereco, "Endereco", "Informe o endereco do anuncio")
                );
            if (Valid)
                Endereco = endereco;
        }
        public void AlterarAnuncio(string titulo, string imagem, string descricao, string telefone, float preco, string categoria, EnDisponibilidade disponibilidade)
        {
            AddNotifications(new Contract()
                 .Requires()
                 .HasMinLen(titulo, 3, "Titulo", "O nome deve ter pelo menos 3 caracteres")
                 .HasMaxLen(titulo, 40, "Titulo", "O nome deve ter no máximo 40 caracteres")
                 .IsNotNullOrEmpty(imagem, "Imagem", "Informe o Imagem do produto")
                 .HasMaxLen(descricao, 200, "Descricao", "Informe o Descrição do anuncio")
                 .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descricao do produto")
                 .IsNotNullOrEmpty(categoria, "Categoria", "Informe uma categoria ao produto")
                 .IsNotNullOrEmpty(telefone, "Telefone", "Informe um contato")
                 .HasMinLen(telefone, 11, "Titulo", "O telefone deve ter pelo menos 11 caracteres")
                 );
            if (Valid)
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Telefone = telefone;
            Preco = preco;
            Categoria = categoria;
            Disponibilidade = disponibilidade;
        }


        public void AtivarAnuncio()
        {
            Ativo = true;
        }

        public void DesativarAnuncio()
        {
            Ativo = false;
        }

        public void AlterarStatus(bool ativo)
        {
            Ativo = ativo;
        }

        public void AlterarImagem(string imagem)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe a imagem do anuncio")
            );

            if (Valid)
                Imagem = imagem;
        }

        public void AlterarTitulo(string titulo)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Imagem", "Informe a titulo do anuncio")
            );

            if (Valid)
                Titulo = titulo;
        }

    }
}
