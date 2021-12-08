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
    public class PontuacaoRepositorio : IPontuacaoRepositorio
    {

        //Injeção de dependencia
        private readonly ProjetoLeadsContext _context;

        public PontuacaoRepositorio(ProjetoLeadsContext context)
        {
            _context = context;
        }

        public void Atualizar(Pontuacao pontuacaoAtualizada)
        {
            _context.Entry(pontuacaoAtualizada).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public Pontuacao BuscarPorId(Guid IdPontuacao)
        {
            return _context.Pontuacoes.FirstOrDefault(p => p.Id == IdPontuacao);
        }
    }
}
