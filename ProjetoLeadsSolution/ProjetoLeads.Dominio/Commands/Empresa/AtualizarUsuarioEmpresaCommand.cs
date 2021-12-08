using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Empresa
{
    class AtualizarUsuarioEmpresaCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarUsuarioEmpresaCommand()
        {

        }

        public AtualizarUsuarioEmpresaCommand(Guid idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
           );
        }
    }
}
