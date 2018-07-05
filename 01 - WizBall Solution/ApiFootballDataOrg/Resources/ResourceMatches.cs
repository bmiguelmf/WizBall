using System.Collections.Generic;
using System.Web.Script.Serialization;

using ApiFootballDataOrg.Entities;


namespace ApiFootballDataOrg.Resources
{
    public class ResourceMatches : Resource
    {
        public ResourceMatches(string Token) : base(Token)
        {            
        }


        // List all matches for a particular competition.
        public List<Match> GetByCompetition(string CompetitionId)
        {
            string endPoint = GetEndPoint(Globals.URL_COMPETITIONS, CompetitionId, "matches");                          // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));              // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonMatches = serializer.Serialize(((Dictionary<string, object>)objResponse)["matches"]);            // Serializes only the matches node into a json string.
            object lstMatches = serializer.Deserialize(jsonMatches, typeof(List<Match>));                               // Deserializes the jsonMatches into a List<Match>.

            return lstMatches as List<Match>;
        }

        // List one particular match.
        public Match GetById(string MatchId)
        {
            string endPoint = GetEndPoint(Globals.URL_MATCHES, MatchId);                                                // Generate the end point.

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object match = serializer.Deserialize(jsonResponse, typeof(Match));                                         // Deserializes the jsonResponse into a match.

            return match as Match;
        }

        public List<Match> GetByCompetitionAndStatus(string CompetitionId, string Status)
        {
            string endPoint = GetEndPoint(Globals.URL_COMPETITIONS,                                                      // Generate the end point.
                                          CompetitionId, 
                                          "matches",
                                          new List<KeyValuePair<string, string>>() { new KeyValuePair<string, string>("status", Status) });

            string jsonResponse = DownloadString(endPoint);                                                             // Executes the request agains the end point.

            JavaScriptSerializer serializer = new JavaScriptSerializer();                                               // Serializer object to manipulate jsons.
            object objResponse = serializer.Deserialize(jsonResponse, typeof(Dictionary<string, object>));              // Deserializes the jsonResponse into an object of type Dictionary<string, object>.
            string jsonMatches = serializer.Serialize(((Dictionary<string, object>)objResponse)["matches"]);            // Serializes only the matches node into a json string.
            object lstMatches = serializer.Deserialize(jsonMatches, typeof(List<Match>));                               // Deserializes the jsonMatches into a List<Match>.

            return lstMatches as List<Match>;

        }

    }
}
