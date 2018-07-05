using System.Net;
using System.Text;
using System.Collections.Generic;

namespace ApiFootballDataOrg.Resources
{
    public abstract class Resource
    {
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
  
            //while (response.Contains("null"))
            //{             
            //    int endIndex = response.IndexOf("null") + 5;
            //    int startIndex = endIndex;
            //    int count = 0;

            //    while (count < 2)
            //    {
            //        startIndex--;
            //        if (response[startIndex].ToString() == "," || response[startIndex].ToString() == "{")
            //            count++;
            //    };
            //    startIndex++;

            //    string sub = response.Substring(startIndex, (endIndex - startIndex));
            //    response = response.Remove(startIndex, (endIndex - startIndex));
            //};



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
