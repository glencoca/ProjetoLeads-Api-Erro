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
    public class MudarEmpresaPessoaContatoCommand : Notifiable<Notification>, ICommand
    {
        public MudarEmpresaPessoaContatoCommand()
        {

        }

        public MudarEmpresaPessoaContatoCommand(Guid idEmpresa, Guid idPessoaContato, DateTime dataInicio)
        {
            IdEmpresa = idEmpresa;
            IdPessoaContato = idPessoaContato;
            DataInicio = dataInicio;
        }

        public Guid IdPessoaContato { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public DateTime DataInicio { get; private set; }
        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(IdEmpresa, "IdEmpresa", "A propriedade IdEmpresa não pode ser nula")
                .IsNotNull(IdPessoaContato, "IdPessoaContato", "A propriedade IdPessoaContato não pode ser nula")
            );
        }
    }
}
