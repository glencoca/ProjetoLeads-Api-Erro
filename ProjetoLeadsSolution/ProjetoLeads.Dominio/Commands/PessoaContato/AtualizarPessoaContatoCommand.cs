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
    public class AtualizarPessoaContatoCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarPessoaContatoCommand()
        {

        }

        public AtualizarPessoaContatoCommand(Guid idPessoaContato, string nome, string setor, Guid idRedesSociais, string area, string cargo)
        {
            IdPessoaContato = idPessoaContato;
            Nome = nome;
            Setor = setor;
            IdRedesSociais = idRedesSociais;
            Area = area;
            Cargo = cargo;
        }

        public Guid IdPessoaContato { get; private set; }
        public string Nome { get; private set; }
        public string Setor { get; private set; }
        public Guid IdRedesSociais { get; private set; }
        public string Area { get; private set; }
        public string Cargo { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Nome", "A propriedade Nome não pode ser nula")
                .IsNotNull(Setor, "Setor", "A propriedade Setor não pode ser nula")
                .IsNotNull(IdRedesSociais, "IdRedesSociais", "A propriedade IdRedesSociais não pode ser nula")
                .IsNotNull(Area, "Area", "A propriedade Area não pode ser nula")
                .IsNotNull(Cargo, "Cargo", "A propriedade Cargo não pode ser nula")
            );
        }
    }
}
