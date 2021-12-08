using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Entidades
{
    public class TipoMomentoEmpresa : Base
    {
        public TipoMomentoEmpresa(EnTipoMomentoEmpresa nomeTipoMomentoCliente)
        {

            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(nomeTipoMomentoCliente, "NomeTipoMomentoCliente", "O tipo momento cliente não pode ser nulo")
                );


            if (IsValid)
            {
                NomeTipoMomentoCliente = nomeTipoMomentoCliente;
            }
        }

        public EnTipoMomentoEmpresa NomeTipoMomentoCliente { get; private set; }


        public void AlterarNomeMomentoEmpresa(EnTipoMomentoEmpresa NomeTipoMomentoEmpresa)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
            );

            if (IsValid)
            {
                NomeTipoMomentoCliente = NomeTipoMomentoCliente;
            }
        }



    }
}
