using Classificados.Dominio.Entidades;
using Classificados.Dominio.Repositories;
using Classificados.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classificados.Infra.Data.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly ClassificadosContext _context;


        public AnuncioRepository(ClassificadosContext context)
        {
            _context = context;
        }

        public void Adicionar(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            _context.SaveChanges();
        }

        public void Alterar(Anuncio anuncio)
        {
            _context.Entry(anuncio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public Anuncio BuscarPorId(Guid id)
        {
            return _context.Anuncios.FirstOrDefault(u => u.Id == id);
        }

        public Anuncio BuscarPorPrecoCrescente(float preco)
        {
            return _context.Anuncios.FirstOrDefault(u => u.Preco == preco);
        }

        public Anuncio BuscarPorPrecoDecrescente(float preco)
        {
            return _context.Anuncios.FirstOrDefault(u => u.Preco == preco);
        }


        public IEnumerable<Anuncio> Listar(bool? ativo = null)
        {

            return _context.Anuncios;

        }

        IEnumerable<Anuncio> IAnuncioRepository.BuscarPorTitulo(string titulo)
        {
                return _context.Anuncios
                .Include(i => i._anuncios)
                  .Where(p => p.Titulo == titulo)
                  .OrderBy(x => x.DataCriacao);
        }


        public void Deletar(Guid id)
        {
            var anuncio = BuscarPorId(id);
            _context
                .Anuncios
                .Remove(anuncio);
            _context
                .SaveChanges();

        }
        
    }
}
