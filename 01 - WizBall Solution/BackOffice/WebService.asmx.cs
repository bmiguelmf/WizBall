using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Services;

namespace BackOffice
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {
        private string connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;
        private string apiToken = WebConfigurationManager.AppSettings["ApiToken"];


        // USER METHODS.
        [WebMethod]
        public List<User> GetAllUsers()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetAllUsers();
        }
        [WebMethod]
        public User GetUserById(string Id)
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetUserById(Id);
        }
        [WebMethod]
        public bool InsertUser(User User)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.InsertUser(User);
        }
        [WebMethod]
        public bool UpdateUser(User User)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.UpdateUser(User);
        }
        [WebMethod]
        public bool UpdateUserAndUserHistory(User User, UserHistory UserHistory)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.UpdateUser(User, UserHistory);
        }
        [WebMethod]
        public User UserLogin(string Username, string Password)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.UserLogin(Username, Password);
        }
        [WebMethod]
        public bool RecoverUserPassword(string Email)
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.RecoverUserPassword(Email);
        }
        [WebMethod]
        public bool UserMailExists(string Email)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.UserMailExists(Email);
        }
        [WebMethod]
        public bool UsernameExists(string Username)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.UsernameExists(Username);
        }
        [WebMethod]
        public List<User> GetUsersByState(string UserStateId)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.GetUsersByState(UserStateId);
        }

        // USER_STATE METHODS.
        [WebMethod]
        public List<UserState> GetAllUserStates()
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.GetAllUserStates();
        }
        [WebMethod]
        public UserState GetUserStateById(string Id)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.GetUserStateById(Id);
        }

        // USER_HISTORY MOTHODS.
        [WebMethod]
        public UserHistory GetUserHistoryById(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                return null;
            }

            BLL bll = new BLL(connString, apiToken);

            return bll.GetUserHistoryById(Id);
        }
        [WebMethod]
        public List<UserHistory> GetUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }

            BLL bll = new BLL(connString, apiToken);

            return bll.GetUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public UserHistory GetCurrentUserHistoryByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
            {
                return null;
            }


            BLL bll = new BLL(connString, apiToken);

            return bll.GetCurrentUserHistoryByUserId(UserId);
        }
        [WebMethod]
        public bool InsertUserHistory(UserHistory UserHistory)
        {
            if (UserHistory is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.InsertUserHistory(UserHistory);
        }



        // ADMIN METHODS.
        [WebMethod]
        public List<Admin> GetAllAdmins()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetAllAdmins();
        }
        [WebMethod]
        public Admin GetAdminById(string Id)
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetAdminById(Id);
        }
        [WebMethod]
        public bool InsertAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            BLL bll = new BLL(connString, apiToken);
            bll.InsertAdmin(Admin);

            return true;
        }
        [WebMethod]
        public bool UpdatetAdmin(Admin Admin)
        {
            if (Admin is null)
                return false;

            BLL bll = new BLL(connString, apiToken);
            return bll.UpdateAdmin(Admin);
        }
        [WebMethod(EnableSession = true)]
        public Admin AdminLogin(string Username, string Password)
        {
            BLL bll = new BLL(connString, apiToken);
            Admin ad = bll.AdminLogin(Username, Password);
            if (ad != null)
            {
                Session["Admin"] = ad;
                return ad;
            }
            else
            {
                Session["Admin"] = null;
                return null;
            }
        }



        // SYNC METHODS
        [WebMethod]
        public bool FullDatabaseSync()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.FullDatabaseSync();
        }
        [WebMethod]
        public bool SyncMatchesTierOne()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.SyncMatchesTierOne();
        }
        [WebMethod]
        public bool SyncTeams()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.SyncTeams();
        }



        // TEAMS METHODS
        [WebMethod]
        public List<Team> GetAllTeams()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetAllTeams();
        }



        // AREAS METHODS
        [WebMethod]
        public List<Area> GetAllAreas()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetAllAreas();
        }




        // MATCHES METHODS
        [WebMethod]
        public List<Match> GetNextMatchesByTierOneCompetitions()
        {
            BLL bll = new BLL(connString, apiToken);
            return bll.GetNextMatchesByTierOneCompetitions();
        }
        [WebMethod]
        public bool MatchesHasRows()
        {
            BLL bll = new BLL(connString, apiToken);
            var tou = bll.MatchesHasRows();
            return tou;
        }
    }
}
