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
    public class CadastrarTipoAlteracaoHandler : Notifiable<Notification>, IHandler<CadastrarTipoAlteracaoCommand>
    {
        private ITipoAlteracaoRepositorio _tipoAlteracaoRepositorio;

        public CadastrarTipoAlteracaoHandler(ITipoAlteracaoRepositorio tipoAlteracaoRepositorio)
        {
            _tipoAlteracaoRepositorio = tipoAlteracaoRepositorio;
        }


        public ICommandResult Handler(CadastrarTipoAlteracaoCommand command)
        {

            //Validamos os dados
            command.Validar();

            //Se forem inválidos, retornamos um erro
            if (!IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Verificamos se já existe um tipo alteração com o mesmo nome
            var tipoAlteracaoExiste = _tipoAlteracaoRepositorio.BuscarPorNome(command.EnTipoAlteracao);

            //Caso exista, retornamos um erro
            if (tipoAlteracaoExiste != null)
            {
                return new GenericCommandResult(false, "TipoAlteração já cadastrado", command.Notifications);
            }

            //Criamos um novo TipoAlteracao
            var newTipoAlteracao = new Entidades.TipoAlteracao(command.EnTipoAlteracao);

            //Verificamos os dados e retornamos um erro caso sejam inválidos
            if (!newTipoAlteracao.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Cadastramos no banco de dados
            _tipoAlteracaoRepositorio.Adicionar(newTipoAlteracao);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Novo Tipo Alteração cadastrado com sucesso", null);
        }
    }
}
