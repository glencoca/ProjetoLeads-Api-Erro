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
    class AtualizarPessoaContatoHandler : Notifiable<Notification>, IHandler<AtualizarPessoaContatoCommand>
    {
        private readonly IPessoaContatoRepositorio _pessoaContatoRepositorio;

        public AtualizarPessoaContatoHandler(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            _pessoaContatoRepositorio = pessoaContatoRepositorio;
        }

        public ICommandResult Handler(AtualizarPessoaContatoCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            var pessoaContatoBuscado = _pessoaContatoRepositorio.BuscarPorId(command.IdPessoaContato);

            if (pessoaContatoBuscado == null)
            {
                return new GenericCommandResult(false, "PessoaContato não foi encontrado", command.Notifications);
            }

            pessoaContatoBuscado.AtualizarPessoaContato(command.Nome, command.Setor, command.IdRedesSociais, command.Area, command.Cargo);

            if (!pessoaContatoBuscado.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos, não foi possível atualizar a pessoa contato", command.Notifications);
            }

            _pessoaContatoRepositorio.AtualizarPessoaContato(pessoaContatoBuscado);

            return new GenericCommandResult(true, "A pessoa contato foi atualizada com sucesso", null);
        }
    }
}
