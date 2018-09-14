use wizball
go

select  home_team_id, MIN(utc_date)

from matches

where utc_date >= CONVERT(date, getdate()) 
and	  competition_id = 2017

group by home_team_id


select  distinct home_team_id
from matches
where competition_id = 2017

select top 1 * from matches





