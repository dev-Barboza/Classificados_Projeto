using Classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Repositories
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="usuario">dados do usuario</param>
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        void AlterarSenha(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        ICollection<Usuario> Listar();
    }
}
