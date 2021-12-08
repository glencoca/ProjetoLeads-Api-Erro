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
    public class RedesSociais : Base
    {
        public RedesSociais(string telefone, string email, string linkLinkedin, string linkInstagram)
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsGreaterThan(telefone, 10, "Telefone", "O telefone precisa ter 11 números")
                .IsEmail(email, "Email", "O Formato do email está incorreto")
                .IsNotNull(linkLinkedin, "LinkLinkedin", "O link do Linkedin não pode estar vazio")
                );


            if (IsValid)
            {
                Telefone = telefone;
                Email = email;
                LinkLinkedin = linkLinkedin;
            }
        }

        [ForeignKey("Empresa")]
        public Guid IdEmpresa { get; private set; }

        public Empresa Empresa { get; set; }


        [ForeignKey("PessoaContato")]
        public Guid IdPessoaContato { get; private set; }

        public PessoaContato PessoaContato { get; private set; }

        public string Telefone   { get; private set; }
        public string Email { get; private set; }
        public string LinkLinkedin { get; private set; }
    }
}
