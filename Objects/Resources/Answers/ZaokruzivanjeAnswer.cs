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
            Type = AnswerEnum.ZaokruzivanjeOdgovor;
        }
    }
}