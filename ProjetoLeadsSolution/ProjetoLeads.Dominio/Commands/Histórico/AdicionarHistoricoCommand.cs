using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Histórico
{
    public class AdicionarHistoricoCommand : Notifiable<Notification>, ICommand
    {

        public AdicionarHistoricoCommand()
        {

        }

        public AdicionarHistoricoCommand(DateTime dataAlteracao, Guid idEmpresa, Guid idUsuario, EnTipoAlteracao enTipoAlteracao, object? dados)
        {
            DataAlteracao = dataAlteracao;
            IdEmpresa = idEmpresa;
            IdUsuario = idUsuario;
            EnTipoAlteracao = enTipoAlteracao;
            Dados = dados;
        }

        public DateTime DataAlteracao { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public Guid IdUsuario { get; private set; }
        public EnTipoAlteracao EnTipoAlteracao { get; private set; }
        public object? Dados { get; private set; }

        public void Validar()
        {
                AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(DataAlteracao, "DataAlteração", "A Data não pode estar vazio")
                .IsNotNull(IdEmpresa, "IdEmpresa", "O ID da Empresa não pode estar vazio")
                .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
                .IsNotNull(EnTipoAlteracao, "EnTipoAlteracao", "O Enum do tipo alteração não pode estar vazio")
           );
        }
    }
}
