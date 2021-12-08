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

namespace ProjetoLeads.Dominio.Handlers.Usuarios
{
    class AlterarUsuarioHandler : Notifiable<Notification>, IHandler<AlterarUsuarioCommand>
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;

        /* Injeção de dependência */
        public AlterarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }


        public ICommandResult Handler(AlterarUsuarioCommand command)
        {
            /* Validamos os dados */
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Informe os dados corretamente", command.Notifications);
            }

            /* Buscamos o usuário pelo e-mail */
            var userBuscado = _usuarioRepositorio.BuscarPorEmail(command.Email);

            /* Se o usuário não existir, retornamos um erro*/
            if (userBuscado == null)
            {
                return new GenericCommandResult(false, "Usuário inválido, informe os dados corretamente", command.Notifications);
            }

            //Verificamos se o e-mail informado já está em uso
            if (userBuscado.Email == command.Email)
            {
                var emailExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

                //Caso exista, retornamos um erro
                if (emailExiste != null)
                {
                    return new GenericCommandResult(false, "E-mail já cadastrado", command.Notifications);
                }
            }

            // Passamos os novos dados para o usuário
            userBuscado.AlterarUsuario(command.Nome, command.Email, command.TipoUsuario);

            //Validamos os dados
            if (!userBuscado.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Caso os dados forem válidos, chamamos o método para alterar
            _usuarioRepositorio.Alterar(userBuscado);

            return new GenericCommandResult(false, "Dados alterados com sucesso", null);
        }
    }
}
