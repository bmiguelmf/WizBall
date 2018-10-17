-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela Permission															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir permissions
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure insertPermission 
	@name			varchar(60),
	@description	varchar(200) = null,
	@createdBy		varchar(15)
as begin
	
	-- valida todos os parametros
	if(@name	    is not null and @name			!= '' and
	   @createdBy	is not null and @createdBy		!= '')
	begin

		-- valida se o parametro createdBy corresponde a um user v�lido
		declare @userId int
		set @userId =  (SELECT TOP 1 userId FROM [user] WHERE username = @createdBy)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@userId > 0)
		begin
			insert into permission values(@name, @description, @createdBy, getdate())

			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar update a permissions
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure updatePermission
	@permissionId	int,
	@name			varchar(60),
	@description	varchar(200) = null
as begin
	
	-- valida todos os parametros
	if(@permissionId	> 0  and
	   @name is not null and @name	!= '')
	begin

	
		-- valida se o parametro permissionId corresponde a uma permission v�lida
		declare @isPermissionValid int
		set @isPermissionValid =  (SELECT TOP 1 permissionId FROM permission WHERE permissionId = @permissionId)

		-- se isPermissionValid maior que um, significa que a permission existe, ent�o pode fazer o update
		if(@isPermissionValid > 0)
		begin
			update permission set name			= @name,
								  description   = @description
						   where permissionId   = @permissionId
			
			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar delete de permissions
-- valida se os parametros v�m preenchidos e n�o nulos
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido
create or alter procedure deletePermission
	@permissionId			int
as begin
	
	-- valida o parametro
	if(@permissionId > 0)
	begin
	
		-- valida se o parametro userId corresponde a um user v�lido
		declare @isPermissionValid int
		set @isPermissionValid =  (SELECT TOP 1 permissionId FROM permission WHERE permissionId = @permissionId)

		-- se permissionId maior que um, significa que a permission existe, ent�o pode fazer o delete
		if(@isPermissionValid > 0)
		begin
			delete from permission where permissionId = @permissionId
			
			return 1
		end
			
	end

	return -1
end
go