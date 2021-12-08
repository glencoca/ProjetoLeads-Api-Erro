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
    public class PessoaContato : Base
    {
        public PessoaContato(string nome, string setor, Guid idEmpresa, Guid idRedesSociais, byte imagem, string area, string cargo, DateTime dataInicio)
        {

                AddNotifications(
                 new Contract<Notification>()
                .Requires()
                .IsNotNull(nome, "Nome", "Nome não pode estar vazio")
                .IsNotNull(setor, "Setor", "Setor não pode estar vazio")
                .IsNotNull(idEmpresa, "IdEmpresa", "ID Empresa não pode estar vazio")
                .IsNotNull(idRedesSociais, "IdRedesSociais", "O ID das Redes Sociais não podem estar vazio")
                .IsNotNull(area, "Area", "A propriedade Area não pode ser nula")
                .IsNotNull(cargo, "Cargo", "A propriedade Cargo não pode ser nula")
                .IsNotNull(dataInicio, "DataInicio", "A propriedade DataInicio não pode ser nula")

                );

            if (IsValid)
            {
                Nome = nome;
                Setor = setor;
                IdEmpresa = idEmpresa;
                IdRedesSociais = idRedesSociais;
                Imagem = imagem;
                Area = area;
                Cargo = cargo;
                DataInicio = dataInicio;
            }
        }

        public string Nome { get; private set; }
        public string Setor { get; private set; }
        public byte Imagem { get; private set; }
        public string Area { get; private set; }
        public string Cargo { get; private set; }
        public DateTime DataInicio { get; private set; }


        //Composiçoes

        //Chave Estrangeira
        [ForeignKey("Empresa")]
        public Guid IdEmpresa { get; private set; }

        [ForeignKey("RedesSociais")]
        public Guid IdRedesSociais { get; private set; }

        //Objetos
        public Empresa Empresa { get; private set; }
        public RedesSociais RedesSociais { get; private set; }


        public void AtualizarPessoaContato(string nome, string setor, Guid idRedesSociais, string area, string cargo)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(nome, "A propriedade nome não pode ser nula")
                .IsNotNull(setor, "A propriedade setor não pode ser nula")
                .IsNotNull(idRedesSociais, "A propriedade idRedesSociais não pode ser nula")
                .IsNotNull(area, "Area", "A propriedade Area não pode ser nula")
                .IsNotNull(cargo, "Cargo", "A propriedade Cargo não pode ser nula")
            );

            if (IsValid)
            {
                Nome = nome;
                Setor = setor;
                IdRedesSociais = idRedesSociais;
                Area = area;
                Cargo = cargo;
            }
            
        }

        public void MudarEmpresaPessoaContato(Guid idPessoaContato, Guid idEmpresa, DateTime dataInicio)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(idPessoaContato, "A propriedade idPessoaContato não pode ser nula")
                .IsNotNull(idEmpresa, "A propriedade idEmpresa não pode ser nula")
                .IsNotNull(dataInicio, "DataInicio", "A propriedade DataInicio não pode ser nula")

            );

            if (IsValid)
            {
                IdEmpresa = idEmpresa;
                DataInicio = dataInicio;
            }
        }

        public void AlterarImagem(byte novaImagem)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(novaImagem, "Imagem", "A propriedade Imagem não pode ser nula")
            );
        }
    }
}
