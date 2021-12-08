using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.PessoaContato;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.PessoaContato
{
    class MudarEmpresaPessoaContatoHandler : Notifiable<Notification>, IHandler<MudarEmpresaPessoaContatoCommand>
    {
        private IPessoaContatoRepositorio _pessoaContatoRepositorio;

        public MudarEmpresaPessoaContatoHandler(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            _pessoaContatoRepositorio = pessoaContatoRepositorio;
        }

        public ICommandResult Handler(MudarEmpresaPessoaContatoCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Se os dados forem inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência da pessoa contato
            var pessoaContatoBuscado = _pessoaContatoRepositorio.BuscarPorId(command.IdPessoaContato);

            //Se não existir, retornamos um erro
            if (pessoaContatoBuscado == null)
            {
                return new GenericCommandResult(false, "PessoaContato não foi encontrado", command.Notifications);
            }

            //Validamos novamente os dados
            pessoaContatoBuscado.MudarEmpresaPessoaContato(command.IdPessoaContato, command.IdEmpresa, command.DataInicio);

            //Se forem inválidos, retornamos uma mensagem de erro
            if (!pessoaContatoBuscado.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos, não foi possível mudar a empresa", command.Notifications);
            }

            //Estando de acordo, salvamos no banco de dados
            _pessoaContatoRepositorio.MudarEmpresaPessoaContato(pessoaContatoBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "A mudança de empresa da pessoa contato foi realizada com sucesso", null);
        }
    }
}
