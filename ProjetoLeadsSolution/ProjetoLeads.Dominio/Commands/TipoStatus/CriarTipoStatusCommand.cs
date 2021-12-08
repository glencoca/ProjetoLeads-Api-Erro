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
    public class CriarTipoStatusCommand : Notifiable<Notification>, ICommand
    {

        public CriarTipoStatusCommand()
        {

        }


        public CriarTipoStatusCommand(Guid idUsuario, EnTiposStatus nomeTipoSatus, string corTipoStatus)
        {
            IdUsuario = idUsuario;
            NomeTipoStatus = nomeTipoSatus;
            CorTipoStatus = corTipoStatus;
        }

        public EnTiposStatus NomeTipoStatus { get; private set; }
        public Guid IdUsuario { get; private set; }
        public string CorTipoStatus { get; set; }

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
