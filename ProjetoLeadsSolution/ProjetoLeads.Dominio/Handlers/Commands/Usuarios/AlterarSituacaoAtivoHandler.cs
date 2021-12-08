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
    public class AlterarSituacaoAtivoHandler : Notifiable<Notification>, IHandler<AlterarSituacaoAtivoCommand>
    {
        private IUsuarioRepositorio _usuarioRepositorio;

        public AlterarSituacaoAtivoHandler(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public ICommandResult Handler(AlterarSituacaoAtivoCommand command)
        {
            //Verificamos se o dado é válido
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }
            
            command.Usuario.AlterarSituacaoAtivo(true);

            //Alteramos no banco de dados
            _usuarioRepositorio.AlterarSituacaoAtivo(command.Usuario);

            return new GenericCommandResult(true, "Alteração realizada com sucesso", null);
        }
    }
}
