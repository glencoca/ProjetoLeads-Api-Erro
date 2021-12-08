using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Dominio.Commands.Empresa;

namespace ProjetoLeads.Dominio.Handlers.Commands.Empresa
{
    class ExcluirEmpresaHandler : Notifiable<Notification>, IHandler<ExcluirEmpresaCommand>
    {

        private IEmpresaRepositorio _empresaRepositorio;

        public ExcluirEmpresaHandler(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public ICommandResult Handler(ExcluirEmpresaCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso não sejam válidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Buscamos a empresa que será excluída
            var empresaBuscada = _empresaRepositorio.BuscarPorId(command.IdEmpresa);

            //Se não encontrarmos, retornamos um erro
            if (empresaBuscada == null)
            {
                return new GenericCommandResult(false, "Não foi possível encontrar a empresa", command.Notifications);
            }

            //Caso contrário, removemos do banco de dados
            _empresaRepositorio.Excluir(empresaBuscada);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Empresa excluída com sucesso", null);
        }
    }
}
