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
    public class HistoricoRepositorio : IHistoricoRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public HistoricoRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void AdicionarHistorico(Historico novoHistorico)
        {
            _context.Historicos.Add(novoHistorico);
            _context.SaveChanges();
        }

        public Historico BuscarHistoricoPorId(Guid idHistorico)
        {
            return _context.Historicos.FirstOrDefault(c => c.Id == idHistorico);
        }

        public List<Historico> BuscarListaHistorico()
        {
            return _context.Historicos.ToList();
        }
    }
}
