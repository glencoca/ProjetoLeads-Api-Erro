using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.TipoStatus
{
    public class AlterarCorTipoStatusCommand : Notifiable<Notification>, ICommand
    {

        public AlterarCorTipoStatusCommand()
        {

        }

        public AlterarCorTipoStatusCommand(string corTipoStatus)
        {
            CorTipoStatus = corTipoStatus;
        }


        public string CorTipoStatus { get; private set; }


        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(CorTipoStatus, "CorTipoStatus", "A propriedade CorTipoStatus não pode ser nula")
);
        }
    }
}
