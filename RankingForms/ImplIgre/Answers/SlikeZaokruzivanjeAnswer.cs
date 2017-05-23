using Android.Widget;

namespace RankingForms.ImplIgre.Answers
{
    public class SlikeZaokruzivanjeAnswer : Answer
    {
        public ImageView Prvi { get; set; }
        public ImageView Drugi { get; set; }
        public ImageView Treci { get; set; }
        public ImageView Cetvrti { get; set; }
        public ImageView TocanOdgovor { get; set; }

        public SlikeZaokruzivanjeAnswer(ImageView prvi, ImageView drugi, ImageView treci, ImageView cetvrti, ImageView tocanOdgovor)
        {
            Prvi = prvi;
            Drugi = drugi;
            Treci = treci;
            Cetvrti = cetvrti;
            TocanOdgovor = tocanOdgovor;
            Type = typeof(QuestionWithPicture);
        }
    }
}