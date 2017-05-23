using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Javax.Crypto.Interfaces;
using RankingForms.ImplIgre;
using RankingForms.MenuActivities;
using Object = Java.Lang.Object;

namespace RankingForms.Themer
{
    public class Themer
    {
        public int this[Kategorija index]
        {
            get
            {
                switch (index)
                {
                    case Kategorija.Zemljopis:
                        return GreenButtonColor;
                    case Kategorija.Povijest:
                        return OrangeButtonColor;
                    case Kategorija.Tehnologija:
                        return BlueButtonColor;
                    case Kategorija.Zabava:
                        return YellowButtonColor;
                    case Kategorija.Znanost:
                        return PurpleButtonColor;
                    case Kategorija.Umjetnost:
                        return RedButtonColor;
                }
                return 0;
            }
        }
        public Typeface NormalText { get; set; }
        public Typeface NavButtonText { get; set; }

        public PracticeGame gamer { get; set; }

        public int NormalBackground { get; set; }
        public int QuestionBackground { get; set; }

        private Dictionary<string, string> _localizer;
        public MediaPlayer ButtonClickPlayer { get; set; }

       
        private Themer()
        {
            NormalText = null;
            _localizer = new Dictionary<string, string>();
            ButtonClickPlayer = null;
            InitLocalizer();
        }

        public static Themer Instance { get; } = new Themer();

        private void InitLocalizer()
        {
            _localizer.Add("POZICIJA","Pozicija");
            _localizer.Add("IGRAC", "Igraè");
            _localizer.Add("BODOVI", "Bodovi");
        }

        public string Translate(string word) => _localizer[word];

        public void ButtonClickSound(object sender, EventArgs eventArgs)
        {
           // ButtonClickPlayer.Start();
        }

        public int RedButtonColor { get; set; }
        public int BlueButtonColor { get; set; }
        public int GreenButtonColor { get; set; }
        public int PurpleButtonColor { get; set; }
        public int OrangeButtonColor { get; set; }
        public int YellowButtonColor { get; set; }
    }

    
}