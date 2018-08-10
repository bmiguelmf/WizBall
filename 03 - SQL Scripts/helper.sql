use wizball
go

delete from matches
delete from teams
delete from competitions
delete from seasons
delete from areas

select * from tips
select * from areas
select * from seasons where id= 160
select * from competitions where name like '%Premier League%'
select * from competitions where id = 2003
select * from teams where id = 516 or id = 511
select * from matches order by utc_date asc
select * from matches where id = 238996
select * from users
select * from user_history

select * from teams where id = 1903

select * from competitions
inner join areas on competitions.area_id = areas.id
order by competitions.id asc

select * from matches
order by utc_date asc

select * from areas