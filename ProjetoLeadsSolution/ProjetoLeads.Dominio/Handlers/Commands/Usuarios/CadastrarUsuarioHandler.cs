using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Comum.Uteis;
using ProjetoLeads.Comum.Utils;
using ProjetoLeads.Dominio.Commands.Usuario;
using ProjetoLeads.Dominio.Entidades;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Usuarios
{
    public class CadastrarUsuarioHandler : Notifiable<Notification>, IHandler<CadastrarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public CadastrarUsuarioHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handler(CadastrarUsuarioCommand command)
        {
            /* Validamos os dados do usuário */
            if (!command.IsValid)
            {
                return new GenericCommandResult(
                    false,
                    "Informe os dados corretamente.",
                    command.Notifications
                );
            }

            //Validamos o e-mail pelo domínio
            if (!Email.ValidarEmail(command.Email))
            {
                return new GenericCommandResult(false, "O e-mail é inválido, informe um e-mail válido", command.Notifications);
            }

            /*Verficamos se o usuário já existe */
            Usuario usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            /*Se existir, retornamos um erro */
            if (usuarioExiste != null)
            {
                return new GenericCommandResult(false, "O e-mail já está cadastrado", command.Notifications);
            }

            /*Criamos um novo usuário */
            Usuario newUser = new Usuario(
               command.Nome,
               command.Email,
               command.Senha
            );

            /*Verificamos se as infomações são válidas, se não forem, retornamos um erro */
            if (!newUser.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos.", command.Notifications);
            }

            //Caso for válido, criptografamos a senha
            newUser.AlterarSenha(Senha.Criptografar(command.Senha));

            
            /*Por fim, cadastramos no banco*/
            _usuarioRepositorio.Adicionar(newUser);

            /*E retornamos uma mensagem de sucesso junto do token do usuário */
            return new GenericCommandResult(true, "Novo usuário cadastrado com sucesso", "");
        }
    }
}
