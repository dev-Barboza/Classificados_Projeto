using Classificados.Comum.Enum;
using Classificados.Comum.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Queries.Usuario
{
    public class ListarUsuarioQuery : IQuery
    {
        public void Validar()
        {

        }

        public class ListarUsuarioQueryResult
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string CPF { get; set; }
            public EnTipoUsuario TipoUsuario { get; set; }
        }
    }
}
