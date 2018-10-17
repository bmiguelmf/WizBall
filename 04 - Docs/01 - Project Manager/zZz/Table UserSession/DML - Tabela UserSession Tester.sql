-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela userSession															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go





-- teste ao stored procedure userLogin
declare @now datetime
set @now = getdate()
declare @insertedUserSession int;
exec @insertedUserSession = userLogin 1, @now, '10.0.0.1', 'agent IE', 'admin'
print @insertedUserSession


-- teste ao stored procedure userLogout
declare @logout datetime
set @logout = getdate()
declare @userLogout int;
exec @userLogout = userLogout 1, @logout
print @userLogout


-- teste ao stored procedure deleteUserSession
declare @deletedUserSession int;
exec @deletedUserSession = deleteUserSession 1
print @deletedUserSession


