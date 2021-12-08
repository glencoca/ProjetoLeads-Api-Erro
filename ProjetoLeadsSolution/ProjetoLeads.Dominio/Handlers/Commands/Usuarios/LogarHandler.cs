using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Comum.Utils;
using ProjetoLeads.Dominio.Commands.Autenticação;
using ProjetoLeads.Dominio.Commands.Usuario;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Usuarios
{
    class LogarHandler : Notifiable<Notification>, IHandler<LogarCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LogarHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handler(LogarCommand command)
        {

            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Email ou senha Inválidos", command.Notifications);

            //Verificar email existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuarioExiste == null)
                return new GenericCommandResult(false, "Email inválido", command.Notifications);

            //Validar senha
            if (!Senha.ValidarSenha(command.Senha, usuarioExiste.Senha))
                return new GenericCommandResult(false, "Senha inválida", command.Notifications);


            return new GenericCommandResult(true, "Usuário logado", usuarioExiste);
        }
    }
    }


