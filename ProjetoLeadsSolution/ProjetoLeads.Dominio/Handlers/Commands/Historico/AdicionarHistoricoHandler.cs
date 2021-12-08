using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.Histórico;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Historico
{
    class AdicionarHistoricoHandler : Notifiable<Notification>, IHandler<AdicionarHistoricoCommand>
    {
        private readonly IHistoricoRepositorio _historicoRepositorio;

        public AdicionarHistoricoHandler(IHistoricoRepositorio historicoRepositorio)
        {
            _historicoRepositorio = historicoRepositorio;
        }

        public ICommandResult Handler(AdicionarHistoricoCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso sejam inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Criamos um novo histórico
            var historico = new Entidades.Historico(command.DataAlteracao, command.IdEmpresa, command.IdUsuario, command.EnTipoAlteracao, command.Dados);

            //Caso as informações sejam inválidas, retornamos um erro
            if (!historico.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Caso contrário, adcionamos ao banco de dados
            _historicoRepositorio.AdicionarHistorico(historico);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Novo hisotórico adicionado com sucesso", null);
        }
    }
}
