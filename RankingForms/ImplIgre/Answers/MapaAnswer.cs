using RankingForms.Questions;

namespace RankingForms.ImplIgre.Answers
{
    public class MapaAnswer : Answer
    {
        public string Country { get; set; }

        public MapaAnswer(string country)
        {
            Country = country;
            Type = typeof(QuestionMaps);
        }
        
        
    }
}