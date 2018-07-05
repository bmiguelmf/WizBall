using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ApiFootballDataOrg;
using ApiFootballDataOrg.Entities;
using ApiFootballDataOrg.Resources;

using BusinessLogic;




namespace BackOffice.pages
{
    public partial class _default : System.Web.UI.Page
    {

        private const string TOKEN = "7f91f916023b4430b44d97cc11e5c030";

        // Bruno Home.
        //private const string ConnString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";

        // Bruno ATEC
        private const string ConnString = "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = wizball; Integrated Security = SSPI;";


        protected void Page_Load(object sender, EventArgs e)
        {
            // GetAllCompetitions();                                // List all available competitions.

            // GetCompetitionsByArea(2187);                         // List competitions by area (Portugal).

            // GetCompetitionById(2017);                            // List a particular competition by its Id (Primeira Liga).




            // GetTeamsById(18);

            // GetTeamsByCompetition(2001);                         // List teams by competition(Liga Campeões 17/18).

            // GetTeamsByCompetitionAndStage(2001, "SEMI_FINALS");



            // GetMatchesByCompetition(2000);

            // GetMatchById(200033);

            // GetByCompetitionAndStatus(2000, "SCHEDULED");


            ResourceCompetitions rc = new ResourceCompetitions(TOKEN);
            List<Season> lstSeasons = new List<Season>();

            foreach (Competition comp in rc.GetAll())
            {
                lstSeasons.Add(comp.CurrentSeason);
            }

            DALSeasons dalSeason = new DALSeasons(ConnString);
            dalSeason.Insert(lstSeasons);

            //ResourceAreas resourceAreas = new ResourceAreas(TOKEN);
            //List<Area> lstAreas = resourceAreas.GetAll();

            //DALAreas dalAreas = new DALAreas(ConnString);
            //dalAreas.Insert(lstAreas);

            //DALAreas fds = new DALAreas(ConnString);

            //foreach(Area a in fds.GetAll())
            //{
            //    Page.Response.Write(a.Id + " &emsp; " + a.Name + " <br/>");
            //}
        }



        // List one particular competition by its Id.
        private void GetCompetitionById(int Id)
        {
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);

            Competition comp = resourceCompetitions.GetById(Id.ToString());

            Page.Response.Write(comp.Id + " &emsp; " + comp.Plan + " &emsp; " + comp.Name + " <br/>");
        }

        // List all available competitions.
        private void GetAllCompetitions()
        {
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);

            foreach (Competition comp in resourceCompetitions.GetAll())
            {
                Page.Response.Write(comp.Id + " &emsp; " + comp.Plan + " &emsp; " + comp.Name + " <br/>");
            }
        }

        // List competitions by area.
        private void GetCompetitionsByArea(int Id)
        {
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);

            foreach (Competition comp in resourceCompetitions.GetByArea(Id.ToString()))
            {
                Page.Response.Write(comp.Id + " &emsp; " + comp.Plan + " &emsp; " + comp.Name + " <br/>");
            }
        }



        // List teams by competition.
        private void GetTeamsById(int Id)
        {
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            Team team = resourceTeams.GetById(Id.ToString());

            Page.Response.Write(team.Id + " &emsp; " + team.Name + " <br/>");

        }

        // List teams by competition.
        private void GetTeamsByCompetition(int Id)
        {
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            foreach (Team team in resourceTeams.GetByCompetition(Id.ToString()))
            {
                Page.Response.Write(team.Id + " &emsp; " + team.Name + " <br/>");
            }
        }

        // List teams by competition.
        private void GetTeamsByCompetitionAndStage(int Id, string Stage)
        {
            ResourceTeams resourceTeams = new ResourceTeams(TOKEN);

            foreach (Team team in resourceTeams.GetByCompetitionAndStage(Id.ToString(), Stage))
            {
                Page.Response.Write(team.Id + " &emsp; " + team.Name + " <br/>");
            }
        }



        // List all matches for a particular competition.
        private void GetMatchesByCompetition(int Id)
        {
            ResourceMatches resourceMatches = new ResourceMatches(TOKEN);


            foreach (Match match in resourceMatches.GetByCompetition(Id.ToString()))
            {
                Page.Response.Write(match.Id + " &emsp; " + " <br/>");
            }


        }

        // List one particular match by its Id.
        private void GetMatchById(int Id)
        {
            ResourceMatches resourceMatches = new ResourceMatches("7f91f916023b4430b44d97cc11e5c030");

            Match match = resourceMatches.GetById(Id.ToString());

            Page.Response.Write(match.Id + " &emsp; " + " <br/>");
        }

        // List all matches for a particular competition filtered by its status.
        private void GetByCompetitionAndStatus(int Id, string Status)
        {
            ResourceMatches resourceMatches = new ResourceMatches(TOKEN);



            foreach (Match match in resourceMatches.GetByCompetitionAndStatus(Id.ToString(), Status))
            {
                Page.Response.Write(match.Id + " &emsp; " + match.Status + " &emsp; " + match.HomeTeam.Name + " vs &emsp; " + match.AwayTeam.Name + " <br/>");
            }
        }




        // List all available areas.
        public void GetAllAreas()
        {
            ResourceAreas resourceAreas = new ResourceAreas(TOKEN);

            foreach (Area area in resourceAreas.GetAll())
            {
                Page.Response.Write(area.Id + " &emsp; " + area.Name + " &emsp; " + area.ParentArea + " <br/>");
            }

        }
    }
}