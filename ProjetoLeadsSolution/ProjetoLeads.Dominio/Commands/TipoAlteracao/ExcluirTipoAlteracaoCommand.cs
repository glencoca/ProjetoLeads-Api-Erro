using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.TipoAlteracao
{
    public class ExcluirTipoAlteracaoCommand : Notifiable<Notification>, ICommand
    {
        public ExcluirTipoAlteracaoCommand()
        {

        }

        public ExcluirTipoAlteracaoCommand(Guid idUsuario, EnTipoAlteracao nomeEnTipoAlteracao)
        {

        }

        public Guid IdUsuario { get; private set; }
        public EnTipoAlteracao NomeEnTipoAlteracao { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(IdUsuario, "IdUsuario", "A propriedade IdUsuario não pode ser nula")
                .IsNotNull(NomeEnTipoAlteracao, "NomeEnTipoAlteracao", "A propriedade NomeEnTipoAlteracao não pode ser nula")
            );
        }
    }
}
