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
    public class CadastrarTipoAlteracaoCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarTipoAlteracaoCommand()
        {

        }

        public CadastrarTipoAlteracaoCommand(Guid idUsuario, EnTipoAlteracao enTipoAlteracao)
        {
            IdUsuario = idUsuario;
            EnTipoAlteracao = enTipoAlteracao;

        }


        public Guid IdUsuario { get; private set; }
        public EnTipoAlteracao EnTipoAlteracao { get; private set; }
        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(IdUsuario, "IdUsuario", "A propriedade IdUsuario não pode ser nula")
                .IsNotNull(EnTipoAlteracao, "EnTipoAlteracao", "A propriedade EnTipoAlteracao não pode ser nula")
            );
        }
    }
}
