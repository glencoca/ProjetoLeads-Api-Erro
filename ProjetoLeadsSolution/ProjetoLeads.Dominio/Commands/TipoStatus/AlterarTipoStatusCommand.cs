using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.TipoStatus
{
    public class AlterarTipoStatusCommand : Notifiable<Notification>, ICommand
    {
        public AlterarTipoStatusCommand()
        {

        }


        public AlterarTipoStatusCommand(Guid idUsuario, EnTiposStatus nomeTipoStatus)
        {
            IdUsuario = idUsuario;
            NomeTipoStatus = nomeTipoStatus;
        }

        public EnTiposStatus NomeTipoStatus { get; private set; }
        public Guid IdUsuario { get; private set; }


        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(NomeTipoStatus, "NomeTipoStatus", "O nome do tipo status não pode ser nulo")
            .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode ser nulo")
            );
        }
    }
}
