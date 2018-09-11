use wizball
go

-- Competitons
update competitions set flag = 'bundesliga.png' where id = 2002
update competitions set flag = 'eredivisie.png' where id = 2003
update competitions set flag = 'la_liga.png' where id = 2014
update competitions set flag = 'ligue1.png' where id = 2015
update competitions set flag = 'championship.png' where id = 2016
update competitions set flag = 'primeira_liga.png' where id = 2017
update competitions set flag = 'serie_a.png' where id = 2019
update competitions set flag = 'premier_league.png' where id = 2021



-- Teams Portugal
update teams set flag = 'Benfica.ico' where id= 1903;
update teams set flag = 'SportingLisbon.ico' where id= 498;
update teams set flag = 'Porto.ico' where id= 503;
update teams set flag = 'Chaves.png' where id= 1103;
update teams set flag = 'Nacional.ico' where id= 5529;
update teams set flag = 'SantaClara.png' where id= 5530;
update teams set flag = 'VitoriaSetubal.ico' where id= 5543;
update teams set flag = 'DesportivoAves.png' where id= 5544;
update teams set flag = 'Feirense.png' where id= 5565;
update teams set flag = 'Belenenses.ico' where id= 5568;
update teams set flag = 'Maritimo.ico' where id= 5575;
update teams set flag = 'Portimonense.png' where id= 5601;
update teams set flag = 'SportingBraga.ico' where id= 5613;
update teams set flag = 'VitoriaGuimaraes.ico' where id= 5620;
update teams set flag = 'Boavista.ico' where id= 810;
update teams set flag = 'RioAve.png' where id= 496;
update teams set flag = 'Moreirense.png' where id= 583;
update teams set flag = 'Tondela.png' where id= 1049;

-- Teams Spain
update teams set flag = 'athletic_bilbaoa.ico' where id= 77;
update teams set flag = 'atletico_madrid.ico' where id= 78;
update teams set flag = 'espanyol.ico' where id= 80;
update teams set flag = 'barcelona.ico' where id= 81;
update teams set flag = 'getafe.ico' where id= 82;
update teams set flag = 'real_radrid.ico' where id= 86;
update teams set flag = 'rayo_vallecano.ico' where id= 87;
update teams set flag = 'levante.png' where id= 88;
update teams set flag = 'real_betis.ico' where id= 90;
update teams set flag = 'real_sociedad.ico' where id= 92;
update teams set flag = 'villareal.ico' where id= 94;
update teams set flag = 'valencia.ico' where id= 95;
update teams set flag = 'real_valladolid.ico' where id= 250;
update teams set flag = 'deportivo_alaves.ico' where id= 263;
update teams set flag = 'eibar.png' where id= 278;
update teams set flag = 'girona.png' where id= 298;

update teams set flag = 'huesca.png' where id= 299;
update teams set flag = 'celta_vigo.ico' where id= 558;
update teams set flag = 'sevilla.ico' where id= 559;
update teams set flag = 'leganes.jpg' where id= 745;


select * from teams 
inner join areas on teams.area_id = areas.id
where areas.id = 2224

select * from areas