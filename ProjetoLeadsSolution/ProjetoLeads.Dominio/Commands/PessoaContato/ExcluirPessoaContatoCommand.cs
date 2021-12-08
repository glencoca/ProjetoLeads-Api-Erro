using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.PessoaContato
{
    public class ExcluirPessoaContatoCommand : Notifiable<Notification>, ICommand
    {
        public ExcluirPessoaContatoCommand()
        {

        }

        public ExcluirPessoaContatoCommand(Guid idPessoaContato)
        {
            IdPessoaContato = idPessoaContato;
        }

        public Guid IdPessoaContato { get; private set; }
        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(IdPessoaContato, "IdPessoaContato", "A propriedade IdPessoaContato não pode ser nula")
            );
        }
    }
}
