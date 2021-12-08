using Flunt.Notifications;
using Flunt.Validations;
using ProjetoLeads.Comum;
using ProjetoLeads.Comum.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Commands.Usuario
{
    public class CadastrarUsuarioCommand : Notifiable<Notification>, ICommand
    {

        public CadastrarUsuarioCommand()
        {

        }

        public CadastrarUsuarioCommand(string nome, string email, string senha, EnTipoUsuario tipoUsuario)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string Nome { private set; get; }
        public string Email { get; private set; }
        public string Senha { get; private set; }


        public void Validar()
        {
                AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Nome", "Nome não pode estar vazio")
                .IsEmail(Email, "Email", "O Formato do email está incorreto")
                .IsGreaterThan(Senha, 7, "Senha", "A senha deve conter pelo menos 8 caracteres")
                );
        }
    }
}
