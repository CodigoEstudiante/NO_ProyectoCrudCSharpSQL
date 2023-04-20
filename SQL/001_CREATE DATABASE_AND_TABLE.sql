use master
go
IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases WHERE NAME = 'DBPRUEBAS')
CREATE DATABASE DBPRUEBAS

GO 

USE DBPRUEBAS

GO

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'PERSONA')
create table PERSONA(
IdPersona int primary key identity(1,1),
DocumentoIdentidad varchar(60),
Nombres varchar(60),
Apellidos varchar(60),
Telefono varchar(60),
Foto varbinary(max) NULL,
Activo bit default 1,
FechaRegistro datetime default getdate()
)

go

select * from dbo.PERSONA