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

namespace RankingForms.FinalPlayerResult
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FinalPlayerRes : Activity
    {
        private List<int> playerScore;
        private TextView titleTextView;

        private ListView titleListView;
        private ListView playerScoreListView;

        private Button backButton;

        private Themer.Themer themer = Themer.Themer.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.FinalScoreList);

            titleTextView = FindViewById<TextView>(Resource.Id.textRezultatFinal);

            titleListView = FindViewById<ListView>(Resource.Id.titleFinalResult);
            playerScoreListView = FindViewById<ListView>(Resource.Id.myFinalResult);

            backButton = FindViewById<Button>(Resource.Id.buttonFinalResultBack);

            playerScore = JsonConvert.DeserializeObject<int[]>(Intent.GetStringExtra("Rezultat")).ToList();

            titleListView.Adapter = new FinalResultTitleAdapter(this);
            playerScoreListView.Adapter = new FinalResultAdapter(this, playerScore);
            
            //akcije
            backButton.Click += (sender, args) =>
            {
                this.Finish();
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            };
            titleTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            backButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
        }
    }
}