using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Repositorios
{
    public interface IPessoaContatoRepositorio
    {
        void CadastrarPessoaContato(PessoaContato novaPessoaContato);
        List<PessoaContato> ListarPessoaContato();
        PessoaContato BuscarPorId(Guid idPessoaContato);
        void AtualizarPessoaContato(PessoaContato pessoaContatoAtualizada);
        void MudarEmpresaPessoaContato(PessoaContato pessoaContatoAtualizada);
        void ExcluirPessoaContato(Guid idPessoaContato);
        void AlterarImagem(PessoaContato pessoaContato);

    }
}
