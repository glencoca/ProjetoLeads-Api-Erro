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
    public class AlterarTipoAlteracaoCommand : Notifiable<Notification>, ICommand
    {
        public AlterarTipoAlteracaoCommand()
        {

        }

        public AlterarTipoAlteracaoCommand(Guid idUsuario, EnTipoAlteracao nomeEnTipoAlteracao)
        {
            IdUsuario = idUsuario;
            NomeEnTipoAlteracao = nomeEnTipoAlteracao;

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
