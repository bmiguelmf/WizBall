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




            User bro = new User() { Email = "1bmiguelmf&gmail.com", Password = "06121984", Username = "bro" };
            bro.Picture = "bro.pic";
            bro.Newsletter = true;
            bro.Username = "brox";
            bll.InsertUser(bro);
            Console.WriteLine("BRo inserido");

            Console.ReadLine();
        }
    }
}
