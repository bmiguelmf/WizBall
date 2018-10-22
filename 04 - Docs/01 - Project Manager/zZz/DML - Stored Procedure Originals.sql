-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Bruno Ferreira 19/10/2018													   --
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



-- cria um stored procedure para saber total de acessos (sessões diferentes) por utilizador entre datas;
create or alter procedure getUserSessionCount 
	@startDate		datetime,
	@endDate		datetime,
	@userId			int
as begin
	
	-- valida todos os parametros
	if(@startDate	is not null and 
	   @endDate		is not null and 
	   @userId		> 0)
	begin

		-- valida se o parametro @userId corresponde a um user válido
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, então pode fazer o insert
		if(@isUserValid > 0)
		begin
			
			select count(*) from userSession 
			where userId = @userId and
				createdOn between @startDate and @endDate

		end
	end
			
end
go


--  cria um stored procedure para saber total de tempo “logado” (com a sessão ativa) por utilizador;
create or alter procedure getSessionTimeByUser
	@userId			int
as begin
	
	-- valida todos os parametros
	if(@userId > 0)
	begin

		-- valida se o parametro @userId corresponde a um user válido
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, então pode fazer o insert
		if(@isUserValid > 0)
		begin

			-- verifica se o user tem sessão activa.
			declare @beginSession datetime = (select top(1) logOnUser from userSession where userId = @userId and logOffUser is null)

			-- então calcula o tempo de sessão
			if(@beginSession is not null)
				select datediff(minute, @beginSession, getdate()) as 'Minutos desde inicio de sessão'

		end

	end		
end
go



--  cria um stored procedure para saber todas as permissões de um utilizador;
create or alter procedure getRolesByUser
	@userId			int
as begin
	
	-- valida todos os parametros
	if(@userId > 0)
	begin

		-- valida se o parametro @userId corresponde a um user válido
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, então pode fazer o insert
		if(@isUserValid > 0)
		begin

			select [user].userId, [user].username, [user].firstName, [user].lastName, [user].email, [permissionAssignament].createdBy, [role].[name], [role].[description] from [user]
			left join permissionAssignament on permissionAssignament.userId = [user].userId
			left join role on [role].roleId = permissionAssignament.RoleId
			where [user].userId = @userId

		end

	end		
end
go




--  cria um stored procedure para listar todos os utilizadores e respetivas regras atribuídas, com resultado paginado
-- (esta última parte é um extra valorizado);
create or alter procedure listUsersAndRoles
@rowNumber int,
@totalItems int
as begin
	
	if(@rowNumber > 0 and @totalItems > 0)
	begin
		select [user].userId, [user].username, [user].firstName, [user].lastName, [user].email, [permissionAssignament].createdBy, [role].[name], [role].[description] from [user]
		left join permissionAssignament on permissionAssignament.userId = [user].userId
		left join role on [role].roleId = permissionAssignament.RoleId
		order by [user].userId
		offset @rowNumber rows 
		fetch next @totalItems rows only
	end
end
go



--Ranking de utilizadores pelos acessos
create or alter procedure userRankSessions
as begin

	select [user].username, count(userSession.userId) as 'total user session' from [user]
	left join userSession on [user].userId = userSession.userId
	where userSession.logOffUser is not null
	group by [user].username

end
go