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
    public class EmpresaRepositorio : IEmpresaRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public EmpresaRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void AlterarImagem(Empresa empresaAtualizada)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Empresa empresaAtualizada)
        {
            _context.Entry(empresaAtualizada).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Empresa BuscarPorId(Guid idEmpresa)
        {
            return _context.Empresas.FirstOrDefault(e => e.Id == idEmpresa);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            _context.Empresas.Add(novaEmpresa);

            _context.SaveChanges();
        }

        public void Excluir(Empresa idEmpresa)
        {
            _context.Empresas.Remove(BuscarPorId(idEmpresa.Id));
            _context.SaveChanges();
        }
    }
}
