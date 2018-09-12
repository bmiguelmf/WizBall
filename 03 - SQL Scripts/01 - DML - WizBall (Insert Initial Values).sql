USE wizball
GO



-- ADMINS
insert into admins values('bro', 'bmiguelmf@gmail.com', '06121984', default);
insert into admins values('passeira', 'lfmpasseira99@live.com.pt', 'passeira', default);
insert into admins values('joao', 'joao@gmail.com', 'joao', default);



-- USER STATES
insert into user_states values('Pending');
insert into user_states values('Blocked');
insert into user_states values('Granted');
go


-- USERS
insert into users values('Songoku', 'songoku@kamehameha.bola.cristal', '123', default, default, getdate(), getdate());
insert into users values('Terminator', 'terminator@t1001.net', '123', default, default, getdate(), getdate());
insert into users values('terrorist', 'head@shot.cs', '123', default, default, getdate(), getdate());
insert into users values('estoreish', 'estoreish@procidur.atec.pt', '123', default, default, getdate(), getdate());
insert into users values('one', 'fds@po.caralho.pt', '123', default, default, getdate(), getdate());



-- USERS HISTORY
);



-- MARKETS
insert into markets values('Full Time +2,5 Goals', 'ft_over_two_and_half_goals.png');


