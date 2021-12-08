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
    class ExcluirUsuarioHandler : Notifiable<Notification>, IHandler<ExcluirUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public ExcluirUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public ICommandResult Handler(ExcluirUsuarioCommand command)
        {
            command.Validar();

            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Id de usuário inválido", command.Notifications);
            }

            var userBuscado = _usuarioRepositorio.BuscarPorId(command.IdUsuario);

            if (userBuscado == null)
            {
                return new GenericCommandResult(false, "Usuário não foi encontrado", command.Notifications);
            }

            _usuarioRepositorio.ExcluirUsuarioPorId(command.IdUsuario);

            return new GenericCommandResult(true, "Usuário excluído com sucesso", null);
        }
    }
}
