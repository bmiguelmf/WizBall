-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela permissionAssignment															   --
-- Bruno Ferreira 18/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

-- preenche a tabela permissionAssignment com 2 assignments
exec insertPermissionAssignment 1, 1, 1, 'admin'
exec insertPermissionAssignment 1, 2, 2, 'admin'






