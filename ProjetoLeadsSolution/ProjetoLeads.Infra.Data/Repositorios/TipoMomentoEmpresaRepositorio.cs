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
    public class TipoMomentoEmpresaRepositorio : ITipoMomentoEmpresaRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public TipoMomentoEmpresaRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void Adicionar(TipoMomentoEmpresa tipoMomentoEmpresa)
        {
            _context.TiposMomentoEmpresa.Add(tipoMomentoEmpresa);

            _context.SaveChanges();
        }

        public void Alterar(TipoMomentoEmpresa tipoMomentoEmpresa)
        {
            throw new NotImplementedException();
        }

        public TipoMomentoEmpresa BuscarPorNome(EnTipoMomentoEmpresa nomeTipoStatus)
        {
            return _context.TiposMomentoEmpresa.FirstOrDefault(t => t.NomeTipoMomentoCliente == nomeTipoStatus);
        }

        public void Excluir(TipoMomentoEmpresa tipoMomentoEmpresa)
        {
            _context.TiposMomentoEmpresa.Remove(BuscarPorNome(tipoMomentoEmpresa.NomeTipoMomentoCliente));

            _context.SaveChanges();
        }

        public ICollection<TipoMomentoEmpresa> Listar()
        {
            return _context.TiposMomentoEmpresa.ToList();
        }
    }
}
