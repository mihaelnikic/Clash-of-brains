using System.Collections.Generic;

namespace RankingForms
{
    public class PlayerStat
    {
        public PlayerStat(string playerName, int noOfQuestion)
        {
            PlayerName = playerName;
            PerQuestionScore = new List<int>(noOfQuestion);
        }

        public string PlayerName { get; set; }

        public List<int> PerQuestionScore { get; set; }

    }
}