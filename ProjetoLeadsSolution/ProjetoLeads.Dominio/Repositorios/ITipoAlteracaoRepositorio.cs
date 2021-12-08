using ProjetoLeads.Comum.Enum;
using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface ITipoAlteracaoRepositorio
    {
        void Adicionar(TipoAlteracao tipoAlteracao);
        void Alterar(TipoAlteracao tipoAlteracao);
        void Excluir(TipoAlteracao tipoAlteracao);
        ICollection<TipoAlteracao> Listar();
        TipoAlteracao BuscarPorNome(EnTipoAlteracao nomeEnTipoAlteracao);

    }
}
