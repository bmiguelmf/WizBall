using BusinessLogic.Entities;

namespace WebApp.App_Code
{ //id, hometeam, away team, score, matchday, 
    public class MatchTruncated
    {
        #region Variable Definition
        private string  id;

        private string  competitionID;
        private string  competitionName;

        private string  hometeamID;
        private string  hometeamName;
        private string  hometeamShortName;
        private string  hometeamFlag;

        private string  awayteamID;
        private string  awayteamName;
        private string  awayteamShortName;
        private string  awayteamFlag;

        private Score   score;
        private int     matchday;
        private string  matchstage;
        private string  matchdate;
        #endregion
        #region Constructor
        public MatchTruncated(string ID, Team HomeTeam, Team AwayTeam, Score score, int? MatchDay, Competition competition, string MatchStage, string MatchDate)
        {
            this.id                 = ID;

            this.competitionID      = competition.Id.ToString();
            this.competitionName    = competition.Name;

            this.hometeamID         = HomeTeam.Id.ToString();
            this.hometeamName       = HomeTeam.Name;
            this.hometeamShortName  = HomeTeam.ShortName;
            this.hometeamFlag       = HomeTeam.Flag;

            this.awayteamID         = AwayTeam.Id.ToString();
            this.awayteamName       = AwayTeam.Name;
            this.awayteamShortName  = AwayTeam.ShortName;
            this.awayteamFlag       = AwayTeam.Flag;

            this.score              = score;
            this.matchday           = (int)MatchDay;
            this.matchstage         = MatchStage;
            this.matchdate          = MatchDate;
        }
        #endregion
        #region HomeTeam Selectors
        public string HomeTeamID
        {
            get { return hometeamID; }
        }

        public string HomeTeamName
        {
            get { return hometeamName; }
        }

        public string HomeTeamShortName
        {
            get { return hometeamShortName; }
        }

        public string HomeTeamFlag
        {
            get { return hometeamFlag; }
        }
        #endregion
        #region AwayTeam Selectors
        public string AwayTeamID
        {
            get { return awayteamID; }
        }

        public string AwayTeamName
        {
            get { return awayteamName; }
        }

        public string AwayTeamShortName
        {
            get { return awayteamShortName; }
        }

        public string AwayTeamFlag
        {
            get { return awayteamFlag; }
        }
        #endregion
        #region Competition Selectors
        public string CompetitionID
        {
            get { return competitionID; }
        }

        public string CompetitionName
        {
            get { return competitionName; }
        }
        #endregion
        #region Score Selectors
        public int ScoreHomeTeam
        {
            get { return (int)score.FullTime.HomeTeam; }
        }

        public int ScoreAwayTeam
        {
            get { return (int)score.FullTime.AwayTeam; }
        }
        #endregion
        #region Other Selectors
        public string ID
        {
            get { return id; }
        }

        public int MatchDay
        {
            get { return matchday; }
        }

        public string MatchStage
        {
            get { return matchstage; }
        }

        public string MatchDate
        {
            get { return matchdate; }
        }
        #endregion
    }
}