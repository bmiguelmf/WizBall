use wizball
go

delete from matches
delete from teams
delete from competitions
delete from seasons
delete from areas


select * from areas
select * from seasons where id= 20
select * from competitions where name like '%Premier League%'
select * from teams where id = 526
select * from matches where id = 235686 order by utc_date asc
select * from users

select * from teams where id = 1837