using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.TipoAlteracao;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.TipoAlteracao
{
    public class AlterarTipoAlteracaoHandler : Notifiable<Notification>, IHandler<AlterarTipoAlteracaoCommand>
    {
        private ITipoAlteracaoRepositorio _tipoAlteracaoRepositorio;

        public AlterarTipoAlteracaoHandler(ITipoAlteracaoRepositorio tipoAlteracaoRepositorio)
        {
            _tipoAlteracaoRepositorio = tipoAlteracaoRepositorio;
        }

        public ICommandResult Handler(AlterarTipoAlteracaoCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Se forem inválidos, retornamos um erro
            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos a existência do TipoAlteracao
            var tipoAlteracaoBuscado = _tipoAlteracaoRepositorio.BuscarPorNome(command.NomeEnTipoAlteracao);

            //Se não existir, retornamos um erro
            if (tipoAlteracaoBuscado == null)
            {
                return new GenericCommandResult(false, "TipoAlteracao não foi encontrado", command.Notifications);
            }

            //Realizamos a alteraçãom no command, para verificar os dados
            tipoAlteracaoBuscado.AlterarNomeTipoAlteracao(command.NomeEnTipoAlteracao);

            //Salvamos a alteração no banco de dados
            _tipoAlteracaoRepositorio.Alterar(tipoAlteracaoBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Alteração realizada com sucesso", null);
        }
    }
}
