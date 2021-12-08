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
    class AlterarMomentoEmpresaHandler : Notifiable<Notification>, IHandler<AlterarMomentoEmpresaCommand>
    {

        private readonly ITipoMomentoEmpresaRepositorio _tipoMomentoEmpresaRepositorio;

        public AlterarMomentoEmpresaHandler(ITipoMomentoEmpresaRepositorio tipoMomentoEmpresaRepositorio)
        {
            _tipoMomentoEmpresaRepositorio = tipoMomentoEmpresaRepositorio;
        }

        public ICommandResult Handler(AlterarMomentoEmpresaCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso não seja válido, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Nome de tipo status inválido", command.Notifications);
            }

            //Verficamos a existência desse tipo momento
            var tipoMomentoEmpresasBuscado = _tipoMomentoEmpresaRepositorio.BuscarPorNome(command.NomeTipoMomentoCliente);

            //Se não existir, retornamos um erro
            if (tipoMomentoEmpresasBuscado == null)
            {
                return new GenericCommandResult(false, "O tipo status não foi encontrado", command.Notifications);
            }

            //Caso exista, alteramos o nome desse tipo status
            tipoMomentoEmpresasBuscado.AlterarNomeMomentoEmpresa(command.NomeTipoMomentoCliente);

            //Salvamos a alteração no banco
            _tipoMomentoEmpresaRepositorio.Alterar(tipoMomentoEmpresasBuscado);


            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Tipo status alterado com sucesso", null);
        }
    }
}
