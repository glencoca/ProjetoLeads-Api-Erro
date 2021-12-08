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
    public class AlterarImagemHandler : Notifiable<Notification>, IHandler<AlterarImagemCommand>
    {
        private IPessoaContatoRepositorio _pessoaContatoRepositorio;

        public AlterarImagemHandler(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            _pessoaContatoRepositorio = pessoaContatoRepositorio;
        }


        public ICommandResult Handler(AlterarImagemCommand command)
        {
            command.Validar();

            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            var pessoaContatoBuscada = _pessoaContatoRepositorio.BuscarPorId(command.IdPessoaContato);

            if (pessoaContatoBuscada == null)
            {
                return new GenericCommandResult(false, "A pessoaContato não foi encontrada", command.Notifications);
            }


            pessoaContatoBuscada.AlterarImagem(command.Imagem);

            _pessoaContatoRepositorio.AlterarImagem(pessoaContatoBuscada);

            return new GenericCommandResult(true, "Imagem alterada com sucesso", null);
        }
    }
}
