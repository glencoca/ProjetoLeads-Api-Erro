using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Comum.Utils;
using ProjetoLeads.Dominio.Commands.Autenticação;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Usuarios
{
    class RecuperarSenhaHandler : Notifiable<Notification>, IHandler<RecuperarSenhaCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public RecuperarSenhaHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handler(RecuperarSenhaCommand command)
        {
 
            //Aplicar as validações
            command.Validar();

            if (command.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica se email existe
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if (usuario == null)
                return new GenericCommandResult(false, "Email inválido", null);

            //Gerar nova senha
            string senha = Senha.GerarSenha();
            //Criptografar senha
            usuario.AlterarSenha(Senha.Criptografar(senha));

            if (usuario.IsValid)
                return new GenericCommandResult(false, "Dados inválidos", usuario.Notifications);

            //Salvar usuario banco
            _usuarioRepositorio.AlterarSenha(usuario);

            //TODO: Enviar email de boas vindas

            return new GenericCommandResult(true, "Uma nova senha foi criada e enviada para o seu e-mail, verifique!!!", null);
        }
    }
}

