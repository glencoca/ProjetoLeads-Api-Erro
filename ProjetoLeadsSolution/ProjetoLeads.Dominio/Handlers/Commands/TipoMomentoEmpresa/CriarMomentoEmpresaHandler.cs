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
    class CriarMomentoEmpresaHandler : Notifiable<Notification>, IHandler<CriarMomentoEmpresaCommand>
    {
        private readonly ITipoMomentoEmpresaRepositorio _tipoMomentoEmpresaRepositorio;

        public CriarMomentoEmpresaHandler(ITipoMomentoEmpresaRepositorio tipoMomentoEmpresaRepositorio)
        {
            _tipoMomentoEmpresaRepositorio = tipoMomentoEmpresaRepositorio;
        }

        public ICommandResult Handler(CriarMomentoEmpresaCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso os dados sejam inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência de um tipo Momento com o mesmo nome
            var tipoMomentoEmpresaExistente = _tipoMomentoEmpresaRepositorio.BuscarPorNome(command.NomeTipoMomentoCliente);

            //Caso exista, retornamos um erro
            if (tipoMomentoEmpresaExistente != null)
            {
                return new GenericCommandResult(false, "Tipo momento já existente", command.Notifications);
            }

            //Caso contrário, criamos um novo
            var newTipoMomentoEmpresa = new Entidades.TipoMomentoEmpresa(command.NomeTipoMomentoCliente);

            //Se os dados forem inválidos, retornamos um erro
            if (!newTipoMomentoEmpresa.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Salvamos no banco
            _tipoMomentoEmpresaRepositorio.Adicionar(newTipoMomentoEmpresa);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Novo tipo momento cadastrado com sucesso", null);
        }
    }
}
