using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Reunião
{
    public class ListarReuniaoCommand : Notifiable<Notification>, ICommand
    {
        public ListarReuniaoCommand()
        {

        }

        public ListarReuniaoCommand(Guid idUsuario, Guid idReuniao)
        {
            IdUsuario = idUsuario;
            IdReuniao = idReuniao;
        }

        public Guid IdUsuario { get; private set; }
        public Guid IdReuniao { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
           .Requires()
           .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
           .IsNotNull(IdReuniao, "IdReuniao", "O ID da Reunião não pode estar vazio")
           );
        }
    }
}
