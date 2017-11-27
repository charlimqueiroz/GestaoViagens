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

CREATE UNIQUE NONCLUSTERED INDEX [IdxPlaca] ON [dbo].[VEICULO]
( [Placa] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO