using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Reunião
{
    public class MarcarReuniaoCommand : Notifiable<Notification>, ICommand
    {

        public MarcarReuniaoCommand()
        {

        }

        public MarcarReuniaoCommand(DateTime dataHora, Guid idUsuario, Guid idPessoaContato, Guid idReuniao)
        {
            DataHora = dataHora;
            IdUsuario = idUsuario;
            IdPessoaContato = idPessoaContato;
            IdReuniao = idReuniao;
        }

        public DateTime DataHora { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdPessoaContato { get; private set; }
        public Guid IdReuniao { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
           .Requires()
           .IsNotNull(DataHora, "DataHora", "A data e hora não pode estar vazio")
           .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
           .IsNotNull(IdPessoaContato, "IdPessoaContato", "O ID da Pessoa Contato não pode estar vazio")
           .IsNotNull(IdReuniao, "IdReuniao", "O ID da Reunião não pode estar vazio")
           );
        }
    }
}
