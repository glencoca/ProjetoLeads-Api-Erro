using ProjetoLeads.Comum.Enum;
using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface IHistoricoRepositorio
    {
        void AdicionarHistorico(Historico novoHistorico);

        Historico BuscarHistoricoPorId(Guid idHistorico);

        List<Historico> BuscarListaHistorico();
    }
}
