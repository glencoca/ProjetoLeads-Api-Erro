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
    public class LogarCommand : Notifiable<Notification>, ICommand
    {

        public LogarCommand()
        {

        }

        public LogarCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }

        public void Validar()
        {
                AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsEmail(Email, "Email", "O Formato do email está incorreto")
                .IsGreaterThan(Senha, 7, "Senha", "A senha deve conter pelo menos 8 caracteres")
                );

        }
    }
}
