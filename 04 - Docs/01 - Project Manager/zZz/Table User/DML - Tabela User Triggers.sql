-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela User												   	  		           --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

create or alter trigger trigge_userLogs on [user] after insert, delete, update
as begin
	declare @tableName		varchar(25)			= 'user';
	declare @actionType		varchar(10);
	declare @contents		varchar(max);
	declare @userId			int;
	


	-- delete
	if not exists(select * from inserted)
		
		begin

			set @actionType = 'Delete';
			set @contents	= 'Delete do registo do user ' + (select username from deleted);
			
			set @userId = (select top 1 userId from [user] where username = (select createdBy from deleted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end


	-- insert
	else if not exists(select * from deleted)

		begin

			set @actionType = 'Insert';
			set @contents	= 'Insert do registo do user ' + (select username from inserted);

			set @userId = (select top 1 userId from [user] where username = (select createdBy from inserted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end


	-- update
	else

		begin
			
			set @actionType = 'Update';
			set @contents	= 'Update do registo do user ' + (select username from inserted);

			set @userId = (select top 1 userId from [user] where username = (select createdBy from deleted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end
end