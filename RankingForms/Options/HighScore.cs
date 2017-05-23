using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using Environment = System.Environment;
using Path = Android.Graphics.Path;

namespace RankingForms.Options
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class HighScore : Activity
    {
        private TextView title;
        private ListView titleListView;
        private ListView playerListView;
        private Button menuBackButton;
        private List<PlayerStat> playerList;

        private Themer.Themer themer = Themer.Themer.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HighScore);

            title = FindViewById<TextView>(Resource.Id.textWorldRanking);
            titleListView = FindViewById<ListView>(Resource.Id.titleListViewWR);
            playerListView = FindViewById<ListView>(Resource.Id.myListViewWR);

            menuBackButton = FindViewById<Button>(Resource.Id.buttonMenuWR);

            playerList = UcitajHighScoreListu();
            playerList.Sort((stat1, stat2) => -1 * stat1.PerQuestionScore.Sum().CompareTo(stat2.PerQuestionScore.Sum()));
            titleListView.Adapter = new TitleListViewAdapter(this);

            PlayerListViewAdapter adapter = new PlayerListViewAdapter(this, playerList);
            playerListView.Adapter = adapter;

            //teme
            title.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            menuBackButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);

            //akcije
            menuBackButton.Click += (sender, args) =>
            {
                this.Finish();
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            };
        }

        private List<PlayerStat> UcitajHighScoreListu()
        {
            string json;
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filePath = System.IO.Path.Combine(path, "playerstats.txt");
            List<PlayerStat> players = new List<PlayerStat>();
            if (File.Exists(filePath))
            {
                
                using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read))
                using (var strm = new StreamReader(file))
                {
                    while (!strm.EndOfStream)
                    {
                        json = strm.ReadLine();
                        players.Add(JsonConvert.DeserializeObject<PlayerStat>(json));
                    }
                    
                }
                
            }


            return players;
        }
    }
}