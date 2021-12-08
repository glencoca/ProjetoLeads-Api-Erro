using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Usuario
{
    class AlterarUsuarioCommand : Notifiable<Notification>, ICommand
    {
        public AlterarUsuarioCommand()
        {

        }

        public AlterarUsuarioCommand(Guid id, string nome, string email, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            TipoUsuario = tipoUsuario;
        }

        public string Nome { private set; get; }
        public string Email { get; private set; }
        public EnTipoUsuario TipoUsuario { get; private set; }
        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Email, "E-mail", "O e-mail não pode ser nulo.")
                .IsNotNull(Nome, "Nome", "O nome não pode ser nulo.")
                .IsNotNull(TipoUsuario, "Tipo Usuário", "O tipo usuário não pode ser nulo.")
            );
        }
    }
}
