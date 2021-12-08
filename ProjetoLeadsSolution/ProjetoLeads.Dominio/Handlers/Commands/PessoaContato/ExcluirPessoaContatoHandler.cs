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
    class ExcluirPessoaContatoHandler : Notifiable<Notification>, IHandler<ExcluirPessoaContatoCommand>
    {
        private IPessoaContatoRepositorio _pessoaContatoRepositorio;

        public ExcluirPessoaContatoHandler(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            _pessoaContatoRepositorio = pessoaContatoRepositorio;
        }

        public ICommandResult Handler(ExcluirPessoaContatoCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso não sejam válidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência da PessoaContato
            var pessoaContatoBuscada = _pessoaContatoRepositorio.BuscarPorId(command.IdPessoaContato);

            //Se não existir, retornamos um erro
            if (pessoaContatoBuscada == null)
            {
                return new GenericCommandResult(false, "A pessoa contato não foi encontrada", command.Notifications);
            }

            //Caso exista, removemos do banco de dados
            _pessoaContatoRepositorio.ExcluirPessoaContato(command.IdPessoaContato);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "A pessoa contato foi excluída com sucesso", null);
        }
    }
}
