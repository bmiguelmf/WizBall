using System;
using System.Linq;
using System.Net.Mail;
using BusinessLogic.Entities;
using BusinessLogic.DAL;
using BusinessLogic.Resources;
using System.Collections.Generic;
using Newtonsoft;
using Newtonsoft.Json;


namespace BusinessLogic.BLL
{
    public class BLL
    {
        // TEMPORARY ******************************************************************************************

        private const string TOKEN = "7f91f916023b4430b44d97cc11e5c030";

       
        private const string ConnString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";   // Bruno Home.

        // private const string ConnString = "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = wizball; Integrated Security = SSPI;";     // Bruno ATEC.



        // API SYNC METHODS.
        public bool FullDatabaseSync()
        {
            SyncAreas();              // 1 API request.
            SyncSeasons();            // 1 API request.       
            SyncCompetitions();       // 1 API request.
            System.Threading.Thread.Sleep(60000);
            SyncTeams();              // 10 API requests.
            System.Threading.Thread.Sleep(60000);
            SyncMatchesTireOne();     // 10 API requests.

            return true;
        }
        private bool SyncAreas()
        {
            ResourceAreas resourceAreas = new ResourceAreas(TOKEN);         // Object to comunicate with API football-data.org.
            DALAreas dalAreas = new DALAreas(ConnString);                   // Object to comunicate with Database.

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
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);            // Object to comunicate with API football-data.org.
            DALSeasons dalSeasons = new DALSeasons(ConnString);                                     // Object to comunicate with Database.

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
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);            // Object to comunicate with API football-data.org.
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);                      // Object to comunicate with Database.

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
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);                                 // Object to comunicate with API football-data.org.           
            DALTeams dalTeams = new DALTeams(ConnString);                                           // Object to comunicate with Database.

            List<Team> lstInsertTeams = new List<Team>();                                           // Temporary List<Competition> to insert.
            List<Team> lstUpdateTeams = new List<Team>();                                           // Temporary List<Competition> to update.



            foreach (Competition competition in TireOneCompetitions())                               // Foreach tier_one competition.
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


                    DateTime dateTime = new DateTime();                                              // Normalize date to comparison.
                    DateTime.TryParse(apiTeam.LastUpdated,
                                      null,
                                      System.Globalization.DateTimeStyles.AdjustToUniversal,
                                      out dateTime);

                    if (dbTeam.LastUpdated == null || dateTime.ToString() != dbTeam.LastUpdated)
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
        private bool SyncMatchesTireOne()
        {
            DALMatches dalMatches = new DALMatches(ConnString);
            ResourceMatches resourceMatches = new ResourceMatches(TOKEN);

            foreach (Competition competition in TireOneCompetitions())
            {
                List<Match> lstInsertMatches = new List<Match>();
                List<Match> lstApiMatches = resourceMatches.GetByCompetition(competition.Id.ToString());

                foreach (Match match in lstApiMatches)
                {
                    if (match.HomeTeam.Id == 0 || match.AwayTeam.Id == 0)
                    {
                        continue;
                    }

                    if (dalMatches.GetById(match.Id.ToString()) is null)
                    {
                        lstInsertMatches.Add(match);
                    }
                }

                dalMatches.Insert(lstInsertMatches);
            }

            return true;
        }
        private List<Competition> TireOneCompetitions()
        {
            return new List<Competition>()                         
            {
                new Competition() {Id = 2002 },                 // Bundesliga.
                new Competition() {Id = 2003 },                 // Eredivisie.
                new Competition() {Id = 2014 },                 // PrimeraDivision.
                new Competition() {Id = 2015 },                 // Ligue1.
                new Competition() {Id = 2016 },                 // Championship.
                new Competition() {Id = 2017 },                 // PrimeiraLiga.
                new Competition() {Id = 2018 },                 // EuropeanChampionship.
                new Competition() {Id = 2019 },                 // SerieA_italia.
                new Competition() {Id = 2021 }                  // PremierLeague.
            };
        }



        // API METHODS.
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
        public List<Match> GetMatchesByCompetition(string CompetitionId)
        {
            DALTeams dalTeams = new DALTeams(ConnString);
            DALMatches dalMatches = new DALMatches(ConnString);

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
            DALUsers dal = new DALUsers(ConnString);
            return dal.GetAll();
        }
        public User GetUserById(string Id)
        {
            DALUsers dal = new DALUsers(ConnString);
            return dal.GetById(Id);
        }
        public bool InsertUser(User User)
        {
            if (User is null)
                return false;

            List<User> lstUsers = new List<User>();
            lstUsers.Add(User);

            DALUsers dalUsers = new DALUsers(ConnString);
            dalUsers.Insert(lstUsers);

            return true;
        }
        public bool UpdatetUser(User User)
        {
            if (User is null)
                return false;

            List<User> lstUsers = new List<User>();
            lstUsers.Add(User);

            DALUsers dalUsers = new DALUsers(ConnString);
            dalUsers.Update(lstUsers);

            return true;
        }
        public User UserLogin(string Username, string Password)
        {
            DALUsers dalUsers = new DALUsers(ConnString);

            return dalUsers.Login(Username, Password);
        }
        public bool RecoverUserPassword(string Email)
        {
            DALUsers dalUsers = new DALUsers(ConnString);

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



        // ADMIN METHODS.
        public List<Admin> GetAllAdmins()
        {
            DALAdmins dalAdmins = new DALAdmins(ConnString);
            return dalAdmins.GetAll();
        }
        public Admin GetAdminById(string Id)
        {
            DALAdmins dalAdmins = new DALAdmins(ConnString);
            return dalAdmins.GetById(Id);
        }
        public bool InsertAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            List<Admin> lstAdmins = new List<Admin>();
            lstAdmins.Add(Admin);

            DALAdmins dalAdmins = new DALAdmins(ConnString);
            dalAdmins.Insert(lstAdmins);

            return true;
        }
        public bool UpdatetAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            List<Admin> lstAdmins = new List<Admin>();
            lstAdmins.Add(Admin);

            DALAdmins dalAdmins = new DALAdmins(ConnString);
            dalAdmins.Update(lstAdmins);

            return true;
        }
        public Admin AdminLogin(string Username, string Password)
        {
            DALAdmins dalAdmins = new DALAdmins(ConnString);

            return dalAdmins.Login(Username, Password);
        }
    }
}

