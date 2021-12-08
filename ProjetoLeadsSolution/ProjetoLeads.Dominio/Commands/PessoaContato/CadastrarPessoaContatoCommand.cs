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
    public class CadastrarPessoaContatoCommand : Notifiable<Notification>, ICommand
    {
        public CadastrarPessoaContatoCommand()
        {

        }

        public CadastrarPessoaContatoCommand(string nome, string setor, Guid idEmpresa, Guid idRedesSociais, string area, string cargo)
        {
            Nome = nome;
            Setor = setor;
            IdEmpresa = idEmpresa;
            IdRedesSociais = idRedesSociais;
            Area = area;
            Cargo = cargo;
        }

        public string Nome { get; private set; }
        public string Setor { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public Guid IdRedesSociais { get; private set; }
        public string Area { get; private set; }
        public string Cargo { get; private set; }
        public byte Imagem { get; internal set; }
        public DateTime DataInicio { get; internal set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Nome", "A propriedade Nome não pode ser nula")
                .IsNotNull(Setor, "Setor", "A propriedade Setor não pode ser nula")
                .IsNotNull(IdEmpresa, "IdEmpresa", "A propriedade IdEmpresa não pode ser nula")
                .IsNotNull(IdRedesSociais, "IdRedesSociais", "A propriedade IdRedesSociais não pode ser nula")
            );
        }
    }
}
