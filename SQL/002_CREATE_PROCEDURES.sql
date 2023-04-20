go
use DBPRUEBAS
go
--************************ VALIDAMOS SI EXISTE EL PROCEDIMIENTO ************************--

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_CrearPersona')
DROP PROCEDURE sp_CrearPersona

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ModificarPersona')
DROP PROCEDURE sp_ModificarPersona

go

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_ObtenerPersonas')
DROP PROCEDURE sp_ObtenerPersonas

go

--************************ PROCEDIMIENTO PARA CREAR ************************--
create procedure sp_CrearPersona(
@DocumentoIdentidad varchar(60),
@Nombres varchar(60),
@Apellidos varchar(60),
@Telefono varchar(60),
@Foto varbinary(max),
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM [dbo].[PERSONA] WHERE DocumentoIdentidad =@DocumentoIdentidad)

		insert into [dbo].[PERSONA](DocumentoIdentidad,Nombres,Apellidos,Telefono,Foto) values (
		@DocumentoIdentidad,
		@Nombres,
		@Apellidos,
		@Telefono,
		@Foto
		)
	ELSE
		SET @Resultado = 0

end

go


--************************ PROCEDIMIENTO PARA MODIFICAR ************************--
create procedure sp_ModificarPersona(
@IdPersona int,
@DocumentoIdentidad varchar(60),
@Nombres varchar(60),
@Apellidos varchar(60),
@Telefono varchar(60),
@Foto varbinary(max),
@Resultado bit output
)
as
begin
	SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM [dbo].[PERSONA] WHERE DocumentoIdentidad =@DocumentoIdentidad and IdPersona != @IdPersona)
		
		update [dbo].[PERSONA] set 
		DocumentoIdentidad = @DocumentoIdentidad,
		Nombres = @Nombres,
		Apellidos = @Apellidos,
		Telefono = @Telefono,
		Foto = @Foto
		where IdPersona = @IdPersona

	ELSE
		SET @Resultado = 0

end


go

--************************ PROCEDIMIENTO PARA OBTENER ************************--
create procedure sp_ObtenerPersonas
as
begin
	select IdPersona,DocumentoIdentidad,Nombres,Apellidos,Telefono,Foto from [dbo].[PERSONA] where Activo = 1
end

