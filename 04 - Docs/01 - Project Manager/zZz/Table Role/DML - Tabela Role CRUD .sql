-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela Role															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir role
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure insertRole 
	@name			varchar(60),
	@description	varchar(200) = null,
	@createdBy		varchar(15)
as begin
	
	-- valida todos os parametros
	if(@name	    is not null and @name			!= '' and
	   @createdBy	is not null and @createdBy		!= '')
	begin

		-- valida se o parametro createdBy corresponde a um user válido
		declare @userId int
		set @userId = (SELECT TOP 1 userId FROM [user] WHERE username = @createdBy)

		-- se userId maior que um, significa que o user existe, então pode fazer o insert
		if(@userId > 0)
		begin
			insert into [role] values(@name, @description, @createdBy, getdate())

			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar update a roles
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure updateRole
	@roleId			int,
	@name			varchar(60),
	@description	varchar(200) = null
as begin
	
	-- valida todos os parametros
	if(@roleId	> 0  and
	   @name is not null and @name	!= '')
	begin

	
		-- valida se o parametro roleId corresponde a uma role válida
		declare @isRoleValid int
		set @isRoleValid =  (SELECT TOP 1 roleId FROM role WHERE roleId = @roleId)

		-- se isPermissionValid maior que um, significa que a permission existe, então pode fazer o update
		if(@isRoleValid > 0)
		begin
			update role set name				= @name,
								  description   = @description
						   where roleId			= @roleId
			
			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar delete de roles
-- valida se os parametros vêm preenchidos e não nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inválido
create or alter procedure deleteRole
	@roleId			int
as begin
	
	-- valida o parametro
	if(@roleId > 0)
	begin
	
		-- valida se o parametro userId corresponde a um user válido
		declare @isRoleValid int
		set @isRoleValid =  (SELECT TOP 1 roleId FROM role WHERE roleId = @roleId)

		-- se roleId maior que um, significa que a role existe, então pode fazer o delete
		if(@isRoleValid > 0)
		begin
			delete from [role] where roleId = @roleId
			
			return 1
		end
			
	end

	return -1
end
go