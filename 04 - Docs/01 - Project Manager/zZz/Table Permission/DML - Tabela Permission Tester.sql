-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela Permission															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- teste ao stored procedure insertPermission
declare @insertedPermission int;
exec @insertedPermission = insertPermission 'Full control', null, 'admin'
print @insertedPermission


-- teste ao stored procedure updatePermision
declare @updatePermision int;
exec @updatePermision = updatePermission 1, 'Partial control', 'Grant partial db control'
print @updatePermision


-- teste ao stored procedure deleteUser
declare @deletedPermission int;
exec @deletedPermission = deletePermission 3
print @deletedPermission


