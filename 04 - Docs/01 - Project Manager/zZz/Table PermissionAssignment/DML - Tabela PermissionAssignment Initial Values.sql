-------------------------------------------------------------------------------------
-- Trabalho Pr�tico de Avalia��o da UFCD 5411 � Base de Dados � Sistemas de Gest�o --
-- M�dulo User_Profile															   --
-- Tabela permissionAssignment															   --
-- Bruno Ferreira 18/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

-- preenche a tabela permissionAssignment com 2 assignments
exec insertPermissionAssignment 1, 1, 1, 'admin'
exec insertPermissionAssignment 1, 2, 2, 'admin'






