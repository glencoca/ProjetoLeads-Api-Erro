using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Usuario
{
    public class ExcluirUsuarioCommand : Notifiable<Notification>, ICommand
    {

        public ExcluirUsuarioCommand()
        {

        }

        public ExcluirUsuarioCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

           public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(IdUsuario, "IdUsuario", "O Id do usuário não pode estar vazio")
            );
        }
    }
}
