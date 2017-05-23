using RankingForms.Questions;

namespace RankingForms.ImplIgre.Answers
{
    public class ZaokruzivanjeAnswer : Answer
    {
        public string Prvi { get; set; }
        public string Drugi { get; set; }
        public string Treci { get; set; }
        public string Cetvrti { get; set; }
        public string TocanOdgovor { get; set; }

        public ZaokruzivanjeAnswer(string prvi, string drugi, string treci, string cetvrti, string tocanOdgovor)
        {
            Prvi = prvi;
            Drugi = drugi;
            Treci = treci;
            Cetvrti = cetvrti;
            TocanOdgovor = tocanOdgovor;
            Type = typeof(QuestionStandard);
        }
    }
}