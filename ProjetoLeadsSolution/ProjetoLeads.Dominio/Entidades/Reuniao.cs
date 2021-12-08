using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Entidades
{
    public class Reuniao : Base
    {
        public Reuniao(DateTime dataHora, Guid idUsuario, Guid idPessoaContato)
        {

            AddNotifications(
                 new Contract<Notification>()
                .Requires()
                .IsNotNull(dataHora, "DataHora", "A data e hora não pode estar vazio")
                .IsNotNull(idUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
                .IsNotNull(idPessoaContato, "IdPessoaContato", "O ID da Pessoa Contato não pode estar vazio")
                );

            if (IsValid)
            {
                DataHora = dataHora;
                IdUsuario = idUsuario;
                IdPessoaContato = idPessoaContato;
            }
        }

        public DateTime DataHora { get; private set; }

        //Composições

        //Chave Estrangeira
        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; private set; }

        [ForeignKey("PessoaContato")]
        public Guid IdPessoaContato { get; private set; }

        //Objetos
        public Usuario Usuario { get; private set; }
        public PessoaContato PessoaContato { get; private set; }

    }
}
