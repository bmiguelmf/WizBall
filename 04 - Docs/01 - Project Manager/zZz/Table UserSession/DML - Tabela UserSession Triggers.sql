-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela UserSession 												   	  		           --
-- Bruno Ferreira 19/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

create or alter trigger trigge_userSessionLogs on userSession  after insert, delete, update
as begin
	declare @tableName		varchar(25)			= 'userSession ';
	declare @actionType		varchar(10);
	declare @contents		varchar(max);
	declare @userId			int;
	


	-- delete
	if not exists(select * from inserted)
		
		begin

			set @actionType = 'Delete';
			set @contents	= 'Delete do registo de userSession  n� ' + convert(varchar(10), (select userSessionId from deleted));
			
			set @userId = (select top 1 userId from [user] where username = (select createdBy from deleted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end


	-- insert
	else if not exists(select * from deleted)

		begin

			set @actionType = 'Insert';
			set @contents	= 'Insert do registo de userSession  n� ' + convert(varchar(10), (select userSessionId from inserted));

			set @userId = (select top 1 userId from [user] where username = (select createdBy from inserted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end


	-- update
	else

		begin
			
			set @actionType = 'Update';
			set @contents	= 'Update do registo de userSession  n� ' + convert(varchar(10), (select userSessionId from inserted));

			set @userId = (select top 1 userId from [user] where username = (select createdBy from deleted));

			exec insertLog @tableName, @actionType, @contents, @userId

		end
end