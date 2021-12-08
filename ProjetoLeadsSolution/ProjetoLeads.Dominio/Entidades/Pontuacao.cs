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
    public class Pontuacao : Base
    {
        public Pontuacao(int pontuacaoEmpresa)
        {

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsLowerThan(pontuacaoEmpresa,101, "PontuacaoEmpresa", "A pontuação não pode ser maior que 100")
                );

            if (IsValid)
            {
                PontuacaoEmpresa = pontuacaoEmpresa;
            }

        }

        public int PontuacaoEmpresa { get; private set; }


        [ForeignKey("")]
        public Guid IdEmpresa { get; private set; }


        public Empresa Empresa { get; private set; }


        public void AlterarPontuacao(int NovaPontuacao)
        {
            if (IsValid)
            {
                PontuacaoEmpresa = NovaPontuacao;
            }
        }
    }
}
