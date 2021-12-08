using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoLeads.Dominio.Entidades
{
    public class Usuario : Base
    {
        public Usuario(string nome, string email, string senha )
        {
            AddNotifications(
            new Contract<Notification>()
                .Requires()
                .IsNotNull(nome, "Nome", "Nome não pode estar vazio")
                .IsEmail(email, "Email", "O Formato do email está incorreto")
                .IsGreaterThan(senha, 7,"Senha", "A senha deve conter pelo menos 8 caracteres")
                );

            if (IsValid)
            {
                Nome = nome;
                Email = email;
                Senha = senha;
                Ativo = false;
            }
        }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        [ForeignKey("TipoUsuario")]
        public Guid IdTipoUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; private set; }

        public bool Ativo { get; private set; }


        public void AlterarUsuario(string nome, string email, EnTipoUsuario tipoUsuario)
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotNull(email, "E-mail", "O e-mail não pode ser nulo")
            .IsNotNull(nome, "Nome", "O nome não pode ser nulo")
            .IsNotNull(tipoUsuario, "Tipo Usuário", "O tipo usuário não pode ser nulo")
            );
        }

        public void AlterarSenha(string senha)
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(senha, "A propriedade senha não pode ser nula")
            );

            if (IsValid)
            {
                Senha = senha;
            }
        }

        public bool AlterarSituacaoAtivo(bool ativo)
        {
            if (IsValid)
            {
                Ativo = ativo;
            }

            return Ativo;
        }

    public void RecuperarSenha(string nome, string email)
    {
        AddNotifications(
        new Contract<Notification>()
        .Requires()
        .IsNotNull(nome, "Nome", "O nome não pode ser nulo")
        .IsEmail(email, "Email", "Informe um e-mail válido")
       );

        if (IsValid)
        {
            Nome = nome;
            Email = email;
        }
    }

}
}
