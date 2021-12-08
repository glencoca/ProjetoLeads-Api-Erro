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
    public class ExcluirEmpresaCommand : Notifiable<Notification>, ICommand
    {

        public ExcluirEmpresaCommand()
        {

        }

        public ExcluirEmpresaCommand(Guid idEmpresa, Guid idUsuario)
        {
            IdEmpresa = idEmpresa;
            IdUsuario = idUsuario;
        }

        public Guid IdEmpresa { get; private set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .IsNotNull(IdEmpresa, "A propriedade IdEmpresa não pode ser nula")
                .IsNotNull(IdUsuario, "A propriedade IdUsuario não pode ser nula")
            );
        }
    }
}
