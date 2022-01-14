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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ClassificadosContext _context;

        public UsuarioRepository(ClassificadosContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Alterar(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarSenha(Usuario usuario)
        {

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);

        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(p => p.Id == id);

        }

       

        public ICollection<Usuario> Listar()
        {
            return _context.Usuarios
                    .AsNoTracking()
                    .Include(u => u.Anuncios)
                    .OrderBy(u => u.DataCriacao)
                    .ToList();

        }
    }
}
