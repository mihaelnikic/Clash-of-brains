using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Objects.Answers
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
            Type = AnswerEnum.SlikaOdogovor;
        }
    }
}