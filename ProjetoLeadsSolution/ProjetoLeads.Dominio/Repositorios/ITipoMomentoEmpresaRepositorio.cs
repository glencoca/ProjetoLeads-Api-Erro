using ProjetoLeads.Comum.Enum;
using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface ITipoMomentoEmpresaRepositorio
    {
        void Adicionar(TipoMomentoEmpresa tipoMomentoEmpresa);
        void Alterar(TipoMomentoEmpresa tipoMomentoEmpresa);
        void Excluir(TipoMomentoEmpresa tipoMomentoEmpresa);
        ICollection<TipoMomentoEmpresa> Listar();
        TipoMomentoEmpresa BuscarPorNome(EnTipoMomentoEmpresa nomeTipoStatus);

    }
}
