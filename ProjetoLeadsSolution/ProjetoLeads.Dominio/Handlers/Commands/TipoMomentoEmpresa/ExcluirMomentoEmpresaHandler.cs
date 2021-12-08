using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.TipoMomentoEmpresa;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.TipoMomentoEmpresa
{
    class ExcluirMomentoEmpresaHandler : Notifiable<Notification>, IHandler<ExcluirMomentoEmpresaCommand>
    {

        private readonly ITipoMomentoEmpresaRepositorio _tipoMomentoEmpresaRepositorio;

        public ExcluirMomentoEmpresaHandler(ITipoMomentoEmpresaRepositorio tipoMomentoEmpresaRepositorio)
        {
            _tipoMomentoEmpresaRepositorio = tipoMomentoEmpresaRepositorio;
        }

        public ICommandResult Handler(ExcluirMomentoEmpresaCommand command)
        {

            //Validamos os dados
            command.Validar();

            //Caso os dados não sejam válidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Buscamos pelo Tipo Momento que será excluído
            var tipoStatusBuscado = _tipoMomentoEmpresaRepositorio.BuscarPorNome(command.NomeTipoMomentoCliente);

            //Se não encontrarmos, retornamos um eroo
            if (tipoStatusBuscado == null)
            {
                return new GenericCommandResult(false, "O tipo momento não foi encontrado", command.Notifications);
            }

            //Caso dê tudo certo, removemos do banco de dados
            _tipoMomentoEmpresaRepositorio.Excluir(tipoStatusBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "O tipo momento foi excluído com sucesso", null);
        }
    }
}