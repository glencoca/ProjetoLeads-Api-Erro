using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface IPontuacaoRepositorio
    {

        void Atualizar(Pontuacao pontuacaoAtualizada);
        Pontuacao BuscarPorId(Guid IdPontuacao);

    }
}
