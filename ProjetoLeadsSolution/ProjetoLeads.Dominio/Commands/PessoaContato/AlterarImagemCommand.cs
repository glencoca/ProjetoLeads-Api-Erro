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
    public class AlterarImagemCommand : Notifiable<Notification>, ICommand
    {

        public AlterarImagemCommand()
        {

        }

        public AlterarImagemCommand(byte imagem, Guid idPessoaContato, Guid idUsuario)
        {
            Imagem = imagem;
            IdPessoaContato = idPessoaContato;
            IdUsuario = idUsuario;
        }

        public byte Imagem { get; private set; }
        public Guid IdPessoaContato { get; private set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Imagem, "Imagem", "A propriedade Imagem não pode ser nula")
                .IsNotNull(IdPessoaContato, "IdEmpresa", "A propriedade IdEmpresa não pode ser nula")
                .IsNotNull(IdUsuario, "IdUsuario", "A propriedade não pode ser nula")
            );
        }
    }
}
