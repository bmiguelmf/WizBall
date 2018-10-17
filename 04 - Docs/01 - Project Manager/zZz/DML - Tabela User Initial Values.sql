-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela User												   	  		           --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- cria o utilizador admin
-- este utilizador � necess�rio, uma vez que os demais utilizadores necessitam que exista um utilizador para poder ser passado para o par�metro createBy
insert into [user] values('admin', 'admin', 'admin@admin.com', 'admin', 'superadmin', 1, 'admin.jpg', 'admin', GETDATE())


-- preenche a tabela users com 3 utilizadors
exec insertUser 'Jo�o',   'Marques', 'joao@gmail.com',  'johny', '123123',	  1, 'user.jpg', 'admin'
exec insertUser 'Miguel', 'Silva',   'mikel@gmail.com', 'magic', 'mikel1999', 1, 'user.jpg', 'admin'
exec insertUser 'Ruben',  'Dias',    'ruben@gmail.com', 'lucky', 'mikel1999', 1, 'user.jpg', 'admin'





