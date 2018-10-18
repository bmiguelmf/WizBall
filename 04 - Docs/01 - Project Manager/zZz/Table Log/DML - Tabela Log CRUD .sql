-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela Log															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir log
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure insertLog
	@tableName			varchar(25),
	@actionType			varchar(20),
	@contents			varchar(max),
	@userId				int

as begin
	
	-- valida todos os parametros
	if(@tableName	    is not null and @tableName			!= '' and
	   @actionType		is not null and @actionType			!= '' and
	   @contents		is not null and @contents			!= '' and
	   @userId > 0)
	begin

		-- valida se o parametro createdBy corresponde a um user v�lido
		declare @isUserIdValid int
		set @isUserIdValid = (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@isUserIdValid > 0)
		begin
			insert into log values(@tableName, @actionType, @contents, @userId, getdate())

			return 1
		end
			
	end

	return -1
end
go