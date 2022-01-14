using Classificados.Comum.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Comum.Handlers
{
    public interface IHandlerQuery<T> where T : IQuery
    {
        IQueryResult Handle(T query);
    }
}
