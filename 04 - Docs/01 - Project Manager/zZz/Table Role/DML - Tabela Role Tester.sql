-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela Role															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- teste ao stored procedure insertRole
declare @insertedRole int;
exec @insertedRole = insertRole 'Administrator', 'Rule para administradores', 'admin'
print @insertedRole


-- teste ao stored procedure updateRole
declare @updateRole int;
exec @updateRole = updateRole 2, 'Moderator', 'Rule para moderators'
print @updateRole


-- teste ao stored procedure deleterole
declare @deletedRole int;
exec @deletedRole = deleteRole 3
print @deletedRole


