using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Proposta
{
    public class AtualizarPropostaCommand : Notifiable<Notification>, ICommand
    {
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
