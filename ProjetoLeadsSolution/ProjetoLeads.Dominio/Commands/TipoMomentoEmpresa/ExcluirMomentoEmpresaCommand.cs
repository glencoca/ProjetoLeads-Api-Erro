using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.TipoMomentoEmpresa
{
    public class ExcluirMomentoEmpresaCommand : Notifiable<Notification>, ICommand
    {
        public ExcluirMomentoEmpresaCommand()
        {

        }

        public ExcluirMomentoEmpresaCommand(EnTipoMomentoEmpresa nomeTipoMomentoCliente, Guid idUsuario)
        {
            NomeTipoMomentoCliente = nomeTipoMomentoCliente;
            IdUsuario = idUsuario;
        }


        public EnTipoMomentoEmpresa NomeTipoMomentoCliente { get; private set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(NomeTipoMomentoCliente, "NomeTipoMomentoCliente", "O tipo momento cliente não pode ser nulo")
            .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode ser nulo")
            );
        }
    }
}
