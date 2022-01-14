using Classificados.Comum.Handlers;
using Classificados.Comum.Query;
using Classificados.Dominio.Queries.Anuncios;
using Classificados.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Classificados.Dominio.Handlers.Queries.Usuario.ListarUsuarioQuery;

namespace Classificados.Dominio.Handlers.Queries.Usuario
{
    public class ListarUsuarioHandler : IHandlerQuery<ListarUsuarioQuery>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public ListarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public IQueryResult Handle(ListarUsuarioQuery query)
        {
            var usuario = _usuarioRepository.Listar();

            var Usuarios = usuario.Select(
                x =>
                {
                    return new ListarUsuarioQueryResult()
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        Telefone = x.Telefone,
                        CPF = x.CPF,
                        TipoUsuario = x.TipoUsuario


                    };
                }
            );
            return new GenericQueryResult(true, "Lista de Usuarios", Usuarios);
        }
    }
}
