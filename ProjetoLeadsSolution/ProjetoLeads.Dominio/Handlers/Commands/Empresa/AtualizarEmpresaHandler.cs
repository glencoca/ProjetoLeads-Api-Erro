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
    class AtualizarEmpresaHandler : Notifiable<Notification>, IHandler<AtualizarEmpresaCommand>
    {

        private IEmpresaRepositorio _empresaRepositorio;

        public AtualizarEmpresaHandler(IEmpresaRepositorio empresaRepositorio)
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

            //Verificamos a existência da Empresaaa
            var empresaBuscado = _empresaRepositorio.BuscarPorId(command.IdEmpresa);

            //Se não existir, retornamos um erro
            if (empresaBuscado == null)
            {
                return new GenericCommandResult(false, "Empresa não foi encontrada", command.Notifications);
            }

            //Realizamos a alteraçãom no command, para verificar os dados
            empresaBuscado.AtualizarEmpresa(command.NomeEmpresa, command.QualificacaoTecnica, command.QualificacaoComercial, command.IdRedeSociais, command.IdPontuacao, command.IdTipoStatus, command.IdTipoMomentoEmpresa, command.Cnpj, command.MarcaProduto);

            //Salvamos a alteração no banco de dados
            _empresaRepositorio.Atualizar(empresaBuscado);

            //Retornamos uma mensagem de sucesso
            return new GenericCommandResult(true, "Alteração realizada com sucesso", null);
        }
    }
}

