using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {



        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        void AlterarSenha(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        void ExcluirUsuarioPorId(Guid id);
        void AlterarSituacaoAtivo(Usuario usuario);

    }
}
