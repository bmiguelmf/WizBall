using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



using BusinessLogic.BLL;
using BusinessLogic.Entities;




namespace BackOffice.pages
{
    public partial class _default : System.Web.UI.Page
    {

       


        protected void Page_Load(object sender, EventArgs e)
        {

            BLL bll = new BLL();

            bll.InitializeDatabase();




            //foreach(Area area in bll.GetAllAreas())
            //{
            //    Page.Response.Write(area.Name + " &emsp; " + area.ParentAreaId.ToString() + " <br/>");
            //}


            //foreach (Season season in bll.GetAllSeasons())
            //{
            //    Page.Response.Write(season.Id + " &emsp; " + season.StartDate + " <br/>");
            //}

            //foreach(Competition comp in bll.GetAllCompetitions())
            //{
            //    Page.Response.Write(comp.Id + " &emsp; " + comp.Name + " <br/>");
            //}
        }




    }
}