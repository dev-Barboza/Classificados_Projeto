using Classificados.Comum.Entidades;
using Classificados.Dominio.Entidades;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Commands
{
    public class Reserva : Entidade
    {
        //public Reserva(Guid idUsuario, Guid idAnuncio)
        //{
        //    AddNotifications(new Contract()
        //      .Requires()
        //       .AreNotEquals(idUsuario, Guid.Empty, "IdUsuario", "Informe o Id do Usuário da reserva")
        //       .AreNotEquals(idAnuncio, Guid.Empty, "idAnuncio", "Informe o Id do Anuncio da reserva")
        //      );

        //    if (Valid)
        //    {
        //        IdUsuario = idUsuario;
        //        IdAnuncio = idAnuncio;
        //    }
        //}

        //private readonly List<Reserva> _reservas;
        //public Guid IdUsuario { get; private set; }
        //public virtual Usuario Usuario { get; private set; }

        //public Guid IdAnuncio { get; private set; }
        //public virtual Anuncio Anuncio { get; private set; }
        //public IReadOnlyCollection<Reserva> Reservas { get { return _reservas.ToArray(); } }
    }
}
