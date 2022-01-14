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
    public class ListarAnuncioHandler : IHandlerQuery<ListarAnuncioQuery>
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public ListarAnuncioHandler(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }
        public IQueryResult Handle(ListarAnuncioQuery query)
        {
            var anuncio = _anuncioRepository.Listar(query.Ativo);

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
                        Disponibilidade = x.Disponibilidade,
                        Endereco = x.Endereco



                    };
                }
            );
            return new GenericQueryResult(true, "Lista de Anuncios", Anuncios);
        }
    }
}
