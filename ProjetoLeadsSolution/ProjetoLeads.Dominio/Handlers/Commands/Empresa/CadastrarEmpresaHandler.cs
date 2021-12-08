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
    class CadastrarEmpresaHandler : Notifiable<Notification>, IHandler<CadastrarEmpresaCommand>
    {

        private IEmpresaRepositorio _empresaRepositorio;

        public CadastrarEmpresaHandler(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public ICommandResult Handler(CadastrarEmpresaCommand command)
        {
            //Validamos os dados
            command.Validar();

            //Caso os dados sejam inválidos, retornamos um erro
            if (!command.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Criamos uma nova instância de Empresa
            var newEmpresa = new Entidades.Empresa(command.NomeEmpresa, command.QualificacaoTecnica, command.QualificacaoComercial,command.IdRedeSociais, command.IdPontuacao, command.IdTipoStatus, command.IdTipoMomentoEmpresa, command.IdUsuario ,command.Cnpj, command.MarcaProduto);

            //Se os dados forem inválidos, retornamos um erro
            if (!newEmpresa.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Se não, cadastramos as informações no banco de dados
            _empresaRepositorio.Cadastrar(newEmpresa);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Nova pessoa contato cadastrada com sucesso", null);

        }
    }
}
