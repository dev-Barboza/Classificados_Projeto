using Classificados.Comum.Commands;
using Classificados.Comum.Enum;
using Classificados.Dominio.Commands.Anuncios;
using Classificados.Dominio.Handlers;
using Classificados.Teste.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Classificados.Teste.Handlers.Anuncio
{
    public class CriarAnuncioHandlerTestes
    {
        //[Fact]
        //public void DeveRetornarErroSeDadosHandlerPacoteInvalidos()
        //{
        //    // Criar um command
        //    var command = new CriarAnuncioCommand("TV", "lg.png", "Péssimo estado", "","11977376394", 1000, "Eletronicos", EnDisponibilidade.Unico);

        //    // Criar um Handle
        //    // Criar um Fake Repositorie
        //    // Ou podemos usar o mock
        //    var handle = new CriarAnuncioHandler(new FakeAnuncioRepository());

        //    // Pega o resultado
        //    var resultado = (GenericCommandResult)handle.Handle(command);

        //    //Valida a condição
        //    Assert.False(resultado.Sucesso, "O anúncio é válido");

        //}

        //[Fact]
        //public void DeveRetornarErroSeDadosHandlerValidos()
        //{
        //    //Criar um command
        //    var command = new CriarAnuncioCommand("TV", "lg.png", "Péssimo estado", "fgctg", "11977376394", 1000, "Eletronicos", EnDisponibilidade.Unico);

        //    //Criar um handle
        //    var handle = new CriarAnuncioHandler(new FakeAnuncioRepository()); // Criar um Fake Repositorie
        //                                                                     // Ou podemos usar o mock
        //                                                                     //Pega o resultado
        //    var resultado = (GenericCommandResult)handle.Handle(command);

        //    //Valida a condição
        //    Assert.False(resultado.Sucesso, "O usuario é inválido");


        //}

    }
}
