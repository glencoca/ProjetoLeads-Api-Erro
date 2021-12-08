using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Entidades
{
    public class TipoAlteracao : Base
    {
        public TipoAlteracao(EnTipoAlteracao nomeTipoAlteracao)
        {

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(nomeTipoAlteracao, "NomeTipoAlteracao", "O nome da alteração não pode ser nulo")
                );

            if (IsValid)
            {
                NomeTipoAlteracao = nomeTipoAlteracao;
            }

        }

        public EnTipoAlteracao NomeTipoAlteracao { get; private set; }

        public void AlterarNomeTipoAlteracao(EnTipoAlteracao nomeTipoAlteracao)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
            );

            if (IsValid)
            {
                NomeTipoAlteracao = nomeTipoAlteracao;
            }

        }
    }
}
