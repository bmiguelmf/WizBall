-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela User												   	  		           --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria o utilizador admin
insert into [user] values('admin', 'admin', 'admin@admin.com', 'admin', 'superadmin', 1, 'admin.jpg', 'admin', GETDATE())


-- teste ao stored procedure insertUser
declare @insertedUser int;
exec @insertedUser = insertUser 'Bruno', 'Moita', 'bmiguelmf@gmail.com', 'bro', '123123', 1, 'user.jpg', 'admin'
print @insertedUser


-- teste ao stored procedure updateUser
declare @updatedUser int;
exec @updatedUser = updateUser 7, 'miguel', 'moita', 'ola@gmail.com', 'bro', '123123', 0, 'user.jpg'
print @updatedUser


-- teste ao stored procedure deleteUser
declare @deletedUser int;
exec @deletedUser = deleteUser 4
print @deletedUser


