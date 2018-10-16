-- preset databse
use TrabalhoSQL
go

-- teste insertUser
declare @result int;
exec @result = insertUser 'bruno', 'ferreira', 'bmiguelmf@gmail.com', 'bro', 'fds', 1, 'user.jpg', 'bro'
print @result

 -- teste updateUser
declare @upUser int;
exec @upUser = updateUser 1, 'miguel', 'moita', 'ola@gmail.com', 'bro', '123123', 0, 'user.jpg'
print @upUser


SELECT TOP 1 [user].userId FROM [user] WHERE [user].userId = 1