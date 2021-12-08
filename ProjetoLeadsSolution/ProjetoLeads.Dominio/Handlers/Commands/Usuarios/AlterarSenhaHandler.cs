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
    class AlterarSenhaHandler : Notifiable<Notification>, IHandler<AlterarSenhaCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public AlterarSenhaHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(AlterarSenhaCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso os dados não sejam válidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Senha inválida", command.Notifications);
            }

            //Buscamos o usuário que terá a senha alterada
            var userBuscado = _usuarioRepositorio.BuscarPorId(command.IdUsuario);

            //Se for nulo, retornamos erro
            if (userBuscado == null)
            {
                return new GenericCommandResult(false, "Usuário não foi encontrado", command.Notifications);
            }

            // Criptografamos a nova senha
            command.Senha = Senha.Criptografar(command.Senha);
            userBuscado.AlterarSenha(command.Senha);

            // Salvamos a alteração no banco de dados
            _usuarioRepositorio.AlterarSenha(userBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Senha alterada com sucesso", null);
        }
    }
}
