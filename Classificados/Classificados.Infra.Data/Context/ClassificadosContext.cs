using Classificados.Dominio.Commands;
using Classificados.Dominio.Entidades;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Infra.Data.Context
{
    public class ClassificadosContext  : DbContext
    {
        public ClassificadosContext(DbContextOptions<ClassificadosContext> options) :
           base(options)
        {

        }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ignorar notifictaions
            modelBuilder.Ignore<Notification>();

            // Configurar minha tabela desejada
            #region Anuncios
            modelBuilder.Entity<Anuncio>().ToTable("Anuncios");
            modelBuilder.Entity<Anuncio>().Property(x => x.Id);

            //Titulo
            modelBuilder.Entity<Anuncio>().Property(x => x.Titulo).HasMaxLength(40);
            modelBuilder.Entity<Anuncio>().Property(x => x.Titulo).HasColumnType("varchar(40)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Titulo).IsRequired();

            //Imagem
            modelBuilder.Entity<Anuncio>().Property(x => x.Imagem).HasMaxLength(200);
            modelBuilder.Entity<Anuncio>().Property(x => x.Imagem).HasColumnType("varchar(200)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Imagem).IsRequired();

            //Descricao
            modelBuilder.Entity<Anuncio>().Property(x => x.Descricao).HasMaxLength(200);
            modelBuilder.Entity<Anuncio>().Property(x => x.Descricao).HasColumnType("varchar(200)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Descricao).IsRequired();

            //Telefone
            modelBuilder.Entity<Anuncio>().Property(x => x.Telefone).HasMaxLength(100);
            modelBuilder.Entity<Anuncio>().Property(x => x.Telefone).HasColumnType("varchar(100)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Telefone).IsRequired();

            //Endereco
            modelBuilder.Entity<Anuncio>().Property(x => x.Endereco).HasMaxLength(100);
            modelBuilder.Entity<Anuncio>().Property(x => x.Endereco).HasColumnType("varchar(100)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Endereco).IsRequired();

            //Preco
            modelBuilder.Entity<Anuncio>().Property(x => x.Preco).HasMaxLength(200);
            modelBuilder.Entity<Anuncio>().Property(x => x.Preco).HasColumnType("varchar(200)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Preco).IsRequired();

            //Categoria
            modelBuilder.Entity<Anuncio>().Property(x => x.Categoria).HasMaxLength(100);
            modelBuilder.Entity<Anuncio>().Property(x => x.Categoria).HasColumnType("varchar(100)");
            modelBuilder.Entity<Anuncio>().Property(x => x.Categoria).IsRequired();

            //Ativo
            modelBuilder.Entity<Anuncio>().Property(x => x.Ativo).HasColumnType("bit");
            //Disponibilidade
            modelBuilder.Entity<Anuncio>().Property(x => x.Disponibilidade).HasColumnType("int");


            //DataCriacao
            modelBuilder.Entity<Anuncio>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Anuncio>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<Anuncio>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Anuncio>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            
            #endregion


            #region Mapeamento Tabela Usuários
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(60);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(60)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();

            //Telefone
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasMaxLength(11);
            modelBuilder.Entity<Usuario>().Property(x => x.Telefone).HasColumnType("varchar(11)");

            //CPF
            modelBuilder.Entity<Usuario>().Property(x => x.CPF).HasMaxLength(100);
            modelBuilder.Entity<Usuario>().Property(x => x.CPF).HasColumnType("varchar(100)");


            //Relacionamento de 1 para muitos
            modelBuilder.Entity<Usuario>()
                
               .HasMany(c => c.Anuncios)
               .WithOne(u => u.Usuario)
               .HasForeignKey(fk => fk.IdUsuario);

            //modelBuilder.Entity<Usuario>()
            //    .HasMany(c => c.Anuncios)
            //    .WithOne(u => u.Usuario)
            //    .HasForeignKey(fk => fk.IdUsuario);


            //DataCriacao
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataCriacao).HasDefaultValueSql("GetDate()");

            //DataAlteracao
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Usuario>().Property(t => t.DataAlteracao).HasDefaultValueSql("GetDate()");


            #endregion
     
            base.OnModelCreating(modelBuilder);
        }
    }
}
