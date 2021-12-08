using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.Empresa;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Empresa
{
    class AtualizarUsuarioEmpresaHandler : Notifiable<Notification>, IHandler<AtualizarUsuarioEmpresaCommand>
    {

        private IEmpresaRepositorio _empresaRepositorio;

        public AtualizarUsuarioEmpresaHandler(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public ICommandResult Handler(AtualizarEmpresaCommand command)
        {

            //Validamos os dados
            command.Validar();

            //Se forem inválidos, retornamos um erro
            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência da Empresa
            var empresaBuscado = _empresaRepositorio.BuscarPorId(command.IdEmpresa);

            //Se não existir, retornamos um erro
            if (empresaBuscado == null)
            {
                return new GenericCommandResult(false, "Empresa não foi encontrada", command.Notifications);
            }

            //Realizamos a alteraçãom no command, para verificar os dados
            empresaBuscado.AtualizarUsuario(command.IdUsuario);

            //Salvamos a alteração no banco de dados
            _empresaRepositorio.Atualizar(empresaBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Alteração realizada com sucesso", null);

        }

        public ICommandResult Handler(AtualizarUsuarioEmpresaCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
