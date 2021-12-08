using ProjetoLeads.Comum.Enum;
using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface ITipoStatusRepositorio
    {
        void Adicionar (TipoStatus tipoStatus);
        void Alterar (TipoStatus tipoStatus);
        void Excluir (Guid id);
        ICollection<TipoStatus> Listar();
        TipoStatus BuscarPorNome(EnTiposStatus nomeTipoStatus);
        TipoStatus BuscarPorId(Guid id);
    }
}
