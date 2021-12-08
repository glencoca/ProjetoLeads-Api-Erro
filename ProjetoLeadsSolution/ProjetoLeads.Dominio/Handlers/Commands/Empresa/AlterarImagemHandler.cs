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
    class AlterarImagemHandler : Notifiable<Notification>, IHandler<AlterarImagemCommand>
    {
        private IEmpresaRepositorio _empresaRepositorio;

        public AlterarImagemHandler(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        
        public ICommandResult Handler(AlterarImagemCommand command)
        {
            command.Validar();

            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            var empresaBuscada = _empresaRepositorio.BuscarPorId(command.IdEmpresa);

            if (empresaBuscada == null)
            {
                return new GenericCommandResult(false, "Não foi possível encontrar a Empresa", command.Notifications);
            }

            empresaBuscada.AlterarImagem(command.Imagem);

            _empresaRepositorio.AlterarImagem(empresaBuscada);

            return new GenericCommandResult(true, "Imagem atualizada com sucesso", null);
        }
    }
}
