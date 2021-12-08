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
    public class Empresa : Base
    {

        public Empresa(string nomeEmpresa, string qualificacaoTecnica, string qualificacaoComercial, Guid idRedeSociais, Guid idPontuacao, Guid idTipoStatus, Guid idTipoMomentoEmpresa, Guid idUsuario, string cnpj, string marcaProduto)
        {

                 AddNotifications(
                 new Contract<Notification>()
                .Requires()
                .IsNotNull(nomeEmpresa, "NomeEmpresa", "Nome da empresa não pode estar vazio")
                .IsNotNull(qualificacaoTecnica, "QualificacaoTecnica", "Qualificação Técnica não pode estar vazio")
                .IsNotNull(qualificacaoComercial, "QualificacaoComercial", "Qualificação Comercial não pode estar vazio")
                .IsNotNull(idRedeSociais, "IdRedesSociais", "O ID das Redes Sociais não podem estar vazio")
                .IsNotNull(idPontuacao, "IdPontuacao", "O ID da Pontuação não pode estar vazio")
                .IsNotNull(idTipoStatus, "IdTipoStatus", "O ID do Status não pode estar vazio")
                .IsNotNull(idTipoMomentoEmpresa, "IdTipoMomentoEmpresa", "o ID do Momento da Empresa não pode estar vazio")
                .IsNotNull(idUsuario, "IdUsuario", "o ID do Usuario não pode ser vazio")
                .IsNotNull(cnpj, "Cnpj", "o Cnpj não pode ser vazio")
                .IsNotNull(marcaProduto, "MarcaProduto", "A marca Produto não pode estar vazia")
                );


            if (IsValid)
            {
                NomeEmpresa = nomeEmpresa;
                QualificacaoTecnica = qualificacaoTecnica;
                QualificacaoComercial = qualificacaoComercial;
                IdRedeSociais = idRedeSociais;
                IdPontuacao = idPontuacao;
                IdTipoStatus = idTipoStatus;
                IdTipoMomentoEmpresa = idTipoMomentoEmpresa;
                IdUsuario = idUsuario;
                Cnpj = cnpj;
                MarcaProduto = marcaProduto;
            }

        }

        public string  NomeEmpresa { get; private set; }
        public  string  QualificacaoTecnica { get; private set; }
        public  string  QualificacaoComercial { get; private set; }
        public byte Imagem { get; private set; }
        public string Cnpj { get; private set; }
        public string MarcaProduto { get; private set; }

        //Composições

        //Chave Estrangeira
        [ForeignKey("RedesSociais")]
        public Guid IdRedeSociais { get; private set; }

        [ForeignKey("Pontuacao")]
        public Guid IdPontuacao { get; private set; }

        [ForeignKey("TipoStatus")]
        public Guid IdTipoStatus { get; private set; }

        [ForeignKey("TipoMomentoEmpresa")]
        public Guid IdTipoMomentoEmpresa { get; private set; }

        [ForeignKey("Usuario")]
        public Guid IdUsuario { get; private set; }


        //Objetos
        public  Pontuacao  Pontuacao { get; private set; }
        public  TipoMomentoEmpresa TipoMomentoEmpresa { get; private set; }
        public  RedesSociais  RedesSociais { get; private set; }
        public  TipoStatus TipoStatus { get; private set; }
        public Usuario Usuario { get; private set; }


        public void AlterarImagem(byte novaImagem)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(novaImagem, "Imagem", "A propriedade Imagem não pode ser nula")
            );

            if (IsValid)
            {
                Imagem = novaImagem;
            }
        }
        public void AtualizarEmpresa(string nomeEmpresa, string qualificacaoTecnica, string qualificacaoComercial, Guid idRedeSociais, Guid idPontuacao, Guid idTipoStatus, Guid idTipoMomentoEmpresa, string cnpj, string marcaProduto)
        {
                  AddNotifications(
                  new Contract<Notification>()
                 .Requires()
                 .IsNotNull(nomeEmpresa, "NomeEmpresa", "Nome da empresa não pode estar vazio")
                 .IsNotNull(qualificacaoTecnica, "QualificacaoTecnica", "Qualificação Técnica não pode estar vazio")
                 .IsNotNull(qualificacaoComercial, "QualificacaoComercial", "Qualificação Comercial não pode estar vazio")
                 .IsNotNull(idRedeSociais, "IdRedesSociais", "O ID das Redes Sociais não podem estar vazio")
                 .IsNotNull(idPontuacao, "IdPontuacao", "O ID da Pontuação não pode estar vazio")
                 .IsNotNull(idTipoStatus, "IdTipoStatus", "O ID do Status não pode estar vazio")
                 .IsNotNull(idTipoMomentoEmpresa, "IdTipoMomentoEmpresa", "o ID do Momento da Empresa não pode estar vazio")
                 .IsNotNull(marcaProduto, "MarcaProduto", "Marca produto não pode ser vazio")
            );

            if (IsValid)
            {
                NomeEmpresa = nomeEmpresa;
                QualificacaoTecnica = qualificacaoTecnica;
                QualificacaoComercial = qualificacaoComercial;
                IdRedeSociais = idRedeSociais;
                IdPontuacao = idPontuacao;
                IdTipoStatus = idTipoStatus;
                IdTipoMomentoEmpresa = idTipoMomentoEmpresa;
                Cnpj = cnpj;
                MarcaProduto = marcaProduto;
            }
        }

        public void AtualizarUsuario(Guid idUsuario)
        {
                AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(idUsuario, "IdUsuario", "O ID do usuario não pode ser vazio")
                );

            if (IsValid)
            {

                IdUsuario = idUsuario;

            }
        }

    }
}
