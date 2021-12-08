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
    public class Proposta : Base
    {
        public Proposta(Guid idUsuario, Guid idEmpresa, string nomeArquivo, int tamanhoArquivo, byte arquivo)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(idUsuario, "A propriedade idUsuario não pode ser nula")
                .IsNotNull(idEmpresa, "A propriedade idEmpresa não pode ser nula")
                .IsNotNull(nomeArquivo, "A propriedade nomeArquivo não pode ser nula")
                .IsNotNull(tamanhoArquivo, "A propriedade tamanhoArquivo não pode ser nula")
                .IsNotNull(arquivo, "A propriedade arquivo não pode ser nula")
            );

            if (IsValid)
            {
                IdUsuario = idUsuario;
                IdEmpresa = idEmpresa;
                NomeArquivo = nomeArquivo;
                TamanhoArquivo = tamanhoArquivo;
                Arquivo = arquivo;
            }
        }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; private set; }

        [ForeignKey("Empresa")]
        public Guid IdEmpresa { get; private set; }

        public string NomeArquivo { get; private set; }

        public int TamanhoArquivo { get; private set; }

        public byte Arquivo { get; private set; }

        public DateTime DataProposta { get; private set; }

        public Usuario Usuario { get; private set; }

        public Empresa Empresa { get; private set; }

    }
}
