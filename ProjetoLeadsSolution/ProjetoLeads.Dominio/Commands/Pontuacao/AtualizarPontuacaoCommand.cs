using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Pontuacao
{
    public class AtualizarPontuacaoCommand : Notifiable<Notification>, ICommand
    {

        public AtualizarPontuacaoCommand()
        {

        }

        public AtualizarPontuacaoCommand(int pontuacaoEmpresa, Guid IdPontuacao)
        {
            PontuacaoEmpresa = pontuacaoEmpresa;
        }

        public Guid IdPontuacao { get; private set; }
        public int PontuacaoEmpresa { get; private set; }

        public void Validar()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                 .IsLowerThan(PontuacaoEmpresa, 101, "PontuacaoEmpresa", "A pontuação não pode ser maior que 100")
            );
        }

 
    }
}
