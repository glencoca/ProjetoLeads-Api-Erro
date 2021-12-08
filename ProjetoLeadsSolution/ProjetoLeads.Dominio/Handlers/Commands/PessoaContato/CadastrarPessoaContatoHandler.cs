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
    class CadastrarPessoaContatoHandler : Notifiable<Notification>, IHandler<CadastrarPessoaContatoCommand>
    {
        private IPessoaContatoRepositorio _pessoaContatoRepositorio;

        public CadastrarPessoaContatoHandler(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            _pessoaContatoRepositorio = pessoaContatoRepositorio;
        }

        public ICommandResult Handler(CadastrarPessoaContatoCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso os dados sejam inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Criamos uma nova instância de PessoaContato
            var newPessoaContato = new Entidades.PessoaContato(command.Nome, command.Setor, command.IdEmpresa, command.IdRedesSociais, command.Imagem , command.Area, command.Cargo, command.DataInicio);

            //Se os dados forem inválidos, retornamos um erro
            if (!newPessoaContato.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Se não, cadastramos as informações no banco de dados
            _pessoaContatoRepositorio.CadastrarPessoaContato(newPessoaContato);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Nova pessoa contato cadastrada com sucesso", null);

        }
    }
}
