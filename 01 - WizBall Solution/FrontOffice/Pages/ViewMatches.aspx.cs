using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using WebServices;
using FrontOffice.Resources;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace FrontOffice.Pages
{
    public partial class Default : System.Web.UI.Page
    {
                 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;


            
            string apiToken = WebConfigurationManager.AppSettings["ApiToken"];                              // Database sync purposes. //
            string connString = WebConfigurationManager.ConnectionStrings["home"].ConnectionString;         // // // // // // // // // //
            BLL  bll = new BLL(connString, apiToken);                                                       // // // // // // // // // //
            //bll.FullDatabaseSync();                                                                       // // // // // // // // // //
            // bll.SyncAreas();                                                                             // // // // // // // // // //
            //bll.SyncSeasons();                                                                            // // // // // // // // // //
            //bll.SyncCompetitions();                                                                       // // // // // // // // // //
            //bll.SyncTeams();                                                                              // // // // // // // // // //
            //bll.SyncMatchesTierOne();                                                                     // // // // // // // // // //



            //User bro = new User()
            //{
            //    Username = "Bro",
            //    Email = "bmiguelmf@gmail.com",
            //    Password = "06121984"
            //};

            //bll.InsertUser(bro);

            //Page.Response.Write("User Inserirdo: Showing User");
            //Thread.Sleep(3000);

            //foreach (User user in bll.GetAllUsers())
            //{
            //    Page.Response.Write("");
            //    Page.Response.Write(user.Username + " " + user.Email + " " + user.Password + " " + user.Picture + " " + user.Newsletter.ToString() + " " + user.CreatedAt + " " + user.Id.ToString());
            //}




            //User bro = bll.GetUserById("121");

            //bro.Picture = "fds.png";
            //bro.Email = "outro@mail.com";
            //bro.Newsletter = true;
            //bro.CurrentUserHistory.AfterState.Id = 11;
            //bro.CurrentUserHistory.Description = "bloqued por bro";


            //bll.UpdatetUser(bro, bro.CurrentUserHistory);



            phGridNextMatchesControl.Controls.Add(GridNextMatchesControl.Create());
        }

    }
}