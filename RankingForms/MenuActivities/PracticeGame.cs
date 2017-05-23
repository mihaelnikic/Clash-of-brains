using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using RankingForms.ImplIgre;
using RankingForms.ImplIgre.Answers;
using RankingForms.ImplIgre.Generators;
using RankingForms.Questions;

namespace RankingForms.MenuActivities
{
    public class PracticeGame
    {
        private List<PlayerStat> playerStats;
        private int noOfQuestions;
        private int count;
        private int playerNext;
        private IQuestionGenerator questionGenerator;

        public PracticeGame(int noOfQuestions)
        {
            this.noOfQuestions = noOfQuestions;
            this.count = 0;
            questionGenerator = new MockGenerator2();
            playerStats = new List<PlayerStat>();
        }

        public bool HasNextQuestion()
        {
            return count < noOfQuestions;
        }

        public List<Question> GetNextQuestion()
        {
            count++;
            return questionGenerator.GenerateNextQuestions();
        }

        public void ResetQuestionAcitivity()
        {
            count = 0;
            playerStats.Clear();
            questionGenerator.Clear();
        }

        public int getCurrentQuestionIndex()
        {
            return count;
        }

        public int getNoOfQuestions()
        {
            return noOfQuestions;
        }

        public void AddPlayer(string name)
        {
            playerStats.Add(new PlayerStat(name, noOfQuestions));
        }

        public void PlayerUpdateScore(string name, int score)
        {
            playerStats.Find(f => f.PlayerName.Equals(name)).PerQuestionScore.Add(score);
        }

        public List<PlayerStat> GetPlayerStatsList()
        {
            return playerStats;
        }

        public PlayerStat getLowestScorePlayer()
        {
            int min = playerStats.Min(player => sumPlayerScore(player.PlayerName));
            var low = playerStats.Where(player => sumPlayerScore(player.PlayerName) == min);
            var enumerable = low as IList<PlayerStat> ?? low.ToList();
            return enumerable.ElementAt(new Random().Next(enumerable.Count()));
        }

        private int sumPlayerScore(string player)
        {
            return playerStats.Find(f => f.PlayerName.Equals(player)).PerQuestionScore.Sum();
        }

        public void EnterNextMultiplayerQuestion()
        {
            playerNext = 0;
        }

        public bool HasNextPlayer()
        {
            return playerNext < playerStats.Count;
        }

        public PlayerStat GetNextPlayer()
        {
            return playerStats[playerNext++];
        }

        public PlayerStat GetCurrentPlayer()
        {
            return playerStats[playerNext];
        }
    }
}