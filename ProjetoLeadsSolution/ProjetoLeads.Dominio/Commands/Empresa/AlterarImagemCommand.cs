using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Empresa
{
    public class AlterarImagemCommand : Notifiable<Notification>, ICommand
    {
        public AlterarImagemCommand()
        {

        }

        public AlterarImagemCommand(byte imagem, Guid idEmpresa, Guid idUsuario)
        {
            Imagem = imagem;
            IdEmpresa = idEmpresa;
            IdUsuario = IdUsuario;
        }

        public byte Imagem { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public Guid IdUsuario { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Imagem, "Imagem", "A propriedade Imagem não pode ser nula")
                .IsNotNull(IdEmpresa, "IdEmpresa", "A propriedade IdEmpresa não pode ser nula")
                .IsNotNull(IdUsuario, "IdUsuario", "A propriedade não pode ser nula")
            );
        }
    }
}
