-------------------------------------------------------------------------------------
-- Trabalho Prático de Avaliação da UFCD 5411 – Base de Dados – Sistemas de Gestão --
-- Módulo User_Profile															   --
-- Tabela userSession															   --
-- Bruno Ferreira 17/10/2018													   --
-------------------------------------------------------------------------------------


-- preset databse
use TrabalhoSQL
go

-- preenche a tabela userSession com 1 login e respectivo logout
--login
declare @begin datetime
set @begin = dateadd(DD, -1, cast(getdate() as date))
exec userLogin 1, @begin, '10.0.0.1', 'agent IE', 'admin'
--logout
declare @end datetime
set @end   = getdate()
exec userLogout 2, @end





