using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface IEmpresaRepositorio
    {

        void Cadastrar (Empresa novaEmpresa);
        void Excluir (Empresa idEmpresa);
        void Atualizar (Empresa empresaAtualizada);
        Empresa BuscarPorId (Guid idEmpresa);
        void AlterarImagem(Empresa empresaAtualizada);

    }
}
