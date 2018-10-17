-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela UserSession															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir UserSession
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure userLogin
	@userId			int,
	@logOnUser		datetime,
	@ipAddress		varchar(15),
	@userAgent		varchar(50),
	@createdBy		varchar(15)
as begin
	
	-- valida todos os parametros
	if(@userId > 0										and
	   @logOnUser	is not null 						and
	   @ipAddress   is not null and @ipAddress  != ''	and
	   @userAgent   is not null and @userAgent  != ''	and
	   @createdBy   is not null and @createdBy  != '')
	begin

		-- valida se o parametro createdBy corresponde a um user válido
		declare @isCreatesByValid int
		set @isCreatesByValid = (SELECT TOP 1 userId FROM [user] WHERE username = @createdBy)

		-- valida se o parametro userId corresponde a um user válido
		declare @isUserValid int
		set @isUserValid = (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)


		-- se userId maior que um, significa que o user existe, então pode fazer o insert
		if(@isCreatesByValid > 0 and @isUserValid > 0)
		begin
			insert into userSession values(@userId, @logOnUser, null, @ipAddress, @userAgent, @createdBy, getdate())

			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar update a UserSession
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure userLogout
		@userSessionId	int,
		@logOffUser		datetime
as begin
	
	-- valida todos os parametros
	if(@userSessionId	> 0  and
	   @logOffUser        is not null)
	begin

	
		-- valida se o parametro userSessionId corresponde a uma userSession válida
		declare @isUserSessionValid int
		set @isUserSessionValid =  (SELECT TOP 1 userSessionId FROM userSession WHERE userSessionId = @userSessionId)

		-- se @userSessionId maior que um, significa que a permission existe, então pode fazer o update
		if(@isUserSessionValid > 0)
		begin
			update userSession set logOffUser		= @logOffUser
						     where userSessionId	= @userSessionId
			
			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar delete de userSessions
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure deleteUserSession
	@userSessionId			int
as begin
	
	-- valida o parametro
	if(@userSessionId > 0)
	begin
	
		-- valida se o parametro userId corresponde a um user válido
		declare @isUserSessionValid int
		set @isUserSessionValid =  (SELECT TOP 1 userSessionId FROM userSession WHERE userSessionId = @userSessionId)

		-- se roleId maior que um, significa que a role existe, então pode fazer o delete
		if(@isUserSessionValid > 0)
		begin
			delete from userSession where userSessionId = @userSessionId
			
			return 1
		end
			
	end

	return -1
end
go