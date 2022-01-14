using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Comum.Commands
{
    public interface ICommand
    {
        // Para toda vez que o ICommand for herdado ele fará uma validação do meu comando
        void Validar();
    }
}
