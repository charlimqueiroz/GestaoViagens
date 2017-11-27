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