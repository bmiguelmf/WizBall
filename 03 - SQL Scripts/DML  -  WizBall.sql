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


-- MARKETS
insert into markets values('Full Time +2,5 Goals', '+2,5');


-- AREAS
insert into areas values(999, 'No area', '???', null);
