﻿using System;
using System.Linq;
using System.Net.Mail;
using BusinessLogic.Entities;
using BusinessLogic.DAL;
using BusinessLogic.Resources;
using System.Collections.Generic;


namespace BusinessLogic.BLL

{
    public class BLL
    {
        // CONSTRUCTOR.
        private string apiToken;
        private string connectionString;        
        public BLL(string ConnectionString, string APIToken)
        {
            apiToken            = APIToken;
            connectionString    = ConnectionString;
        }

       

        // UTILITIES
        private DateTime? NormalizeApiDateTime(string Datetime)
        {
            if (string.IsNullOrEmpty(Datetime)) return null;

            DateTime dateTime = new DateTime();                                              
            DateTime.TryParse(Datetime,
                              null,
                              System.Globalization.DateTimeStyles.AdjustToUniversal,
                              out dateTime);

            return dateTime;
        }



        // API SYNC METHODS.
        public bool FullDatabaseSync()
        {
            //SyncAreas();              // 1 API request.
            //SyncSeasons();            // 1 API request.       
            //SyncCompetitions();       // 1 API request.
            //System.Threading.Thread.Sleep(60000);
            //SyncTeams();              // 10 API requests.
            //System.Threading.Thread.Sleep(60000);
            SyncMatchesTierOne();     // 10 API requests.

            return true;
        }
        private bool SyncAreas()
        {
            ResourceAreas resourceAreas = new ResourceAreas(apiToken);      // Object to comunicate with API football-data.org.
            DALAreas dalAreas = new DALAreas(connectionString);             // Object to comunicate with Database.

            List<Area> lstApiAreas = resourceAreas.GetAll();                // All areas available on API.
            List<Area> lstDbAreas = dalAreas.GetAll();                      // All areas available on Database.

            List<Area> lstInsertAreas = new List<Area>();                   // Temporary List<Areas> to insert.
            List<Area> lstUpdateAreas = new List<Area>();                   // Temporary List<Areas> to update.


            if (lstDbAreas.Count == 0)                                       // In case theres no record in database we can just insert all AreasApi.
            {
                dalAreas.Insert(lstApiAreas);
                return true;
            }


            foreach (Area areaApi in lstApiAreas)                           // If database has alreday some records then...
            {
                Area tempArea = dalAreas.GetById(areaApi.Id.ToString());

                if (tempArea == null)
                {
                    lstInsertAreas.Add(areaApi);
                }
                else if (areaApi.Name != tempArea.Name ||
                        areaApi.ParentAreaId != tempArea.ParentAreaId)       // Check for differences.
                {
                    lstUpdateAreas.Add(areaApi);
                }

            }

            if (lstInsertAreas.Count != 0)
                dalAreas.Insert(lstInsertAreas);
            if (lstUpdateAreas.Count != 0)
                dalAreas.Update(lstUpdateAreas);


            return true;
        }
        private bool SyncSeasons()
        {
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(apiToken);         // Object to comunicate with API football-data.org.
            DALSeasons dalSeasons = new DALSeasons(connectionString);                               // Object to comunicate with Database.

            List<Competition> lstApiCompetitions = resourceCompetitions.GetAll();                   // All competitions available on API.
            List<Season> lstDbSeasons = dalSeasons.GetAll();                                        // All seasons available on Database.

            List<Season> lstInsertSeasons = new List<Season>();                                     // Temporary List<Areas> to insert.
            List<Season> lstUpdateSeasosn = new List<Season>();                                     // Temporary List<Areas> to update.


            if (lstDbSeasons.Count == 0)                                                            // In case theres no record in database we can just insert all Seasons.
            {
                foreach (Competition competition in lstApiCompetitions)
                {
                    if (competition.CurrentSeason != null)
                        lstInsertSeasons.Add(competition.CurrentSeason);
                }

                dalSeasons.Insert(lstInsertSeasons);
                return true;
            }


            foreach (Competition competition in lstApiCompetitions)                                 // If database has alreday some records then...
            {
                if (competition.CurrentSeason != null)
                {
                    Season tempSeason = dalSeasons.GetById(competition.CurrentSeason.Id.ToString());

                    if (tempSeason == null)
                    {
                        lstDbSeasons.Add(competition.CurrentSeason);
                    }

                    else if (competition.CurrentSeason.StartDate != tempSeason.StartDate ||
                             competition.CurrentSeason.EndDate != tempSeason.EndDate)               // Checks for any difference.
                    {
                        lstUpdateSeasosn.Add(tempSeason);
                    }
                }
            }


            if (lstInsertSeasons.Count != 0)
                dalSeasons.Insert(lstInsertSeasons);
            if (lstUpdateSeasosn.Count != 0)
                dalSeasons.Update(lstUpdateSeasosn);


            return true;
        }
        private bool SyncCompetitions()
        {
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(apiToken);         // Object to comunicate with API football-data.org.
            DALCompetitions dalCompetitions = new DALCompetitions(connectionString);                // Object to comunicate with Database.

            List<Competition> lstApiCompetition = resourceCompetitions.GetAll();                    // All Competition available on API.
            List<Competition> lstDbCompetition = dalCompetitions.GetAll();                          // All Competition available on Database.

            List<Competition> lstInsertCompetition = new List<Competition>();                       // Temporary List<Competition> to insert.
            List<Competition> lstUpdateCompetition = new List<Competition>();                       // Temporary List<Competition> to update.


            if (lstDbCompetition.Count == 0)                                                        // In case theres no record in database we can just insert all CompetitionApi.
            {
                dalCompetitions.Insert(lstApiCompetition);
                return true;
            }


            foreach (Competition competitionApi in lstApiCompetition)                               // If database has alreday some records then...
            {
                Competition tempCompetition = dalCompetitions.GetById(competitionApi.Id.ToString());

                // Needed to normalize date to compare.
                DateTime compereDate = new DateTime();
                DateTime.TryParse(competitionApi.LastUpdated, null, System.Globalization.DateTimeStyles.AdjustToUniversal, out compereDate);
                string stringDate = compereDate.ToString();


                if (tempCompetition == null)
                {
                    lstInsertCompetition.Add(competitionApi);
                }
                else if (stringDate != tempCompetition.LastUpdated)
                {
                    lstUpdateCompetition.Add(competitionApi);
                }

            }

            if (lstInsertCompetition.Count != 0)
                dalCompetitions.Insert(lstInsertCompetition);
            if (lstUpdateCompetition.Count != 0)
                dalCompetitions.Update(lstUpdateCompetition);


            return true;
        }
        private bool SyncTeams()
        {
            ResourceTeams resourceTeams = new ResourceTeams(apiToken);                              // Object to comunicate with API football-data.org.           
            DALTeams dalTeams = new DALTeams(connectionString);                                     // Object to comunicate with Database.

            List<Team> lstInsertTeams = new List<Team>();                                           // Temporary List<Competition> to insert.
            List<Team> lstUpdateTeams = new List<Team>();                                           // Temporary List<Competition> to update.



            foreach (Competition competition in TierOneCompetitions())                               // Foreach tier_one competition.
            {

                List<Team> lstTeams = resourceTeams.GetByCompetition(competition.Id.ToString());   // Get all the teams from the API.


                foreach (Team apiTeam in lstTeams)                                                  // Foreach apiTeam.
                {
                    Team dbTeam = dalTeams.GetById(apiTeam.Id.ToString());                          // Get Team by Id.


                    if (dbTeam == null)                                                             // If dbTeam null then add to lstInsertTeams.
                    {
                        if (lstInsertTeams.Find(x => x.Id == apiTeam.Id) is null)                   // But first find out if lstInsertTeams has already dbTeam.
                            lstInsertTeams.Add(apiTeam);                                            // If not add to lstInsertTeams.

                        continue;
                    }

                    if (apiTeam.LastUpdated == null)                                                // If apiTeam.LastUpdated == null no need to update.
                    {
                        continue;
                    }

                    DateTime? apiTeamLastUpdated = NormalizeApiDateTime(apiTeam.LastUpdated);

                    if (apiTeamLastUpdated.ToString() != apiTeamLastUpdated.ToString())
                    {
                        lstUpdateTeams.Add(apiTeam);
                    }
                }
            }


            if (lstInsertTeams.Count != 0)
                dalTeams.Insert(lstInsertTeams);
            if (lstUpdateTeams.Count != 0)
                dalTeams.Update(lstUpdateTeams);


            return true;
        }
        private bool SyncMatchesTierOne()
        {
            DALMatches dalMatches = new DALMatches(connectionString);                                               // Object to comunicate with Database.
            ResourceMatches resourceMatches = new ResourceMatches(apiToken);                                        // Object to comunicate with API football-data.org. 

            foreach (Competition competition in TierOneCompetitions())                                              // Foreach tier_one competition.
            {
                List<Match> lstInsertMatches = new List<Match>();                                                   // Temporary list to hold insertable matches.
                List<Match> lstUpdateMatches = new List<Match>();                                                   // Temporary list to hold updatable  matches.

                List<Match> lstApiMatches = resourceMatches.GetByCompetition(competition.Id.ToString());            // Get a list of matches by competition from the Api.

                foreach (Match apiMatch in lstApiMatches)                                                           // Foreach match in lstApiMatches.
                {
                    if (apiMatch.HomeTeam.Id == 0 || apiMatch.AwayTeam.Id == 0)                                     // 0 == null. Do not insert or update.
                    {
                        continue;
                    }

                    Match dbMatch = dalMatches.GetById(apiMatch.Id.ToString());                                     // Tries to get the same match from db.

                    if (dbMatch is null)                                                                            // If no match then add match to insertable matches list.
                    {
                        lstInsertMatches.Add(apiMatch);                                                                
                    }
                    else                                                                                            // Otherwise
                    {
                        DateTime? apiLastUpdated = NormalizeApiDateTime(apiMatch.LastUpdated);                      // First normalize the datetime that came from the api to our standard.

                        if (dbMatch.LastUpdated != apiLastUpdated.ToString())                                       // if Api Last Update is diferent from the corresponding db value.
                        {
                            lstUpdateMatches.Add(apiMatch);                                                         // Add match to updatable matches list.
                        }
                    }
                }

                if (lstInsertMatches.Count != 0)
                    dalMatches.Insert(lstInsertMatches);
                if (lstUpdateMatches.Count != 0)
                    dalMatches.Update(lstUpdateMatches);
            }

            return true;
        }
        private List<Competition> TierOneCompetitions()
        {
            return new List<Competition>()                         
            {
                new Competition() {Id = 2002 },                 // Bundesliga.
                new Competition() {Id = 2003 },                 // Eredivisie.
                new Competition() {Id = 2014 },                 // PrimeraDivision.
                new Competition() {Id = 2015 },                 // Ligue1.
                new Competition() {Id = 2016 },                 // Championship.
                new Competition() {Id = 2017 },                 // PrimeiraLiga.
                new Competition() {Id = 2019 },                 // SerieA_italia.
                new Competition() {Id = 2021 }                  // PremierLeague.
            };
        }



        // API METHODS.
        public List<Area> GetAllAreas()
        {
            DALAreas dal = new DALAreas(connectionString);
            return dal.GetAll();
        }
        public List<Season> GetAllSeasons()
        {
            DALSeasons dal = new DALSeasons(connectionString);
            return dal.GetAll();
        }
        public List<Competition> GetAllCompetitions()
        {
            DALCompetitions dal = new DALCompetitions(connectionString);
            return dal.GetAll();
        }
        public List<Team> GetAllTeams()
        {
            DALTeams dal = new DALTeams(connectionString);
            return dal.GetAll();
        }
        public List<Match> GetMatchesByCompetition(string CompetitionId)
        {
            DALTeams dalTeams = new DALTeams(connectionString);
            DALMatches dalMatches = new DALMatches(connectionString);

            List<Match> lstMatches = dalMatches.GetByCompetitionId(CompetitionId);

            foreach(Match match in lstMatches)
            {
                match.HomeTeam = dalTeams.GetById(match.HomeTeam.Id.ToString());
                match.AwayTeam = dalTeams.GetById(match.AwayTeam.Id.ToString());
            }


            return lstMatches;
        }



        // USER METHODS.
        public List<User> GetAllUsers()
        {
            DALUsers dal = new DALUsers(connectionString);
            return dal.GetAll();
        }
        public User GetUserById(string Id)
        {
            DALUsers dal = new DALUsers(connectionString);
            return dal.GetById(Id);
        }
        public bool InsertUser(User User)
        {
            if (User is null)
                return false;

            List<User> lstUsers = new List<User>();
            lstUsers.Add(User);

            DALUsers dalUsers = new DALUsers(connectionString);
            dalUsers.Insert(lstUsers);

            return true;
        }
        public bool UpdatetUser(User User)
        {
            if (User is null)
                return false;

            List<User> lstUsers = new List<User>();
            lstUsers.Add(User);

            DALUsers dalUsers = new DALUsers(connectionString);
            dalUsers.Update(lstUsers);

            return true;
        }
        public User UserLogin(string Username, string Password)
        {
            DALUsers dalUsers = new DALUsers(connectionString);

            return dalUsers.Login(Username, Password);
        }
        public bool RecoverUserPassword(string Email)
        {
            DALUsers dalUsers = new DALUsers(connectionString);
            User user = dalUsers.GetByEmail(Email);

            if(user is null)
            {
                return false;
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("bmiguelmf@gmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "Wizball - Password Revover";
                mail.Body = "Hi there " + user.Username + " \n";
                mail.Body += "Your password: " + user.Password + " \n\n\n";
                mail.Body += "Wizball support team";


                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("bmiguelmf@gmail.com", "zsdoq06121984fx840Z");
                SmtpServer.EnableSsl = true;

               
                SmtpServer.Send(mail);

                return true;
            }
        }
        public bool UserMailExists(string Email)
        {
            DALUsers dalUsers = new DALUsers(connectionString);

            User user = dalUsers.GetByEmail(Email);

            if (user is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool UsernameExists(string Username)
        {
            DALUsers dalUsers = new DALUsers(connectionString);

            User user = dalUsers.GetByUsername(Username);

            if (user is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public List<UserState> GetUserStates()
        {
            DALUserStates dalUserStatess = new DALUserStates(connectionString);

            return dalUserStatess.GetAll();
        }
        public List<User> GetUsersByState(string UserStateId)
        {
            DALUsers dalUsers = new DALUsers(connectionString);

            return dalUsers.GetByState(UserStateId);
        }



        // ADMIN METHODS.
        public List<Admin> GetAllAdmins()
        {
            DALAdmins dalAdmins = new DALAdmins(connectionString);
            return dalAdmins.GetAll();
        }
        public Admin GetAdminById(string Id)
        {
            DALAdmins dalAdmins = new DALAdmins(connectionString);
            return dalAdmins.GetById(Id);
        }
        public bool InsertAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            List<Admin> lstAdmins = new List<Admin>();
            lstAdmins.Add(Admin);

            DALAdmins dalAdmins = new DALAdmins(connectionString);
            dalAdmins.Insert(lstAdmins);

            return true;
        }
        public bool UpdatetAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            List<Admin> lstAdmins = new List<Admin>();
            lstAdmins.Add(Admin);

            DALAdmins dalAdmins = new DALAdmins(connectionString);
            dalAdmins.Update(lstAdmins);

            return true;
        }
        public Admin AdminLogin(string Username, string Password)
        {
            DALAdmins dalAdmins = new DALAdmins(connectionString);

            return dalAdmins.Login(Username, Password);
        }
    }
}

