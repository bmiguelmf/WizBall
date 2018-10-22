-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela UserSession															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para realizar delete de userSessions
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure deleteUserSession
	@userSessionId			int
as begin
	
	-- valida o parametro
	if(@userSessionId > 0)
	begin
	
		-- valida se o parametro userId corresponde a um user v�lido
		declare @isUserSessionValid int
		set @isUserSessionValid =  (SELECT TOP 1 userSessionId FROM userSession WHERE userSessionId = @userSessionId)

		-- se roleId maior que um, significa que a role existe, ent�o pode fazer o delete
		if(@isUserSessionValid > 0)
		begin
			delete from userSession where userSessionId = @userSessionId
			
			return 1
		end
			
	end

	return -1
end
go