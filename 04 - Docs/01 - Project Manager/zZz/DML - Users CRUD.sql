-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para inserir users
-- valida se as variaveis v�m preenchidas e n�o nulas
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido.
alter procedure insertUser 
	@firstName		varchar(30),
	@lastName		varchar(30),
	@email			varchar(60),
	@username		varchar(15),
	@password		varchar(15),
	@active			bit		   ,
	@profileImg		varchar(128),
	@createBy	    varchar(128)
as begin
	
	-- valida todos os parametros
	if((@firstName	is not null and @firstName	!= '') and
	   (@lastName	is not null and @lastName	!= '') and
	   (@email		is not null and @email		!= '') and
	   (@username	is not null and @username	!= '') and
	   (@password	is not null and @password	!= '') and
	    @active		is not null and
	   (@profileImg	is not null and @profileImg	!= '') and
	   (@createBy	is not null and @createBy	!= ''))
	begin

		-- valida se o parametro createBy � um user v�lido.
		declare @userId int
		set @userId =  (SELECT TOP 1 [user].userId FROM [user] WHERE [user].username = @createBy)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@userId > 0)
		begin
			insert into [user] values(@firstName, @lastName, @email, @username, @password, @active, @profileImg, @createBy, getdate())

			return 1
		end
			
	end

	return -1
end
go


-- cria um stored procedure para realizar update a users
-- valida se as variaveis v�m preenchidas e n�o nulas
-- retorna 1 se tudo correr bem, e -1 se algum algum dos parametros for inv�lido.
alter procedure updateUser 
	@userId			int,
	@firstName		varchar(30),
	@lastName		varchar(30),
	@email			varchar(60),
	@username		varchar(15),
	@password		varchar(15),
	@active			bit		   ,
	@profileImg		varchar(128)
as begin

print 'update'
	
	-- valida todos os parametros
	if( @userId	> 0  and
	   (@firstName	is not null and @firstName	!= '') and
	   (@lastName	is not null and @lastName	!= '') and
	   (@email		is not null and @email		!= '') and
	   (@username	is not null and @username	!= '') and
	   (@password	is not null and @password	!= '') and
	    @active		is not null and
	   (@profileImg	is not null and @profileImg	!= ''))
	begin

	
		-- valida se o parametro userId corresponde a um user v�lido.
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 [user].userId FROM [user] WHERE [user].userId = @userId)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@isUserValid > 0)
		begin
			update [user] set firstName  = @firstName,
						      lastName   = @lastName,
							  email		 = @email,
							  username	 = @username,
							  [password] = @password,
							  active	 = @active,
							  profileImg = @profileImg
						  where userId   = @userId
			
			return 1
		end
			
	end

	return -1
end