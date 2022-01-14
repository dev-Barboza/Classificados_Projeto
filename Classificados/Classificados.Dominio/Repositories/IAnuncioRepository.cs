using Classificados.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Dominio.Repositories
{
    public interface IAnuncioRepository
    {
        void Adicionar(Anuncio anuncio);
        void Alterar(Anuncio anuncio);
        Anuncio BuscarPorId(Guid id);
        void Deletar(Guid id);
        IEnumerable<Anuncio> BuscarPorTitulo(string titulo);
        Anuncio BuscarPorPrecoCrescente(float preco);
        Anuncio BuscarPorPrecoDecrescente(float preco);
        IEnumerable<Anuncio> Listar(bool? ativo = null);
    }
}
