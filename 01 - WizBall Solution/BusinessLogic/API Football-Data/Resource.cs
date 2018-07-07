using System.Net;
using System.Text;
using System.Collections.Generic;

namespace BusinessLogic.Resources
{
    public abstract class Resource
    {
        protected const string URL_AREAS = "http://api.football-data.org/v2/areas/";
        protected const string URL_MATCHES = "http://api.football-data.org/v2/matches/";
        protected const string URL_TEAMS = "http://api.football-data.org/v2/teams/"; 
        protected const string URL_COMPETITIONS = "http://api.football-data.org/v2/competitions/";


        // Properties.
        protected WebClient WebClient { get; set; }


        // Constructor.
        public Resource(string Token)
        {
            WebClient = new WebClient();
            WebClient.Headers.Add("X-Auth-Token", Token);               // Setup WebClient token property.
            WebClient.Encoding = Encoding.UTF8;                         // setup WebClient encoding property.
        }


        // DownloadString methods.
        protected virtual string DownloadString(string EndPoint)
        {
            string response = WebClient.DownloadString(EndPoint);
            response = response.Replace("null", "0");

            return response;                      // Replace nulls by 0.
        }



        // GetEndPoint Overloaded method.
        protected virtual string GetEndPoint(string Resource)
        {
            return Resource;
        }
        protected virtual string GetEndPoint(string Resource, List<KeyValuePair<string, string>> Filters)
        {
            List<string> filters = new List<string>();
            foreach (KeyValuePair<string, string> filter in Filters)
            {
                filters.Add(filter.Key + "=" + filter.Value);
            }

            return Resource + "?" + string.Join("&", filters.ToArray());
        }

        protected virtual string GetEndPoint(string Resource, string Id)
        {
            return Resource + Id;
        }
        protected virtual string GetEndPoint(string Resource, string Id, List<KeyValuePair<string, string>> Filters)
        {
            List<string> filters = new List<string>();
            foreach (KeyValuePair<string, string> filter in Filters)
            {
                filters.Add(filter.Key + "=" + filter.Value);
            }

            return Resource + Id + "?" + string.Join("&", filters.ToArray());
        }

        protected virtual string GetEndPoint(string Resource, string Id, string SubResource)
        {
            return Resource + Id + "/" + SubResource;
        }   
        protected virtual string GetEndPoint(string Resource, string Id, string SubResource, List<KeyValuePair<string, string>> Filters)
        {
            List<string> filters = new List<string>();
            foreach (KeyValuePair<string, string> filter in Filters)
            {
                filters.Add(filter.Key + "=" + filter.Value);
            }

            return Resource + Id + "/" + SubResource + "?" + string.Join("&", filters.ToArray());
        }
    }
}
