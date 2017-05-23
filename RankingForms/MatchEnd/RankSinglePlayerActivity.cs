using System;
using System.Collections.Generic;
using System.IO;
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
using RankingForms.Dialogs;
using RankingForms.FinalPlayerResult;
using RankingForms.ImplIgre;
using RankingForms.MenuActivities;
using Uri = Android.Net.Uri;

namespace RankingForms.MatchEnd
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class RankSinglePlayerActivity : Activity
    {
        private List<PlayerStat> playerList;

        private TextView titleTextView;

        private ListView tileListView;
        public ListView playerListView;

        public Button highScoreButton;
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
            SetContentView(Resource.Layout.singlePlayerList);

            playerListView = FindViewById<ListView>(Resource.Id.myListViewSP);

            titleTextView = FindViewById<TextView>(Resource.Id.textKrajIgreSP);
            tileListView = FindViewById<ListView>(Resource.Id.titleListViewSP);

            rePlayButton = FindViewById<Button>(Resource.Id.buttonProceedSP);
            menuBackButton = FindViewById<Button>(Resource.Id.buttonMenuSP);
            highScoreButton = FindViewById<Button>(Resource.Id.buttonHighScore);

            playerList = JsonConvert.DeserializeObject<List<PlayerStat>>(Intent.GetStringExtra("Lista"));
            playerList.Sort((stat1, stat2) => -1 * stat1.PerQuestionScore.Sum().CompareTo(stat2.PerQuestionScore.Sum()));
            tileListView.Adapter = new TitleListViewAdapter(this);

            PlayerListViewAdapter adapter = new PlayerListViewAdapter(this, playerList);

            //akcije
            playerListView.Adapter = adapter;

            playerListView.ItemClick += PlayerListViewOnItemClick;
            rePlayButton.Click += (sender, args) => ButtonClick(false);
            menuBackButton.Click += (sender, args) => ButtonClick(true);
            highScoreButton.Click += HighScoreButtonOnClick;
            //teme
            highScoreButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            titleTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            rePlayButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            menuBackButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
        }

        private void HighScoreButtonOnClick(object sender, EventArgs eventArgs)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //  dialog_AddPlayer dialogAddPlayer = new dialog_AddPlayer();
            //   dialogAddPlayer.Show(transaction, "add player");
            dialog_AddPlayer dialogPoruka = new dialog_AddPlayer();
            dialogPoruka.InputHandler += RegisterHighScore;
            dialogPoruka.Show(transaction, "ok");
        }

        private void RegisterHighScore(object sender, EventArgs e)
        {
            string text = sender.ToString();
            if (text.Length < 1 || text.Length > 15)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_poruka dialogPoruka = new dialog_poruka();
                dialogPoruka.Show(transaction, "Duljina imena mora biti izmeðu 1 do 15 znakova!");
            }
            else
            {
                AddHighScoreToDatabase(text);
                highScoreButton.Enabled = false;
                highScoreButton.SetBackgroundResource(Resource.Drawable.buttonDisabled);
            }
        }

        private void AddHighScoreToDatabase(string playerName)
        {
            //dodaj u bazu
            PlayerStat player = playerList.ElementAt(0);
            player.PlayerName = playerName;
            string json = JsonConvert.SerializeObject(player);
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string filePath = System.IO.Path.Combine(path, "playerstats.txt");

            FileMode fileMode;
            fileMode = File.Exists(filePath) ? FileMode.Append : FileMode.Create;

            using (var file = File.Open(filePath, fileMode, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.WriteLine(json);
            }
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