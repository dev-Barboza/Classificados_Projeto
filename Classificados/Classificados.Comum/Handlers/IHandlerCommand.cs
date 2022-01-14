
using Classificados.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Comum.Handlers
{
    public interface IHandlerCommand<T> where T : ICommand
    {
        // Para que retorne uma resposta
        ICommandResult Handle(T command);
    }
}
