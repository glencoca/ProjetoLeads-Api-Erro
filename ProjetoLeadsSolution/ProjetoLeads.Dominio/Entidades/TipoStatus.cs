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
    public class TipoStatus : Base
    {
        public TipoStatus(EnTiposStatus nomeTipoStatus, string corTipoStatus)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(nomeTipoStatus, "NomeTipoStaus", "O tipo do status não pode ser nulo")
                .IsNotNull(corTipoStatus, "CorTipoStatus", "A propriedade CorTipoStatus não pode ser nula")
                );


            if (IsValid)
            {
                NomeTipoStatus = nomeTipoStatus;
            }
        }


        public EnTiposStatus NomeTipoStatus { get; private set; }
        public string CorTipoStatus { get; private set; }

        public void AlterarNomeTipoStatus(EnTiposStatus NomeTipoStatusAlterado)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(NomeTipoStatusAlterado, "NomeTipoStatusAlterado", "A propriedade NomeTipoStatusAlterado não pode ser nula")
            );

            if (IsValid)
            {
                NomeTipoStatus = NomeTipoStatusAlterado;
            }
        }

        public void AlterarCorTipoStatus(string novaCor)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(novaCor, "NovaCor", "A propriedade NovaCor não pode ser nula")
            );

            if (IsValid)
            {
                CorTipoStatus = novaCor;
            }
        }

    }
}
