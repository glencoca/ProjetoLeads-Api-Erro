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
    public class AdicionarTipoStatusHandler : Notifiable<Notification>, IHandler<CriarTipoStatusCommand>
    {
        private readonly ITipoStatusRepositorio _tipoStatusRepositorio;

        public AdicionarTipoStatusHandler(ITipoStatusRepositorio tipoStatusRepositorio)
        {
            _tipoStatusRepositorio = tipoStatusRepositorio;
        }

        public ICommandResult Handler(CriarTipoStatusCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso os dados sejam inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência de um tipo staus com o mesmo nome
            var tipoStatusExiste = _tipoStatusRepositorio.BuscarPorNome(command.NomeTipoStatus);

            //Caso exista, retornamos um erro
            if (tipoStatusExiste != null)
            {
                return new GenericCommandResult(false, "TipoStatus já existente", command.Notifications);
            }

            //Caso contrário, criamos um novo
            var newTipoStatus = new Entidades.TipoStatus(command.NomeTipoStatus, command.CorTipoStatus);

            //Se os dados forem inválidos, retornamos um erro
            if (!newTipoStatus.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Salvamos no banco
            _tipoStatusRepositorio.Adicionar(newTipoStatus);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Novo tipo status cadastrado com sucesso", null);
        }
    }
}
