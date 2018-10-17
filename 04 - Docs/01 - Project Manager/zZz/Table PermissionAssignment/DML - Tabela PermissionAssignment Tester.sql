-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela permissionAssignment															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go



-- teste ao stored procedure insertPermissionAssignment
declare @insertedAssignment int;
exec @insertedAssignment = insertPermissionAssignment 1, 1, 1, 'admin'
print @insertedAssignment


-- teste ao stored procedure updatePermissionAssignment
declare @updateddAssignment int;
exec @updateddAssignment = updatePermissionAssignment 2,2,1
print @updateddAssignment


---- teste ao stored procedure deleteUserSession
--declare @deletedUserSession int;
--exec @deletedUserSession = deleteUserSession 1
--print @deletedUserSession


