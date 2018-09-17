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
            //string connString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = wizball; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            string connString = "Data Source = DESKTOP-OBFHSOT\\MSSQLSERVERATEC; Initial Catalog = wizball; Integrated Security = SSPI;";
            string apiToken   = "7f91f916023b4430b44d97cc11e5c030";

            BLL bll = new BLL(connString, apiToken);

            bll.FullDatabaseSync();
            bll.FullDatabaseSync();

            //bll.SetTodayTips();






            //UserHistory userHistory = bll.GetCurrentUserHistoryByUserId("1");

            //Console.WriteLine("Admin        : " + userHistory.Admin.Username);
            //Console.WriteLine("User         : " + userHistory.User.Username);
            //Console.WriteLine("Date         : " + userHistory.CreatedAt);
            //Console.WriteLine("Description  : " + userHistory.Description);
            //Console.WriteLine("Before State : " + userHistory.BeforeState.Description);
            //Console.WriteLine("After State  : " + userHistory.AfterState.Description);

            //User bro = new User();
            //bro.Email = "1z91@fdadertfgs.pt";
            //bro.Password = "19z1";
            //bro.Username = "19z1";
            //bool id = bll.InsertUser(bro);

            ////Console.WriteLine(bll.GetLastInsertedUserId());

            //foreach (User user in bll.GetAllUsers())
            //{
            //    if (user.CurrentUserHistory is null) continue;

            //    Console.WriteLine(  user.CurrentUserHistory.Id + " " +
            //                        user.CurrentUserHistory.Description + " " +
            //                        user.CurrentUserHistory.Admin.Username + " " +
            //                        user.CurrentUserHistory.BeforeState.Description + " " +
            //                        user.CurrentUserHistory.AfterState.Description + " " +
            //                        user.CurrentUserHistory.CreatedAt);
            //}

            //UserHistory uh = new UserHistory();
            //uh.User = bll.GetUserById("1");
            //uh.BeforeState = bll.GetUserStateById("21");
            //uh.AfterState = bll.GetUserStateById("11");
            //uh.Admin = bll.GetAdminById("1");
            //uh.Description = "Ban by fdgp";
            //bll.InsertUserHistory(uh);


            //Tip tip = new Tip()
            //{
            //    Market = new Market() { Id = 1 },
            //    Match = bll.GetMatchById("233023"),
            //    BetNoBet = true,
            //    Forecast = true
            //};

            //tip = bll.GetTipById("1");

            //tip.Result = true;

            //bll.UpdateTip(tip);


            //// Code Here.
            //foreach (Match match in bll.GetTodayMatchesByTierOneCompetitions())
            //{
            //    bll.MatchBuilder(match);
            //    Console.WriteLine("Match -> " + match.Id);
            //    Console.WriteLine(match.Competition.Name);
            //    Console.WriteLine(match.UtcDate + "  Matchday: " + match.Matchday + " Winner: " + match.Score.Winner);
            //    Console.WriteLine(match.HomeTeam.ShortName + "   " + match.Score.HalfTime.HomeTeam + " half-time " + match.Score.HalfTime.AwayTeam + "   " + match.AwayTeam.ShortName);
            //    Console.WriteLine(match.HomeTeam.ShortName + "   " + match.Score.FullTime.HomeTeam + " full-time " + match.Score.FullTime.AwayTeam + "   " + match.AwayTeam.ShortName);
            //    Console.WriteLine();
            //    Console.WriteLine();
            // }




            //bll.FullDatabaseSync();


            //List<UserHistory> history = bll.GetUserHistoryByUserId("1");


            //foreach(UserHistory uh in history)
            //{
            //    Console.WriteLine(uh.User.Username + " " + uh.User.Email + " " + uh.User.Password + " " + uh.Admin.Username + " " + uh.AfterState.Description );
            //}



            //User user = new User() { Username = "bro", Email = "bmiguelmf@gmail.com", Password = "06121984" };
            //bll.InsertUser(user);





            Console.WriteLine("Done.....");
            Console.ReadLine();
        }
    }
}
