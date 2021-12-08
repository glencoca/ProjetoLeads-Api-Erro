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
    public class TipoStatusRepositorio : ITipoStatusRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public TipoStatusRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void Adicionar(TipoStatus tipoStatus)
        {
            _context.TiposStatus.Add(tipoStatus);
            _context.SaveChanges();
        }

        public void Alterar(TipoStatus tipoStatus)
        {
            _context.Entry(tipoStatus).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TipoStatus BuscarPorNome(EnTiposStatus nomeTipoStatus)
        {
            return _context.TiposStatus.FirstOrDefault(x => x.NomeTipoStatus == nomeTipoStatus);
        }

        public void Excluir(Guid id)
        {
            _context.TiposStatus.Remove(BuscarPorId(id));

            _context.SaveChanges();
        }

        public TipoStatus BuscarPorId(Guid id)
        {
            return _context.TiposStatus.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<TipoStatus> Listar()
        {
            return _context.TiposStatus.ToList();
        }
    }
}
