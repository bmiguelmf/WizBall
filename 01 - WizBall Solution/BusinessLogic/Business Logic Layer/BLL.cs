using System;
using System.Linq;

using BusinessLogic.Entities;
using BusinessLogic.DAL;
using BusinessLogic.Resources;
using System.Collections.Generic;

namespace BusinessLogic.BLL
{
    public class BLL
    {
        private const string TOKEN = "7f91f916023b4430b44d97cc11e5c030";


        // Bruno Home.
        private const string ConnString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";
        // Bruno ATEC
        //private const string ConnString = "Data Source = DESKTOP-O32Q2UQ\\SQLEXPRESS; Initial Catalog = wizball; Integrated Security = SSPI;";


        public bool InitializeDatabase()
        {
            // Areas
            ResourceAreas resourceAreas = new ResourceAreas(TOKEN);
            DALAreas dalAreas = new DALAreas(ConnString);
            dalAreas.Insert(resourceAreas.GetAll());


            // Competitions
            ResourceCompetitions resourceCompetitions = new ResourceCompetitions(TOKEN);
            DALCompetitions dalCompetitions = new DALCompetitions(ConnString);
            dalCompetitions.Insert(resourceCompetitions.GetAll());


            // Seasons           
            List<Season> lstSeasons = new List<Season>();         
            foreach(Competition comp in resourceCompetitions.GetAll())
            {
                if(comp.CurrentSeason.StartDate != "0" && comp.CurrentSeason.EndDate != "0")
                    lstSeasons.Add(comp.CurrentSeason);
            }
            DALSeasons dalSeason = new DALSeasons(ConnString);
            dalSeason.Insert(lstSeasons);




            return true;
        }
    }
}
