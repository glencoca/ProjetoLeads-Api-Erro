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
    class AlterarTipoStatusHandler : Notifiable<Notification>, IHandler<AlterarTipoStatusCommand>
    {
        private readonly ITipoStatusRepositorio _tipoStatusRepositorio;

        public AlterarTipoStatusHandler(ITipoStatusRepositorio tipoStatusRepositorio)
        {
            _tipoStatusRepositorio = tipoStatusRepositorio;
        }

        public ICommandResult Handler(AlterarTipoStatusCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso não seja válido, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Nome de tipo status inválido", command.Notifications);
            }

            //Verficamos a existência desse tipo status
            var tipoStatusBuscado = _tipoStatusRepositorio.BuscarPorNome(command.NomeTipoStatus);

            //Se não existir, retornamos um erro
            if (tipoStatusBuscado == null)
            {
                return new GenericCommandResult(false, "O tipo status não foi encontrado", command.Notifications);
            }

            //Caso exista, alteramos o nome desse tipo status
            tipoStatusBuscado.AlterarNomeTipoStatus(command.NomeTipoStatus);

            //Salvamos a alteração no banco
            _tipoStatusRepositorio.Alterar(tipoStatusBuscado);


            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Tipo status alterado com sucesso", null);
        }
    }
}
