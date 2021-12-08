using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.Usuario;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Usuarios
{
    public class ValidarCadastroHanlder : Notifiable<Notification>, IHandler<ValidarCadastroCommand>
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public ValidarCadastroHanlder(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handler(ValidarCadastroCommand command)
        {
            command.Validar();

            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            _usuarioRepositorio.AlterarSituacaoAtivo(command.Usuario);

            return new GenericCommandResult(true, "Usuario validado com sucesso", null);


        }
    }
}
