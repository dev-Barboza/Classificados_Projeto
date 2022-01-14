using Classificados.Comum.Handlers;
using Classificados.Comum.Query;
using Classificados.Dominio.Queries.Anuncios;
using Classificados.Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Handlers.Queries.Anuncio
{
    public class BuscarAnuncioTituloHandler : IHandlerQuery<BuscarAnuncioTituloQuery>
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public BuscarAnuncioTituloHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
        public IQueryResult Handle(BuscarAnuncioTituloQuery query)
        {
            var anuncio = _anuncioRepository.BuscarPorTitulo(query.Titulo);

            var Anuncios = anuncio.Select(
               x =>
               {
                   return new ListarAnuncioQueryResult()
                   {

                       Id = x.Id,
                       Titulo = x.Titulo,
                       Descricao = x.Descricao,
                       Preco = x.Preco,
                       Categoria = x.Categoria,
                       Imagem = x.Imagem,
                       Ativo = x.Ativo,
                       Disponibilidade = x.Disponibilidade
                   };
               }
           );

            return new GenericQueryResult(true, "Anuncios encontrados", Anuncios);
        }

    }
}
