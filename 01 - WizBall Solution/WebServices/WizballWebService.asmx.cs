﻿using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Services;

namespace WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WizballWebService : System.Web.Services.WebService
    {
        private string connString = WebConfigurationManager.ConnectionStrings["ConnStringBroHome"].ConnectionString;
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
        public bool UpdatetUser(User User)
        {
            if (User is null)
                return false;

            BLL bll = new BLL(connString, apiToken);

            return bll.UpdatetUser(User);
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
        public List<UserState> GetUserStates()
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.GetAllUserStates();
        }
        [WebMethod]
        public List<User> GetUsersByState(string UserStateId)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.GetUsersByState(UserStateId);
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
            return bll.UpdatetAdmin(Admin);
        }
        [WebMethod]
        public Admin AdminLogin(string Username, string Password)
        {
            BLL bll = new BLL(connString, apiToken);

            return bll.AdminLogin(Username, Password);
        }
    }
}
