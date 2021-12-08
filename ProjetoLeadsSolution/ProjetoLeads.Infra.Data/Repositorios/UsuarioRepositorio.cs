using Microsoft.EntityFrameworkCore;
using ProjetoLeads.Dominio.Entidades;
using ProjetoLeads.Dominio.Repositorios;
using ProjetoLeads.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Infra.Data.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public UsuarioRepositorio(ProjetoLeadsContext context)
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
            _context.Entry(usuario.Senha).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public void AlterarSituacaoAtivo(Usuario usuario)
        {
            _context.Entry(usuario.Ativo).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public Usuario BuscarPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public Usuario BuscarPorId(Guid id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void ExcluirUsuarioPorId(Guid id)
        {
            _context.Usuarios.Remove(BuscarPorId(id));

            _context.SaveChanges();
        }
    }
}
