-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela Permission															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

-- preenche a tabela users com 2 rules
exec insertRole 'Administrator', 'Rule para administrators', 'admin'
exec insertRole 'Moderator', 'Rule para moderators', 'admin'




