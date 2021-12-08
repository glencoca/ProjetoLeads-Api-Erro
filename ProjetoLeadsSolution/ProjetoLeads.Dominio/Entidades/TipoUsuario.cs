using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Entidades
{
    public class TipoUsuario : Base
    {
        public TipoUsuario(string tipoUsuario)
        {
            AddNotifications(
                new Contract<Notification>()
                    .Requires()
                    .IsNotNull(tipoUsuario, "TipoUsuario", "A propriedade TipoUsuario não pode ser nula")
                );

            if (IsValid)
            {
                NomeTipoUsuario = tipoUsuario;
            }
        }

        public string NomeTipoUsuario { get; private set; }

    }
}
