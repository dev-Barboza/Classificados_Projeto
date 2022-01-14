using Classificados.Dominio.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Repositories
{
    public interface IReservaRepository
    {
        void Cadastrar(Reserva reserva);
        Reserva BuscarPorId(Guid id);
        ICollection<Reserva> Listar();
    }
}
