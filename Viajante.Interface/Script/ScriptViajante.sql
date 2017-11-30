create database VIAJANTE
go

use VIAJANTE
go

create table VEICULO (
   Id					bigint			not null IDENTITY(1,1),
   Placa				varchar(7)		not null,
   Chassi				varchar(30)		not null,
   Marca				varchar(30)		not null,
   Modelo				varchar(30)		not null,
   AnoModelo			int				not null,
   AnoFabricacao		int				not null,
   Inativo				bit				not null,
   constraint PK_VEICULO primary key (Id)
)
GO

------------------------------------------------------------
CREATE TABLE [dbo].[telefone](
	[Id] [bigint] NOT NULL  IDENTITY(1,1),
	[Numero] [varchar](15) NOT NULL,
	[Tipo] [tinyint] NOT NULL
 CONSTRAINT [PK_TELEFONE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------
CREATE TABLE [dbo].[unidade_federacao](
	[Id] [bigint] NOT NULL  IDENTITY(1,1),
	[Sigla] [char](2) NOT NULL,
	[Nome] [varchar](25) NOT NULL
 CONSTRAINT [PK_UNIDADE_FEDERACAO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

------------------------------------------------------------
CREATE TABLE [dbo].[cidade](
	[Id] [bigint] NOT NULL  IDENTITY(1,1),
	[UnidadeFederacao_Id] [bigint] NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Longitude] [decimal](18, 16) NOT NULL,
	[Latitude] [decimal](18, 16) NOT NULL,
	[CodigoIBGE] [varchar](7) NULL
 CONSTRAINT [PK_CIDADE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cidade]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacao] FOREIGN KEY([UnidadeFederacao_Id])
REFERENCES [dbo].[unidade_federacao] ([Id])
GO

ALTER TABLE [dbo].[cidade] CHECK CONSTRAINT [FK_UnidadeFederacao]
GO

------------------------------------------------------------
CREATE TABLE [dbo].[endereco](
	[Id] [bigint] NOT NULL  IDENTITY(1,1),
	[UnidadeFederacao_Id] [bigint] NULL,
	[Cidade_Id] [bigint] NULL,
	[TipoLogradouro] [tinyint] NOT NULL,
	[Logradouro] [varchar](50) NOT NULL,
	[Numero] [varchar](15) NOT NULL,
	[Complemento] [varchar](20) NOT NULL,
	[TipoBairro] [tinyint] NOT NULL,
	[Bairro] [varchar](30) NOT NULL,
	[Cep] [char](8) NOT NULL,
	[Longitude] [decimal](18, 16) NOT NULL,
	[Latitude] [decimal](18, 16) NOT NULL
 CONSTRAINT [PK_ENDERECO] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[endereco]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacaoEndereco] FOREIGN KEY([UnidadeFederacao_Id])
REFERENCES [dbo].[unidade_federacao] ([Id])
GO

ALTER TABLE [dbo].[endereco] CHECK CONSTRAINT [FK_UnidadeFederacaoEndereco]
GO

ALTER TABLE [dbo].[endereco]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacaoCidade] FOREIGN KEY([Cidade_Id])
REFERENCES [dbo].[cidade] ([Id])
GO

ALTER TABLE [dbo].[endereco] CHECK CONSTRAINT [FK_UnidadeFederacaoCidade]
GO

------------------------------------------------------------
CREATE TABLE pessoa(
	[Id] [bigint] NOT NULL  IDENTITY(1,1),
	[Endereco_Id] [bigint] NULL,
	[Telefone_Id] [bigint] NULL,
	[TipoHeranca] [tinyint] NOT NULL,
	[CpfCnpj] [varchar](18) NOT NULL,
	[InscricaoEstadual] [varchar](16) NOT NULL,
	[InscricaoMunicipal] [varchar](15) NOT NULL,
	[Tipo] [tinyint] NOT NULL,
	[Site] [varchar](60) NOT NULL,
	[Email] [varchar](60) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Sexo] [tinyint] NOT NULL,
	[RazaoSocial] [varchar](60) NOT NULL,
	[NumeroIdentidade] [varchar](15) NOT NULL,
	[OrgaoExpedidorIdentidade] [varchar](15) NOT NULL,
	[UnidadeFederacaoIdentidade_Id] [bigint] NULL,
	[Nacionalidade] [varchar](30) NOT NULL,
	[EstadoCivil] [tinyint] NOT NULL,
	[Profissao] [varchar](50) NOT NULL
 CONSTRAINT [PK_PESSOA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[pessoa]  WITH CHECK ADD  CONSTRAINT [FK_UnidadeFederacaoPessoa] FOREIGN KEY([UnidadeFederacaoIdentidade_Id])
REFERENCES [dbo].[unidade_federacao] ([Id])
GO

ALTER TABLE [dbo].[pessoa] CHECK CONSTRAINT [FK_UnidadeFederacaoPessoa]
GO

ALTER TABLE [dbo].[pessoa]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoPessoa] FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[endereco] ([Id])
GO

ALTER TABLE [dbo].[pessoa] CHECK CONSTRAINT [FK_EnderecoPessoa]
GO

ALTER TABLE [dbo].[pessoa]  WITH CHECK ADD  CONSTRAINT [FK_TelefonePessoa] FOREIGN KEY([Telefone_Id])
REFERENCES [dbo].[telefone] ([Id])
GO

ALTER TABLE [dbo].[pessoa] CHECK CONSTRAINT [FK_TelefonePessoa]
GO

------------------------------------------------------------
CREATE TABLE [dbo].[cliente](
	[Pessoa_Id] [bigint] NOT NULL,
	[Endereco_Id] [bigint] NULL,
	[Codigo] [varchar](20) NOT NULL,
CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED 
(
	[Pessoa_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_PessoaCliente] FOREIGN KEY([Pessoa_Id])
REFERENCES [dbo].[pessoa] ([Id])
GO

ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_PessoaCliente]
GO

ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoCliente] FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[endereco] ([Id])
GO

ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_EnderecoCliente]
GO

------------------------------------------------------------
CREATE TABLE [dbo].[fornecedor](
	[Pessoa_Id] [bigint] NOT NULL,
	[Endereco_Id] [bigint] NULL,
	[Codigo] [varchar](20) NOT NULL,
CONSTRAINT [PK_FORNECEDOR] PRIMARY KEY CLUSTERED 
(
	[Pessoa_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[fornecedor]  WITH CHECK ADD  CONSTRAINT [FK_PessoaFornecedor] FOREIGN KEY([Pessoa_Id])
REFERENCES [dbo].[pessoa] ([Id])
GO

ALTER TABLE [dbo].[fornecedor] CHECK CONSTRAINT [FK_PessoaFornecedor]
GO

ALTER TABLE [dbo].[fornecedor]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoFornecedor] FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[endereco] ([Id])
GO

ALTER TABLE [dbo].[fornecedor] CHECK CONSTRAINT [FK_EnderecoFornecedor]
GO

------------------------------------------------------------
