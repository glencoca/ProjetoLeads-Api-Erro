using Flunt.Notifications;
using ProjetoLeads.Comum.Commands;
using ProjetoLeads.Comum.Handlers.Contracts;
using ProjetoLeads.Dominio.Commands.Pontuacao;
using ProjetoLeads.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Dominio.Handlers.Commands.Pontuação
{
    class AtualizarPontuacaoHandler : Notifiable<Notification>, IHandler<AtualizarPontuacaoCommand>
    {

        private IPontuacaoRepositorio _pontuacaoRepositorio;

        public AtualizarPontuacaoHandler(IPontuacaoRepositorio pontuacaoRepositorio)
        {
            _pontuacaoRepositorio = pontuacaoRepositorio;
        }

        public ICommandResult Handler(AtualizarPontuacaoCommand command)
        {
            // Passamos os novos dados para o usuário
            var pontuacaoBuscado = _pontuacaoRepositorio.BuscarPorId(command.IdPontuacao);


            //Validamos os dados
            if (!pontuacaoBuscado.IsValid)
            {
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            }

            //Alteramos a pontuação
            pontuacaoBuscado.AlterarPontuacao(command.PontuacaoEmpresa);

            //Caso os dados forem válidos, chamamos o método para alterar
            _pontuacaoRepositorio.Atualizar(pontuacaoBuscado);

            return new GenericCommandResult(false, "Dados alterados com sucesso", null);
        }
    }
}




