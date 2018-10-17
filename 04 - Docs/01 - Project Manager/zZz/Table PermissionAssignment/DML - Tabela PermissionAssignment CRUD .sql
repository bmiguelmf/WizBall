-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela PermissionAssignment															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir PermissionAssignment
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure insertPermissionAssignment
	@permissionId	int,
	@roleId			int,
	@userId		    int,
	@createdBy		varchar(15)
as begin
	
	-- valida todos os parametros
	if(@permissionId > 0	and
	   @roleId		 > 0 	and
	   @userId		 > 0 	and
	   @createdBy   is not null and @createdBy  != '')
	begin

		-- valida se o parametro userId corresponde a um user v�lido
		declare @isPermissionValid int
		set @isPermissionValid = (SELECT TOP 1 permissionId FROM permission WHERE permissionId = @permissionId)

		-- valida se o parametro userId corresponde a um user v�lido
		declare @isUserValid int
		set @isUserValid = (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- valida se o parametro userId corresponde a um user v�lido
		declare @isRoleValid int
		set @isRoleValid = (SELECT TOP 1 roleId FROM [role] WHERE roleId = @roleId)

		-- valida se o parametro createdBy corresponde a um user v�lido
		declare @isCreatesByValid int
		set @isCreatesByValid = (SELECT TOP 1 userId FROM [user] WHERE username = @createdBy)


		-- se ent�o pode fazer o insert
		if(@isPermissionValid > 0 and @isRoleValid > 0 and @isCreatesByValid > 0 and @isUserValid > 0)
		begin
			insert into permissionAssignament values(@permissionId, @roleId, @userId,  @createdBy, getdate())

			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar update na PermissionAssignment
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure updatePermissionAssignment
		@permissionAssignmentId		int,
		@permissionId				int,
		@roleId						int
as begin
	
		-- valida todos os parametros
		if(@permissionId			> 0		and
		   @roleId					> 0 	and
		   @permissionAssignmentId  > 0)
		begin


		-- valida se o parametro isPermissionValid corresponde a uma permission v�lida
		declare @isPermissionValid int
		set @isPermissionValid = (SELECT TOP 1 permissionId FROM permission WHERE permissionId = @permissionId)

		-- valida se o parametro roleId corresponde a um role v�lido
		declare @isRoleValid int
		set @isRoleValid = (SELECT TOP 1 roleId FROM [role] WHERE roleId = @roleId)

		-- valida se o parametro permessionAssignmentId corresponde a uma PermissionAssignment v�lida
		declare @isPermissionAssignmentValid int
		set @isPermissionAssignmentValid = (SELECT TOP 1 permissionAssignmentId FROM permissionAssignament WHERE permissionAssignmentId = @permissionAssignmentId)


		-- se @userSessionId maior que um, significa que a permission existe, ent�o pode fazer o update
		if(@isPermissionValid > 0 and @isRoleValid > 0 and @isPermissionAssignmentValid > 0 )
		begin
			update permissionAssignament set permissionId				= @permissionId,
											 roleId						= @roleId
									   where permissionAssignmentId		= @permissionAssignmentId
			
			return 1
		end
			
	end

	return -1
end
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