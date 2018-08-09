using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.BLL;
using BusinessLogic.Entities;
using System.Configuration;
using WebServices;


namespace ConsoleAppTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";
            string apiToken = "7f91f916023b4430b44d97cc11e5c030";

            BLL bll = new BLL(connString, apiToken);



            // Code Here.
            foreach (Match match in bll.GetTodayMatchesByCompetition("2016"))
            {
                Console.WriteLine("Match -> " + match.Id);
                Console.Write(match.Competition.Name + " - " + match.Competition.Area.Name);
                Console.WriteLine("   " + match.UtcDate + "  Matchday: " + match.Matchday);
                Console.WriteLine(match.HomeTeam.Name + "  VS  " + "   " + match.AwayTeam.Name);
                Console.WriteLine(match.Score.HalfTime.HomeTeam.Value + "  half-time " + match.Score.HalfTime.AwayTeam.Value);
                Console.WriteLine(match.Score.FullTime.HomeTeam.Value + "  fult-time " + match.Score.FullTime.AwayTeam.Value);
                Console.WriteLine();
                Console.WriteLine();

            }




            //bll.FullDatabaseSync();


            //List<UserHistory> history = bll.GetUserHistoryByUserId("1");


            //foreach(UserHistory uh in history)
            //{
            //    Console.WriteLine(uh.User.Username + " " + uh.User.Email + " " + uh.User.Password + " " + uh.Admin.Username + " " + uh.AfterState.Description );
            //}

            

            //User user = new User() { Username = "bro", Email = "bmiguelmf@gmail.com", Password = "06121984" };
            //bll.InsertUser(user);





            Console.WriteLine("Ok!");
            Console.ReadLine();
        }
    }
}
