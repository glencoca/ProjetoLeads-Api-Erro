using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Usuario
{
    public class AlterarSituacaoAtivoCommand : Notifiable<Notification>, ICommand
    {
        public AlterarSituacaoAtivoCommand()
        {

        }

        public AlterarSituacaoAtivoCommand(Entidades.Usuario usuario)
        {
            Usuario = usuario;
        }

        public Entidades.Usuario Usuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .IsNotNull(Usuario, "Usuario", "A propriedade Usuario não pode ser nula")
            );
        }
    }
}
