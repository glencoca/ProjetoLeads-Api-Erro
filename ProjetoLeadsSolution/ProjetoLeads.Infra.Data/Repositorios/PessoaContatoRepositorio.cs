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
    public class PessoaContatoRepositorio : IPessoaContatoRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public PessoaContatoRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void AlterarImagem(PessoaContato pessoaContato)
        {
            throw new NotImplementedException();
        }

        public void AtualizarPessoaContato(PessoaContato pessoaContatoAtualizada)
        {
            _context.Entry(pessoaContatoAtualizada).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public PessoaContato BuscarPorId(Guid idPessoaContato)
        {
            return _context.PessoasContato.FirstOrDefault(c => c.Id == idPessoaContato);
        }

        public void CadastrarPessoaContato(PessoaContato novaPessoaContato)
        {
            _context.PessoasContato.Add(novaPessoaContato);

            _context.SaveChanges();
        }

        public void ExcluirPessoaContato(Guid idPessoaContato)
        {
            _context.PessoasContato.Remove(BuscarPorId(idPessoaContato));
        }

        public List<PessoaContato> ListarPessoaContato()
        {
            return _context.PessoasContato.ToList();
        }

        public void MudarEmpresaPessoaContato(PessoaContato pessoaContatoAtualizada)
        {
            _context.Entry(pessoaContatoAtualizada.Empresa).State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
