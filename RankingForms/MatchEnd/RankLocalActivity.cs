using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using RankingForms.FinalPlayerResult;
using RankingForms.ImplIgre;
using RankingForms.MenuActivities;
using Uri = Android.Net.Uri;

namespace RankingForms
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RankLocalActivity : Activity
    {

        private List<PlayerStat> playerList;
        
        private TextView titleTextView;

        private ListView tileListView;
        public ListView playerListView;

        public Button rePlayButton;
        public Button menuBackButton;

        private Themer.Themer themer = Themer.Themer.Instance;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            //OVAJ THEMER MIJENJANJE TEKSTA KASNIJE POBRISATI
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");

            //OVO OSTAVITI
            //themer.ButtonClickPlayer = MediaPlayer.Create(this, Resource.Raw.Click1);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            playerListView = FindViewById<ListView>(Resource.Id.myListView);

            titleTextView = FindViewById<TextView>(Resource.Id.textKrajIgre);
            tileListView = FindViewById<ListView>(Resource.Id.titleListView);

            rePlayButton = FindViewById<Button>(Resource.Id.buttonProceed);
            menuBackButton = FindViewById<Button>(Resource.Id.buttonMenu);

            playerList = JsonConvert.DeserializeObject<List<PlayerStat>>(Intent.GetStringExtra("Lista"));
            playerList.Sort((stat1, stat2) => -1*stat1.PerQuestionScore.Sum().CompareTo(stat2.PerQuestionScore.Sum()));
            tileListView.Adapter = new TitleListViewAdapter(this);

            PlayerListViewAdapter adapter = new PlayerListViewAdapter(this, playerList);

            //akcije
            playerListView.Adapter = adapter;
            
            playerListView.ItemClick += PlayerListViewOnItemClick;
            rePlayButton.Click += (sender, args) => ButtonClick(false);
            menuBackButton.Click += (sender, args) => ButtonClick(true);
            //teme
            titleTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            rePlayButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            menuBackButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
        }

        private void PlayerListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            Intent intent = new Intent(this, typeof(FinalPlayerRes));
            intent.PutExtra("Rezultat", JsonConvert.SerializeObject(playerList[itemClickEventArgs.Position].PerQuestionScore));
            this.StartActivityForResult(intent, ConstantActivityResult.PRACTICE_NEXT_CATEGORY);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        private void ButtonClick(bool shouldReturnToMainForm)
        {
            Intent data = new Intent();
            data.SetData(Uri.Parse(shouldReturnToMainForm.ToString()));
            SetResult(Result.Ok, data);
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}

