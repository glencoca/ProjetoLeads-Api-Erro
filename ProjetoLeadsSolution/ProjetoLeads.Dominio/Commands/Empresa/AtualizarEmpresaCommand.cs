using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Empresa
{
    public class AtualizarEmpresaCommand : Notifiable<Notification>, ICommand
    {
        public AtualizarEmpresaCommand()
        {

        }

        public AtualizarEmpresaCommand(string nomeEmpresa, string qualificacaoTecnica, string qualificacaoComercial, Guid idRedeSociais, Guid idPontuacao, Guid idTipoStatus, Guid idTipoMomentoEmpresa, Guid idEmpresa, string cnpj, string marcaProduto)
        {
            NomeEmpresa = nomeEmpresa;
            QualificacaoTecnica = qualificacaoTecnica;
            QualificacaoComercial = qualificacaoComercial;
            IdRedeSociais = idRedeSociais;
            IdPontuacao = idPontuacao;
            IdTipoStatus = idTipoStatus;
            IdTipoMomentoEmpresa = idTipoMomentoEmpresa;
            IdEmpresa = IdEmpresa;
            Cnpj = cnpj;
            MarcaProduto = marcaProduto;
        }

        public string NomeEmpresa { get; private set; }
        public string QualificacaoTecnica { get; private set; }
        public string QualificacaoComercial { get; private set; }
        public string Cnpj { get; private set; }
        public string MarcaProduto { get; private set; }
        public Guid IdRedeSociais { get; private set; }
        public Guid IdPontuacao { get; private set; }
        public Guid IdTipoStatus { get; private set; }
        public Guid IdTipoMomentoEmpresa { get; private set; }
        public Guid IdUsuario { get; private set; }
        public Guid IdEmpresa { get; private set; }

        public void Validar()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(NomeEmpresa, "NomeEmpresa", "Nome da empresa não pode estar vazio")
            .IsNotNull(QualificacaoTecnica, "QualificacaoTecnica", "Qualificação Técnica não pode estar vazio")
            .IsNotNull(QualificacaoComercial, "QualificacaoComercial", "Qualificação Comercial não pode estar vazio")
            .IsNotNull(IdRedeSociais, "IdRedesSociais", "O ID das Redes Sociais não podem estar vazio")
            .IsNotNull(IdPontuacao, "IdPontuacao", "O ID da Pontuação não pode estar vazio")
            .IsNotNull(IdTipoStatus, "IdTipoStatus", "O ID do Status não pode estar vazio")
            .IsNotNull(IdTipoMomentoEmpresa, "IdTipoMomentoEmpresa", "o ID do Momento da Empresa não pode estar vazio")
            .IsNotNull(IdEmpresa, "IdEmpresa", "O ID da Empresa não pode estar vazio")
            .IsNotNull(IdUsuario, "IdUsuario", "O ID do Usuario não pode estar vazio")
            .IsNotNull(Cnpj, "CNPJ", "O CNPJ não pode ser vazio")
            .IsNotNull(MarcaProduto, "MarcaProduto", "Marca produto não pode ser vazio")
           );
        }
    }
}
