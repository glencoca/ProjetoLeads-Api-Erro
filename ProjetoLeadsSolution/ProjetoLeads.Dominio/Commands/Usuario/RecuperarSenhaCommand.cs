using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Autenticação
{
    public class RecuperarSenhaCommand : Notifiable<Notification>, ICommand
    {

        public RecuperarSenhaCommand()
        {

        }

        public RecuperarSenhaCommand(string email)
        {
            Email = email;
            IdUsuario = IdUsuario;
        }

        public string Email { get; private set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsEmail(Email, "Email", "O Formato do email está incorreto")
            .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode ser vazio")
            );
        }
    }
}
