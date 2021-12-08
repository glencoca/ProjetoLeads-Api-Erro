using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProjetoLeads.Dominio;
using ProjetoLeads.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Infra.Data.Contexts
{
    public class ProjetoLeadsContext : DbContext
    {

        public ProjetoLeadsContext(DbContextOptions<ProjetoLeadsContext> options) : base(options)
        {
        }

            public DbSet<Proposta> Propostas { get; set; }
            public DbSet<Pontuacao> Pontuacoes { get; set; }
            public DbSet<Empresa> Empresas { get; set; }
            public DbSet<Historico> Historicos { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<TipoAlteracao> TiposAlteracao { get; set; }
            public DbSet<TipoStatus> TiposStatus { get; set; }
            public DbSet<RedesSociais> RedesSociais { get; set; }
            public DbSet<PessoaContato> PessoasContato { get; set; }
            public DbSet<Reuniao> Reunioes { get; set; }
            public DbSet<TipoMomentoEmpresa> TiposMomentoEmpresa { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            #region Mapeamento da Tabela Usuario

            //Muda o nome da tabela
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Nome).IsRequired();

            //Email
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Email).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Email).IsRequired();

            //Senha
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Senha).IsRequired();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();


            //Tipo Usuario
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.TipoUsuario).IsRequired();

            //Ativo / Inativo
            modelBuilder.Entity<Usuario>().Property(x => x.Ativo).HasMaxLength(40);
            modelBuilder.Entity<Usuario>().Property(x => x.Ativo).HasColumnType("varchar(40)");
            modelBuilder.Entity<Usuario>().Property(x => x.Ativo).IsRequired();

            #endregion

            #region Mapeamento da Tabela TipoStatus

            modelBuilder.Entity<TipoStatus>().ToTable("TipoStatus");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<TipoStatus>().Property(x => x.Id);

            //Nome Tipo Status
            modelBuilder.Entity<TipoStatus>().Property(x => x.NomeTipoStatus).HasMaxLength(40);
            modelBuilder.Entity<TipoStatus>().Property(x => x.NomeTipoStatus).HasColumnType("varchar(40)");
            modelBuilder.Entity<TipoStatus>().Property(x => x.NomeTipoStatus).IsRequired();
            //Cor Tipo Status
            modelBuilder.Entity<TipoStatus>().Property(x => x.CorTipoStatus).HasMaxLength(40);
            modelBuilder.Entity<TipoStatus>().Property(x => x.CorTipoStatus).HasColumnType("varchar(40)");
            modelBuilder.Entity<TipoStatus>().Property(x => x.CorTipoStatus).IsRequired();
            #endregion

            #region Mapeamento da Tabela TipoMomentoEmpresa

            modelBuilder.Entity<TipoMomentoEmpresa>().ToTable("TipoMomentoEmpresa");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<TipoMomentoEmpresa>().Property(x => x.Id);

            //NomeTipoMomentoEmpresa
            modelBuilder.Entity<TipoMomentoEmpresa>().Property(x => x.NomeTipoMomentoCliente).HasMaxLength(40);
            modelBuilder.Entity<TipoMomentoEmpresa>().Property(x => x.NomeTipoMomentoCliente).HasColumnType("varchar(40)");
            modelBuilder.Entity<TipoMomentoEmpresa>().Property(x => x.NomeTipoMomentoCliente).IsRequired();


            #endregion

            #region Mapeamento da Tabela TipoAlteracao

            modelBuilder.Entity<TipoAlteracao>().ToTable("TipoAlteracao");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<TipoAlteracao>().Property(x => x.Id);

            //NomeTipoAlteracao
            modelBuilder.Entity<TipoAlteracao>().Property(x => x.NomeTipoAlteracao).HasMaxLength(40);
            modelBuilder.Entity<TipoAlteracao>().Property(x => x.NomeTipoAlteracao).HasColumnType("varchar(40)");
            modelBuilder.Entity<TipoAlteracao>().Property(x => x.NomeTipoAlteracao).IsRequired();

            #endregion

            #region Mapeamento da Tabela Reuniao

            //Id Usuario
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //Id Pessoa Contato
            modelBuilder.Entity<PessoaContato>().Property(x => x.Id);

            //Data e Hora
            modelBuilder.Entity<Reuniao>().Property(x => x.DataHora).HasColumnType("DateTime");
            modelBuilder.Entity<Reuniao>().Property(x => x.DataHora).HasDefaultValueSql("getdate()");

            #endregion

            #region Mapeamento da Tabela RedesSociais

            modelBuilder.Entity<RedesSociais>().ToTable("RedesSociais");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<RedesSociais>().Property(x => x.Id);

            //Telefone
            modelBuilder.Entity<RedesSociais>().Property(x => x.Telefone).HasMaxLength(40);
            modelBuilder.Entity<RedesSociais>().Property(x => x.Telefone).HasColumnType("varchar(40)");
            modelBuilder.Entity<RedesSociais>().Property(x => x.Telefone).IsRequired();

            //Email 
            modelBuilder.Entity<RedesSociais>().Property(x => x.Email).HasMaxLength(250);
            modelBuilder.Entity<RedesSociais>().Property(x => x.Email).HasColumnType("varchar(250)");
            modelBuilder.Entity<RedesSociais>().Property(x => x.Email).IsRequired();

            //LinkLinkedin 
            modelBuilder.Entity<RedesSociais>().Property(x => x.LinkLinkedin).HasMaxLength(250);
            modelBuilder.Entity<RedesSociais>().Property(x => x.LinkLinkedin).HasColumnType("varchar(250)");
            modelBuilder.Entity<RedesSociais>().Property(x => x.LinkLinkedin).IsRequired();



            #endregion

            #region Mapeamento da Tabela Proposta

            //IdUsuario
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //IdEmpresa 
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            //NomeArquivo 
            modelBuilder.Entity<Proposta>().Property(x => x.NomeArquivo).HasMaxLength(250);
            modelBuilder.Entity<Proposta>().Property(x => x.NomeArquivo).HasColumnType("varchar(250)");
            modelBuilder.Entity<Proposta>().Property(x => x.NomeArquivo).IsRequired();

            //TamanhoArquivo 
            modelBuilder.Entity<Proposta>().Property(x => x.TamanhoArquivo).HasColumnType("int");

            //Arquivo 
            modelBuilder.Entity<Proposta>().Property(x => x.Arquivo).HasColumnType("longblob");

            #endregion

            #region Mapeamento da Tabela Pontuacao

            modelBuilder.Entity<RedesSociais>().ToTable("RedesSociais");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<Pontuacao>().Property(x => x.Id);

            //PontuacaoEmpresa
            modelBuilder.Entity<Pontuacao>().Property(x => x.PontuacaoEmpresa).HasMaxLength(40);
            modelBuilder.Entity<Pontuacao>().Property(x => x.PontuacaoEmpresa).HasColumnType("tinyint");
            modelBuilder.Entity<Pontuacao>().Property(x => x.PontuacaoEmpresa).IsRequired();

            #endregion

            #region Mapeamento da Tabela PessoaContato

            modelBuilder.Entity<PessoaContato>().ToTable("PessoContato");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<PessoaContato>().Property(x => x.Id);

            //Nome
            modelBuilder.Entity<PessoaContato>().Property(x => x.Nome).HasMaxLength(40);
            modelBuilder.Entity<PessoaContato>().Property(x => x.Nome).HasColumnType("varchar(40)");
            modelBuilder.Entity<PessoaContato>().Property(x => x.Nome).IsRequired();

            //Setor 
            modelBuilder.Entity<PessoaContato>().Property(x => x.Setor).HasMaxLength(40);
            modelBuilder.Entity<PessoaContato>().Property(x => x.Setor).HasColumnType("varchar(40)");
            modelBuilder.Entity<PessoaContato>().Property(x => x.Setor).IsRequired();

            //IdEmpresa 
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            //IdRedesSociais 
            modelBuilder.Entity<RedesSociais>().Property(x => x.Id);

            //Imagem 
            modelBuilder.Entity<PessoaContato>().Property(x => x.Area).HasColumnType("image");

            //Area
            modelBuilder.Entity<PessoaContato>().Property(x => x.Area).HasMaxLength(40);
            modelBuilder.Entity<PessoaContato>().Property(x => x.Area).HasColumnType("varchar(40)");
            modelBuilder.Entity<PessoaContato>().Property(x => x.Area).IsRequired();

            //Cargo
            modelBuilder.Entity<PessoaContato>().Property(x => x.Cargo).HasMaxLength(40);
            modelBuilder.Entity<PessoaContato>().Property(x => x.Cargo).HasColumnType("varchar(40)");
            modelBuilder.Entity<PessoaContato>().Property(x => x.Cargo).IsRequired();

            //DataInicio

            modelBuilder.Entity<PessoaContato>().Property(x => x.DataInicio).HasColumnType("DateTime");
            modelBuilder.Entity<PessoaContato>().Property(x => x.DataInicio);


            #endregion

            #region Mapeamento da Tabela Historico

            modelBuilder.Entity<Historico>().ToTable("Historico");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<Historico>().Property(x => x.Id);

            //DataAlteracao
            modelBuilder.Entity<Historico>().Property(x => x.DataAlteracao).HasColumnType("DateTime");
            modelBuilder.Entity<Historico>().Property(x => x.DataAlteracao).HasDefaultValueSql("getdate()");

            //IdEmpresa 
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            //IdUsuario 
            modelBuilder.Entity<Usuario>().Property(x => x.Id);

            //EnTipoAlteracao 
            modelBuilder.Entity<Historico>().Property(x => x.EnTipoAlteracao).HasMaxLength(40);
            modelBuilder.Entity<Historico>().Property(x => x.EnTipoAlteracao).HasColumnType("varchar(40)");
            modelBuilder.Entity<Historico>().Property(x => x.EnTipoAlteracao).IsRequired();

            //Dados
            modelBuilder.Entity<Historico>().Property(x => x.Dados).HasMaxLength(250);
            modelBuilder.Entity<Historico>().Property(x => x.Dados).HasColumnType("varchar(250)");
            modelBuilder.Entity<Historico>().Property(x => x.Dados).IsRequired();

            #endregion

            #region Mapeamento da Tabela Empresa

            modelBuilder.Entity<Empresa>().ToTable("Empresa");

            //Determinar chaves, não precisa determinar como primary Key já que está nomeado como ID
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            //NomeEmpresa 
            modelBuilder.Entity<Empresa>().Property(x => x.NomeEmpresa).HasMaxLength(40);
            modelBuilder.Entity<Empresa>().Property(x => x.NomeEmpresa).HasColumnType("varchar(40)");
            modelBuilder.Entity<Empresa>().Property(x => x.NomeEmpresa).IsRequired();

            //QualificacaoTecnica 
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoTecnica).HasMaxLength(40);
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoTecnica).HasColumnType("varchar(40)");
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoTecnica).IsRequired();

            //QualificacaoComercial 
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoComercial).HasMaxLength(40);
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoComercial).HasColumnType("varchar(40)");
            modelBuilder.Entity<Empresa>().Property(x => x.QualificacaoComercial).IsRequired();

            //IdRedeSociais 
            modelBuilder.Entity<RedesSociais>().Property(x => x.Id);

            //IdPontuacao 
            modelBuilder.Entity<Pontuacao>().Property(x => x.Id);

            //IdTipoStatus 
            modelBuilder.Entity<Empresa>().Property(x => x.Id);

            //IdTipoMomentoEmpresa
            modelBuilder.Entity<TipoMomentoEmpresa>().Property(x => x.Id);


            //Cnpj 
            modelBuilder.Entity<Empresa>().Property(x => x.Cnpj).HasMaxLength(40);
            modelBuilder.Entity<Empresa>().Property(x => x.Cnpj).HasColumnType("varchar(40)");
            modelBuilder.Entity<Empresa>().Property(x => x.Cnpj).IsRequired();

            //MarcaProduto
            modelBuilder.Entity<Empresa>().Property(x => x.MarcaProduto).HasMaxLength(250);
            modelBuilder.Entity<Empresa>().Property(x => x.MarcaProduto).HasColumnType("varchar(250)");
            modelBuilder.Entity<Empresa>().Property(x => x.MarcaProduto).IsRequired();

            #endregion


            base.OnModelCreating(modelBuilder);
        }

    }
}
