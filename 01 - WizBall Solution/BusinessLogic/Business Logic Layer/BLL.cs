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
        // PRIVATE.
        private string apiToken;
        private string connectionString;
        // CONSTRUCTOR.
        public BLL(string ConnectionString, string APIToken)
        {
            apiToken            = APIToken;
            connectionString    = ConnectionString;
        }




        // UTILITIES
        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DateTime NormalizeApiDateTimeVersioTwo(string Datetime)
        {
            DateTime dtNormalized;

            DateTime.TryParse(Datetime,
                              null,
                              System.Globalization.DateTimeStyles.AdjustToUniversal,
                              out dtNormalized);


            return dtNormalized;
        }
        public DateTime? NormalizeApiDateTime(string Datetime)
        {
            if (string.IsNullOrEmpty(Datetime))
                return null;



            DateTime dtNormalized;     
            
            DateTime.TryParse(Datetime,
                              null,
                              System.Globalization.DateTimeStyles.AdjustToUniversal,
                              out dtNormalized);


            return dtNormalized;
        }    
        public List<Competition> TierOneCompetitions()
        {
            return new List<Competition>()
            {
                new Competition() {Id = 2002 },                 // Bundesliga.
                new Competition() {Id = 2003 },                 // Eredivisie.
                new Competition() {Id = 2014 },                 // LaLiga.
                new Competition() {Id = 2015 },                 // Ligue1.
                new Competition() {Id = 2016 },                 // Championship.
                new Competition() {Id = 2017 },                 // PrimeiraLiga.
                new Competition() {Id = 2019 },                 // SerieA_italia.
                new Competition() {Id = 2021 }                  // PremierLeague.
            };
        }



        // Entities Builders
        public void EntityBuilder(User User)
        {
            if (User != null)
            {
                User.CurrentUserHistory = GetCurrentUserHistoryByUserId(User.Id.ToString());
            }               
        }
        public void EntityBuilder(Match Match)
        {
            if (Match != null)
            {
                Match.Season            = GetSeasonById(Match.Season.Id.ToString());
                Match.Competition       = GetCompetitionById(Match.Competition.Id.ToString());
                Match.Competition.Area  = GetAreaById(Match.Competition.Area.Id.ToString());

                Match.HomeTeam          = GetTeamById(Match.HomeTeam.Id.ToString());
                Match.HomeTeam.Area     = GetAreaById(Match.HomeTeam.Area.Id.ToString());

                Match.AwayTeam          = GetTeamById(Match.AwayTeam.Id.ToString());
                Match.AwayTeam.Area     = GetAreaById(Match.AwayTeam.Area.Id.ToString());
            }
        }
        public void EntityBuilder(UserHistory UserHistory)
        {
            if (UserHistory != null)
            {
                UserHistory.Admin           = GetAdminById(UserHistory.Admin.Id.ToString());
                // UserHistory.User         = GetUserById(UserHistory.User.Id.ToString()); Previne recursão EntityBuilder User e Useristory.
                UserHistory.BeforeState     = GetUserStateById(UserHistory.BeforeState.Id.ToString());
                UserHistory.AfterState      = GetUserStateById(UserHistory.AfterState.Id.ToString());
            }
        }




        // API SYNC METHODS.
        public bool FullDatabaseSync()
        {
            SyncAreas();              // 1 API request.
            SyncSeasons();            // 1 API request.       
            SyncCompetitions();       // 1 API request.
            System.Threading.Thread.Sleep(60000);
            SyncTeams();              // 10 API requests.
            System.Threading.Thread.Sleep(60000);
            SyncMatchesTierOne();     // 10 API requests.

            return true;
        }
        public bool SyncAreas()
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
        public bool SyncSeasons()
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


            foreach (Competition apiCompetition in lstApiCompetitions)                                 // If database has alreday some records then...
            {
                if (apiCompetition.CurrentSeason != null)                                               
                {
                    Season dbCompetitionCurrentSeason = dalSeasons.GetById(apiCompetition.CurrentSeason.Id.ToString());

                    if (dbCompetitionCurrentSeason == null)
                    {
                        lstDbSeasons.Add(apiCompetition.CurrentSeason);
                    }
                    else if (apiCompetition.CurrentSeason.StartDate != dbCompetitionCurrentSeason.StartDate ||
                             apiCompetition.CurrentSeason.EndDate != dbCompetitionCurrentSeason.EndDate)               // Checks for any difference.
                    {
                        lstUpdateSeasosn.Add(apiCompetition.CurrentSeason);
                    }
                }
            }


            if (lstInsertSeasons.Count != 0)
                dalSeasons.Insert(lstInsertSeasons);
            if (lstUpdateSeasosn.Count != 0)
                dalSeasons.Update(lstUpdateSeasosn);


            return true;
        }
        public bool SyncCompetitions()
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
                Competition competitionDb = dalCompetitions.GetById(competitionApi.Id.ToString());

                if (competitionDb == null)
                {
                    lstInsertCompetition.Add(competitionApi);
                }
                else 
                {
                    DateTime? competitionApiLastUpdated = NormalizeApiDateTime(competitionApi.LastUpdated);

                    if (competitionApiLastUpdated.ToString() != competitionDb.LastUpdated)
                    {
                        lstUpdateCompetition.Add(competitionApi);
                    }
                }

            }

            if (lstInsertCompetition.Count != 0)
                dalCompetitions.Insert(lstInsertCompetition);
            if (lstUpdateCompetition.Count != 0)
                dalCompetitions.Update(lstUpdateCompetition);


            return true;
        }
        public bool SyncTeams()
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
                    Team dbTeam = dalTeams.GetById(apiTeam.Id.ToString());                          // Get Team by Id from db.


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

                    if (apiTeamLastUpdated.ToString() != dbTeam.LastUpdated)
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
        public bool SyncMatchesTierOne()
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
        public bool SyncMatchesByCompetition(string CompetitionId)
        {
            ResourceMatches resourceMatches = new ResourceMatches(apiToken);                                    // Object to comunicate with API football-data.org.

            List<Match> lstInsertMatches = new List<Match>();                                                   // Temporary list to hold insertable matches.
            List<Match> lstUpdateMatches = new List<Match>();                                                   // Temporary list to hold updatable  matches.

            List<Match> lstApiMatches = resourceMatches.GetByCompetition(CompetitionId);

            foreach (Match apiMatch in resourceMatches.GetByCompetition(CompetitionId))                         // Get a list of matches by competition from the Api.
            {
                if (apiMatch.HomeTeam.Id == 0 || apiMatch.AwayTeam.Id == 0)                                     // 0 == null. Do not insert or update.
                {
                    continue;
                }

                Match dbMatch = GetMatchById(apiMatch.Id.ToString());                                     // Tries to get the same match from db.

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
                InsertMatches(lstInsertMatches);
            if (lstUpdateMatches.Count != 0)
                UpdateMatches(lstUpdateMatches);

            return true;
        }
        
     


        // USER METHODS.
        public List<User> GetAllUsers()
        {
            DALUsers dal = new DALUsers(connectionString);

            List<User> lstUsers = dal.GetAll();
            lstUsers.ForEach(EntityBuilder);

            return lstUsers;
        }
        public User GetUserById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }


            DALUsers dal = new DALUsers(connectionString);
            User user = dal.GetById(Id);

            EntityBuilder(user);


            return user;
        }
        public bool InsertUser(User User)
        {
            // User Validations.
            if (User is null)
                return false;
            if(!IsValidEmail(User.Email))
                return false;


            // Insert User and get his Id.
            DALUsers dalUsers = new DALUsers(connectionString);
            int userId = dalUsers.Insert(User);                     

            
            // Creates and inserts default user_history for the current user.            
            UserHistory userHistory = new UserHistory()
            {
                Admin       = new Admin()           { Id= 1 },
                User        = new User()            { Id= userId },
                Description = "User registration.",
                BeforeState = new UserState()       { Id = 1 },
                AfterState  = new UserState()       { Id = 1 }
            };
            InsertUserHistory(userHistory);
            
            return true;
        }
        public bool UpdateUser(User User)
        {
            if (User is null)
                return false;

            if (!IsValidEmail(User.Email))
                return false;

            DALUsers dalUsers = new DALUsers(connectionString);
            
            return dalUsers.Update(User);
        }
        public bool UpdateUser(User User, UserHistory UserHistory)
        {
            if (User is null || UserHistory is null)
                return false;

            if (!IsValidEmail(User.Email))
                return false;


            List<User> lstUsers = new List<User>();

            if(UpdateUser(User) && InsertUserHistory(UserHistory))            
                return true;
            

            return false;
        }
        public User UserLogin(string Username, string Password)
        {
            DALUsers dalUsers = new DALUsers(connectionString);

            User user = dalUsers.Login(Username, Password);

            EntityBuilder(user);

            return user;
        }
        public bool RecoverUserPassword(string Email)
        {
            if (!IsValidEmail(Email))
            {
                return false;
            }

            DALUsers dalUsers   = new DALUsers(connectionString);
            User user           = dalUsers.GetByEmail(Email);

            if(user is null)
            {
                return false;
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("bmiguelmf@gmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "Wizball - Password Recover";
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
        public List<User> GetUsersByState(string UserStateId)
        {
            if (string.IsNullOrEmpty(UserStateId))
                return null;

            DALUsers dalUsers = new DALUsers(connectionString);

            return dalUsers.GetByState(UserStateId);
        }
        // USER_STATES METHODS.
        public UserState GetUserStateById(string Id)
        {
            DALUserStates dal = new DALUserStates(connectionString);
            return dal.GetById(Id);
        }
        public List<UserState> GetAllUserStates()
        {
            DALUserStates dalUserStatess = new DALUserStates(connectionString);

            return dalUserStatess.GetAll();
        }
        // USER_HISTORY METHODS.
        public UserHistory GetUserHistoryById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
                return null;

            DALUserHistory  dalUserHistory  = new DALUserHistory(connectionString);           // Gets an user history by its id.
            UserHistory     userHistory     = dalUserHistory.GetById(Id);

            EntityBuilder(userHistory);

            return userHistory;
        }
        public List<UserHistory> GetUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
                return null;
           
            DALUserHistory     dalUserHistory = new DALUserHistory(connectionString);           
            List<UserHistory>  lstUserHistory = dalUserHistory.GetByUserId(UserId);

            lstUserHistory.ForEach(EntityBuilder);

            return lstUserHistory;
        }
        public UserHistory GetCurrentUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
                return null;

            DALUserHistory  dalUserHistory  = new DALUserHistory(connectionString);
            UserHistory     userHistory     = dalUserHistory.GetCurrentByUserId(UserId);

            if (userHistory is null) return null;

            EntityBuilder(userHistory);
     
            return userHistory;
        }
        public bool InsertUserHistory(UserHistory UserHistory)
        {
            if (UserHistory is null)
                return false;


            DALUserHistory dalUserHistory = new DALUserHistory(connectionString);


            return dalUserHistory.Insert(UserHistory);
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
        public bool UpdateAdmin(Admin Admin)
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



        // MATCHES METHODS.
        public Match GetMatchById(string Id)
        {
            DALMatches dalMatches = new DALMatches(connectionString);
            
            Match match = dalMatches.GetById(Id);

            EntityBuilder(match);

            return match; 
        }      
        public List<Match> GetMatchesByCompetition(string CompetitionId)
        {
            DALMatches dalMatches = new DALMatches(connectionString);

            List<Match> lstMatches = dalMatches.GetByCompetitionId(CompetitionId);

            lstMatches.ForEach(EntityBuilder);

            return lstMatches;
        }
        public List<Match> GetNextMatchesByTierOneCompetitions()
        {
            List<Match> lstTodayMatches = new List<Match>();

            DALMatches dalMatches = new DALMatches(connectionString);

            foreach (Competition competition in TierOneCompetitions())
            {
                lstTodayMatches.AddRange(dalMatches.GetSpNextMatchesByCompetitionId(competition.Id.ToString()));
            }

            lstTodayMatches.ForEach(EntityBuilder);

            return lstTodayMatches;
        }
        public List<Match> GetMatchesHistoryByCompetition(string CompetitionId)
        {
            DALMatches dalMatches = new DALMatches(connectionString);

            List<Match> lstMatches = dalMatches.GetHistoryByCompetitionId(CompetitionId);

            lstMatches.ForEach(EntityBuilder);

            return lstMatches;
        }
        public List<Match> GetMatchesByDateAndCompetition(string CompetitionId, DateTime Date)
        {
            DateTime dayInit = new DateTime(Date.Year, Date.Month, Date.Day, 0,  0,  0);
            DateTime dayEnd  = new DateTime(Date.Year, Date.Month, Date.Day, 23, 59, 59);

            DALMatches dalMatches  = new DALMatches(connectionString);

            List<Match> lstMatches = dalMatches.GetByCompetitionIdAndByRangeDates(CompetitionId, dayInit, dayEnd);

            lstMatches.ForEach(EntityBuilder);

            return lstMatches;
        }
        public List<Match> GetMatchesByRangeDateAndCompetition(string CompetitionId, DateTime StartDate, DateTime EndDate)
        {
            DateTime dayInit = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, 0, 0, 0);
            DateTime dayEnd = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, 23, 59, 59);

            DALMatches dalMatches = new DALMatches(connectionString);

            List<Match> lstMatches = dalMatches.GetByCompetitionIdAndByRangeDates(CompetitionId, dayInit, dayEnd);

            lstMatches.ForEach(EntityBuilder);

            return lstMatches;
        }
        public bool InsertMatches(List<Match> Matches)
        {
            if (Matches is null)
                return false;

            DALMatches dalMatches = new DALMatches(connectionString);
            dalMatches.Insert(Matches);


            return true;
        }
        public bool UpdateMatches(List<Match> Matches)
        {
            if (Matches is null)
                return false;

            DALMatches dalMatches = new DALMatches(connectionString);
            dalMatches.Update(Matches);


            return true;
        }


        // AREAS METHODS.
        public List<Area> GetAllAreas()
        {
            DALAreas dal = new DALAreas(connectionString);
            return dal.GetAll();
        }
        public Area GetAreaById(string Id)
        {
            DALAreas dalAreas = new DALAreas(connectionString);
            return dalAreas.GetById(Id);
        }


        // SEASONS METHODS.
        public List<Season> GetAllSeasons()
        {
            DALSeasons dal = new DALSeasons(connectionString);
            return dal.GetAll();
        }
        public Season GetSeasonById(string Id)
        {
            DALSeasons dalSeasons = new DALSeasons(connectionString);
            return dalSeasons.GetById(Id);
        }



        // COMPETITIONS METHODS.
        public List<Competition> GetAllCompetitions()
        {
            DALCompetitions dal = new DALCompetitions(connectionString);
            return dal.GetAll();
        }
        public Competition GetCompetitionById(string Id)
        {
            DALCompetitions dalCompetitions = new DALCompetitions(connectionString);
            return dalCompetitions.GetById(Id);
        }


        // TEAMS METHODS.
        public List<Team> GetAllTeams()
        {
            DALTeams dal = new DALTeams(connectionString);
            return dal.GetAll();
        }
        public Team GetTeamById(string Id)
        {
            DALTeams dalTeams = new DALTeams(connectionString);
            return dalTeams.GetById(Id);
        }


        // TIPS METHODS
        public Tip GetTipById(string Id)
        {
            DALTips dalTips = new DALTips(connectionString);
            return dalTips.GetById(Id);
        }
        public Tip GetTipByMatchId(string Id)
        {
            DALTips dalTips = new DALTips(connectionString);
            return dalTips.GetByMatch(Id);
        }
        public List<Tip> GetTipsByResultNotSet()
        {
            DALTips dalTips = new DALTips(connectionString);
            return dalTips.GetWhereResultNotSet();
        }
        public bool InsertTip(Tip Tip)
        {
            if (Tip is null)
                return false;


            List<Tip> lstTips = new List<Tip>()
            {
                Tip
            };


            DALTips dalTips = new DALTips(connectionString);
            dalTips.Insert(lstTips);


            return true;
        }
        public bool InsertTips(List<Tip> Tips)
        {
            if (Tips is null)
                return false;

            DALTips dalTips = new DALTips(connectionString);
            dalTips.Insert(Tips);


            return true;
        }
        public bool UpdateTip(Tip Tip)
        {
            if (Tip is null)
                return false;

            DALTips dalTips = new DALTips(connectionString);

            return dalTips.Update(Tip);
        }
        public bool UpdateTips(List<Tip> Tips)
        {
            if (Tips is null)
                return false;

            DALTips dalTips = new DALTips(connectionString);
            dalTips.Update(Tips);

            return true;
        }

        public void GenerateTipsFTOverTwoAndHalfGoalsByDate()
        {
            DateTime dt = new DateTime(2018, 10, 2);
            List<Match> lstMatches = GetMatchesByDateAndCompetition("2016", dt);                 // Gets a List<Match> with only elegible matches for setting up tips. (Just right the next match by team)

            foreach (Match match in lstMatches)
            {
                Tip matchTip = GetTipByMatchId(match.Id.ToString());                        // First we try to get from the database the tip corresponding to the current match.

                if (matchTip is null)                                                        // Only if this match does not already has a tip in the database then we will generate one.
                {
                    SetTipFTOverTwoAndHalfGoals(match);                                     // Method call which will generate the tip.
                }
            }
        }
        public void GenerateTipsFTOverTwoAndHalfGoals()                                             
        {
            // The method responsibility is to decide which matches are eligible for the Full Time Over Two And Half Goals generation tip.

            List<Match> lstMatches = GetNextMatchesByTierOneCompetitions();                 // Gets a List<Match> with only elegible matches for setting up tips. (Just right the next match by team)

            foreach (Match match in lstMatches)                      
            {
                Tip matchTip = GetTipByMatchId(match.Id.ToString());                        // First we try to get from the database the tip corresponding to the current match.

                if(matchTip is null)                                                        // Only if this match does not already has a tip in the database then we will generate one.
                {
                    SetTipFTOverTwoAndHalfGoals(match);                                     // Method call which will generate the tip.
                }
            }
        }
        private void SetTipFTOverTwoAndHalfGoals(Match Match)
        {
            // The method responsibility is to generate a tip for a given match.
            

            int homeTeam = Match.HomeTeam.Id;           // Easy to handle pointer to homeTeam id.
            int awayTeam = Match.AwayTeam.Id;           // Easy to handle pointer to awayTeam id.


            List<Match> lstCompetitonMatches    = GetMatchesByCompetition(Match.Competition.Id.ToString());                 // Gets all matches for the competition which the current match belongs to.
            List<Match> playedMatches           = lstCompetitonMatches.Where(x => x.Score.Winner != "").ToList();           // Then filters it just to get the played matches.


            double? homeTeamAvgResult           = playedMatches.Where(x => x.HomeTeam.Id == homeTeam)                       // Gets the avg fult time result for the matches where the Home Team = to homeTeam.
                                                  .Average(x => x.Score.FullTime.HomeTeam + x.Score.FullTime.AwayTeam);
            double? awayTeamAvgResult           = playedMatches.Where(x => x.AwayTeam.Id == awayTeam)                       // Gets the avg fult time result for the matches where the Away Team = to awayTeam.
                                                  .Average(x => x.Score.FullTime.HomeTeam + x.Score.FullTime.AwayTeam);
            double? totalAvg                    = (homeTeamAvgResult + awayTeamAvgResult) / 2;



            Tip tip = new Tip();

            if (totalAvg > 3)       // Sure bet.
            {
                tip.Match       = new Match    { Id = Match.Id };
                tip.Market      = new Market    { Id = 1 };
                tip.BetNoBet    = true;
                tip.Forecast    = true;
            }
            else if(totalAvg < 2)   // Sure no bet.
            {
                tip.Match       = new Match     { Id = Match.Id };
                tip.Market      = new Market    { Id = 1 };
                tip.BetNoBet    = true;
                tip.Forecast    = false;
            }
            else                    // Unpredictable bet. 
            {
                tip.Match       = new Match     { Id = Match.Id };
                tip.Market      = new Market    { Id = 1 };
                tip.BetNoBet    = false;
                tip.Forecast    = false;
            }

            InsertTip(tip);
        }

        public void SetResultsFTOverTwoAndHalfGoals()
        {
            // The method responsibility is to update previous generated tips with real matches result after them being played.

            List<Tip> lstTips = GetTipsByResultNotSet();                                                     // List of tips waiting for the match to happen. (Result = null)             

            foreach (Tip tip in lstTips)
            {
                Match match = GetMatchById(tip.Match.Id.ToString());                                        // Then we will check if the corresponding match for each tip has already been played.

                if (match.Score.Winner == string.Empty)                                                     // Because the application generate tips some days before the corresponding match happens.
                {                                                                                           // we must check if the match has already been played. Otherwise continue to next tip.
                    continue;               
                }

                double? totalGoals = match.Score.FullTime.HomeTeam + match.Score.FullTime.AwayTeam;         // Total goals is equal to the som of home team score plus away team score

                if(totalGoals > 2.5)                                                                        // Checks whether the match had over two and half goals or not.
                {
                    tip.Result = true;                                                                      // Sets the tip result value.
                }
                else
                {
                    tip.Result = false;                                                                     // Sets the tip result value.      
                }
            }

            UpdateTips(lstTips);                                                                            // Finally updates all the tips with the result now set.
        }

    }
}

