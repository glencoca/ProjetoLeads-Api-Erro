using Microsoft.EntityFrameworkCore;
using ProjetoLeads.Comum.Enum;
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
    public class TipoAlteracaoRepositorio : ITipoAlteracaoRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public TipoAlteracaoRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void Adicionar(TipoAlteracao tipoAlteracao)
        {
            _context.TiposAlteracao.Add(tipoAlteracao);

            _context.SaveChanges();
        }

        public void Alterar(TipoAlteracao tipoAlteracao)
        {
            _context.Entry(tipoAlteracao).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public TipoAlteracao BuscarPorNome(EnTipoAlteracao nomeEnTipoAlteracao)
        {
            return _context.TiposAlteracao.FirstOrDefault(t => t.NomeTipoAlteracao == nomeEnTipoAlteracao);
        }

        public void Excluir(TipoAlteracao tipoAlteracao)
        {
            _context.TiposAlteracao.Remove(tipoAlteracao);

            _context.SaveChanges();
        }

        public ICollection<TipoAlteracao> Listar()
        {
            return _context.TiposAlteracao.ToList();
        }
    }
}
