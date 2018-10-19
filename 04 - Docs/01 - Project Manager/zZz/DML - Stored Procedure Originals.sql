-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Bruno Ferreira 19/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria um stored procedure para saber total de acessos (sess�es diferentes) por utilizador entre datas;
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

		-- valida se o parametro @userId corresponde a um user v�lido
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@isUserValid > 0)
		begin
			
			select count(*) from userSession 
			where userId = @userId and
				createdOn between @startDate and @endDate

		end
	end
			
end
go


--  cria um stored procedure para saber total de tempo �logado� (com a sess�o ativa) por utilizador entre datas;
create or alter procedure getSessionTimeByUser
	@userId			int
as begin
	
	-- valida todos os parametros
	if(@userId > 0)
	begin

		-- valida se o parametro @userId corresponde a um user v�lido
		declare @isUserValid int
		set @isUserValid =  (SELECT TOP 1 userId FROM [user] WHERE userId = @userId)

		-- se userId maior que um, significa que o user existe, ent�o pode fazer o insert
		if(@isUserValid > 0)
		begin

			-- verifica se o user tem sess�o activa.
			declare @beginSession datetime = (select top(1) logOnUser from userSession where userId = @userId and logOffUser is null)

			-- ent�o calcula o tempo de sess�o
			if(@beginSession is not null)
				select datediff(minute, @beginSession, getdate()) as 'Minutos desde inicio de sess�o'

		end

	end		
end
go