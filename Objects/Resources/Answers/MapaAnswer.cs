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
    public class MapaAnswer : Answer
    {
        public double X { get; }
        public double Y { get; }

        public MapaAnswer(double x, double y)
        {
            X = x;
            Y = y;
            Type = AnswerEnum.MapaOdogovor;
        }
        
        
    }
}