-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela Permission															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go


-- preenche a tabela permission com 2 permissions
exec insertPermission 'Admin Control', 'Full data base control', 'admin'
exec insertPermission 'Moderator Control', 'Partial data base control', 'admin'



