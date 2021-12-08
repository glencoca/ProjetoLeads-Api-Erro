using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.TipoStatus;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.TipoStatus
{
    class ExcluirTipoStatusHandler : Notifiable<Notification>, IHandler<ExcluirTipoStatusCommand>
    {
        private readonly ITipoStatusRepositorio _tipoStatusRepositorio;

        public ExcluirTipoStatusHandler(ITipoStatusRepositorio tipoStatusRepositorio)
        {
            _tipoStatusRepositorio = tipoStatusRepositorio;
        }

        public ICommandResult Handler(ExcluirTipoStatusCommand command)
        {

            //Validamos os dados
            command.Validar();

            //Caso os dados não sejam válidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Buscamos pelo TipoStatus que será excluído
            var tipoStatusBuscado = _tipoStatusRepositorio.BuscarPorNome(command.NomeTipoStatus);

            //Se não encontrarmos, retornamos um eroo
            if (tipoStatusBuscado == null)
            {
                return new GenericCommandResult(false, "O tipo status não foi encontrado", command.Notifications);
            }

            //Caso dê tudo certo, removemos do banco de dados
            _tipoStatusRepositorio.Excluir(tipoStatusBuscado.Id);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "O tipo status foi excluído com sucesso", null);
        }
    }
}
