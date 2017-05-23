using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RankingForms.ImplIgre;
using Uri = Android.Net.Uri;

namespace RankingForms
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar",
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class ChoiceMenu : Activity
    {
        private TextView titleTextView;

        public Button category1Button;
        public Button category2Button;
        public Button category3Button;
        public Button category4Button;

        private TextView titleNoOfQuestion;
        private TextView noOfQuestion;
        private ListView listViewTitle;
        private ListView scoreListView;

        private List<PlayerStat> playerList;
        private List<Question> questions;
        private int result;

        private Themer.Themer themer = Themer.Themer.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //OVAJ THEMER MIJENJANJE TEKSTA KASNIJE POBRISATI
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChoiceMenu);
            // Create your application here
            titleTextView = FindViewById<TextView>(Resource.Id.textOdaberiKategoriju);
            category1Button = FindViewById<Button>(Resource.Id.buttonCategory1);
            category2Button = FindViewById<Button>(Resource.Id.buttonCategory2);
            category3Button = FindViewById<Button>(Resource.Id.buttonCategory3);
            category4Button = FindViewById<Button>(Resource.Id.buttonCategory4);

            titleNoOfQuestion = FindViewById<TextView>(Resource.Id.textViewPitanjeBrTitle);
            noOfQuestion = FindViewById<TextView>(Resource.Id.textViewPitanjeBr);
            listViewTitle = FindViewById<ListView>(Resource.Id.titleListChoiceMenu);
            scoreListView = FindViewById<ListView>(Resource.Id.myListViewChoiceMenu);

            //teme
            titleTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            category1Button.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            category2Button.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            category3Button.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            category4Button.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            titleNoOfQuestion.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            noOfQuestion.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            

            //ucitavanja
            questions = JsonConvert.DeserializeObject<List<Question>>(Intent.GetStringExtra("Pitanja"));

            playerList = JsonConvert.DeserializeObject<List<PlayerStat>>(Intent.GetStringExtra("Lista"));
            playerList.Sort((stat1, stat2) => -1 * stat1.PerQuestionScore.Sum().CompareTo(stat2.PerQuestionScore.Sum()));
            listViewTitle.Adapter = new TitleListViewAdapter(this);

            scoreListView.Adapter = new PlayerListViewAdapter(this, playerList);

            noOfQuestion.Text = Intent.GetStringExtra("NoOfPitanje");
            
            //dodavanje boja buttonima
            category1Button.SetBackgroundResource(themer[questions[0].Kategorija]);
            category2Button.SetBackgroundResource(themer[questions[1].Kategorija]);
            category3Button.SetBackgroundResource(themer[questions[2].Kategorija]);
            category4Button.SetBackgroundResource(themer[questions[3].Kategorija]);
            //dodavanje opisa pitanja buttoninam
            category1Button.Text = questions[0].OpisKategorije;
            category2Button.Text = questions[1].OpisKategorije;
            category3Button.Text = questions[2].OpisKategorije;
            category4Button.Text = questions[3].OpisKategorije;

            //akcije
            category1Button.Click += (sender, args) => buttonClickIndex(0);
            category2Button.Click += (sender, args) => buttonClickIndex(1);
            category3Button.Click += (sender, args) => buttonClickIndex(2);
            category4Button.Click += (sender, args) => buttonClickIndex(3);
        }

        private void buttonClickIndex(int index)
        {
            Intent data = new Intent();
            data.SetData(Uri.Parse(index.ToString()));
            SetResult(Result.Ok, data);
            Finish();
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }

}