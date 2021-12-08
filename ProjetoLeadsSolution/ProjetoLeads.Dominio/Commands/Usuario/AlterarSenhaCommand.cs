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
    public class AlterarSenhaCommand : Notifiable<Notification>, ICommand
    {

        public AlterarSenhaCommand()
        {

        }

        public AlterarSenhaCommand(string senha)
        {
            Senha = senha;
            IdUsuario = IdUsuario;
        }

        public string Senha { get; set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
           .Requires()
           .IsGreaterThan(Senha, 7, "Senha", "A senha deve conter pelo menos 8 caracteres")
           .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode ser vazio")
           );
        }
    }
}
