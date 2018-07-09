using System;
using System.Linq;

using BusinessLogic.Entities;
using BusinessLogic.DAL;
using BusinessLogic.Resources;
using System.Collections.Generic;
using System.Threading;

namespace BusinessLogic.BLL
{
    public class BLL
    {
        private const string ChampionsLeague = "2000";
        private const string Bundesliga = "2002";
        private const string Eredivisie = "2003";
        private const string SerieA_brazil = "2013";
        private const string PrimeraDivision = "2014";
        private const string Ligue1 = "2015";
        private const string Championship = "2016";
        private const string PrimeiraLiga = "2017";
        private const string EuropeanChampionship = "2000";    
        private const string SerieA_italia = "2019";
        private const string PremierLeague = "2021";


        private const string TOKEN = "7f91f916023b4430b44d97cc11e5c030";


        // Bruno Home.
        private const string ConnString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";
        // Bruno ATEC
        //private const string ConnString = "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = wizball; Integrated Security = SSPI;";



        public bool InitializeDatabase()
        {
            //Areas
            ResourceAreas resourceAreas = new ResourceAreas(TOKEN);
            DALAreas dalAreas = new DALAreas(ConnString);
            dalAreas.Insert(resourceAreas.GetAll());



            // Competitions
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            dalCompetitions.Insert(resourceCompetitions.GetAll());



            // Seasons           
            List<Season> lstSeasons = new List<Season>();
            foreach (Competition comp in resourceCompetitions.GetAll()) // Tem que ser nos resources porque só os resources trazem a current season.
            {
                if (comp.CurrentSeason.StartDate != "0" && comp.CurrentSeason.EndDate != "0")
                    lstSeasons.Add(comp.CurrentSeason);
            }
            DALSeasons dalSeason = new DALSeasons(ConnString);
            dalSeason.Insert(lstSeasons);



            SyncChampionsLeague();
            SyncEuropeanChampionship();
            SyncPremierLeague();
            SyncChampionship();
            SyncPrimeraDivision();
            SyncBundesliga();
            SyncSerieA_italia();
            //SyncLigue1();
            //SyncPrimeiraLiga();
            SyncEredivisie();  
            SyncSerieA_brazil();


            return true;
        }


        // DAL Requesting Working.
        public List<Area> GetAllAreas()
        {
            DALAreas dal = new DALAreas(ConnString);
            return dal.GetAll();
        }
        public List<Season> GetAllSeasons()
        {
            DALSeasons dal = new DALSeasons(ConnString);
            return dal.GetAll();
        }
        public List<Competition> GetAllCompetitions()
        {
            DALCompetitions dal = new DALCompetitions(ConnString);
            return dal.GetAll();
        }
        public List<Team> GetAllTeams()
        {
            DALTeams dal = new DALTeams(ConnString);
            return dal.GetAll();
        }


        // Sync
        public void SyncChampionsLeague()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);
            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(ChampionsLeague);           // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncEuropeanChampionship()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);
            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(EuropeanChampionship);           // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncPremierLeague()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(PremierLeague);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncChampionship()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(Championship);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncPrimeraDivision()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(PrimeraDivision);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncBundesliga()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);
            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(Bundesliga);           // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncSerieA_italia()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(SerieA_italia);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncLigue1()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(Ligue1);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncPrimeiraLiga()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

                                                                                        // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(PrimeiraLiga);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);
            
        }     
        public void SyncEredivisie()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(Eredivisie);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }
        public void SyncSerieA_brazil()
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            // One team can play in more than one competition.       
            List<Team> lstTeams = resourceTeams.GetByCompetition(SerieA_brazil);         // So for each team we need to check if the Teams Id is already into the DB.
            List<Team> lstTeamsToInsert = new List<Team>();

            foreach (Team team in lstTeams)
            {
                if (dalTeams.GetById(team.Id.ToString()) is null)
                {
                    lstTeamsToInsert.Add(team);
                }
            }

            dalTeams.Insert(lstTeamsToInsert);

        }

    }

    
}

