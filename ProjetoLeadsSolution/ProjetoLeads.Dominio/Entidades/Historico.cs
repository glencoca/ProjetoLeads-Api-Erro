using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Entidades
{
    public class Historico : Base
    {
        public Historico(DateTime dataAlteracao, Guid idEmpresa, Guid idUsuario, EnTipoAlteracao enTipoAlteracao, object? dados)
        {

            AddNotifications(
                 new Contract<Notification>()
                .Requires()
                .IsNotNull(dataAlteracao, "DataAlteração", "A Data não pode estar vazio")
                .IsNotNull(idEmpresa, "IdEmpresa", "O ID da Empresa não pode estar vazio")
                .IsNotNull(idUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
                .IsNotNull(enTipoAlteracao, "IdTipoAlteracao", "O ID do tipo alteração não pode estar vazio")
                );

            if (IsValid)
            {
                DataAlteracao = dataAlteracao;
                IdEmpresa = idEmpresa;
                IdUsuario = idUsuario;
                EnTipoAlteracao = enTipoAlteracao;
                Dados = dados;
            }
        }

        public DateTime DataAlteracao { get; private set; }


        //Composições

        //Chave Esrangeira
        [ForeignKey("Empresa")]
        public Guid IdEmpresa { get; private set; }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; private set; }

        [ForeignKey("TipoAlteracao")]
        public EnTipoAlteracao EnTipoAlteracao { get; private set; }

        //Objeto

        public Empresa  Empresa { get; private set; }
        public Usuario Usuario { get; private set; }
        public TipoAlteracao TipoAlteracao { get; private set; }
        #nullable enable
        public object Dados { get; set; }

    }
}
