using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Uri = Android.Net.Uri;

namespace RankingForms.MatchStart
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PlayerChooseList : Activity
    {
        private ObservableCollection<string> PlayerList;

        private TextView TitleTextView;

        private TextView TitleListNameView;
        public ListView PlayerListView;

        public Button AddPlayerButton;
        public Button StartGameButton;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            //OVAJ THEMER MIJENJANJE TEKSTA KASNIJE POBRISATI
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayerChooseLocal);
            TitleTextView = FindViewById<TextView>(Resource.Id.textPlayerChooseTitle);
            TitleListNameView = FindViewById<TextView>(Resource.Id.titlePlayerChooseLocal);
            PlayerListView = FindViewById<ListView>(Resource.Id.PlayerChooseList);
            AddPlayerButton = FindViewById<Button>(Resource.Id.buttonAddPlayerLocal);
            StartGameButton = FindViewById<Button>(Resource.Id.buttonStartGameLocal);

            //disable startGameButton na pocetku
            StartGameButton.Enabled = false;

            //inicijaliziacija liste s elementima
            PlayerList = new ObservableCollection<string>();

            //adapteri lista
            PlayerListView.Adapter = new PlayerChooseAdapterList(this, PlayerList);

            //teme
            TitleTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            TitleListNameView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            AddPlayerButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            StartGameButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            AddPlayerButton.SetBackgroundResource(Resource.Drawable.buttonOrange);
            StartGameButton.SetBackgroundResource(Resource.Drawable.buttonDisabled);


            // Create your application here

            //OVO POBRISATI
            AddPlayerButton.Click += AddPlayerButtonOnClick;
            PlayerListView.ItemClick += PlayerListViewOnItemClick;
            StartGameButton.Click +=StartGameButtonOnClick;
        }

        private void StartGameButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent data = new Intent();
            data.SetData(Uri.Parse(JsonConvert.SerializeObject(PlayerList)));
            SetResult(Result.Ok, data);
            this.Finish();
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        private void PlayerListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            PlayerList.RemoveAt(itemClickEventArgs.Position);
            PlayerListView.Adapter = new PlayerChooseAdapterList(this, PlayerList);
            if (PlayerList.Count < 2)
            {
                StartGameButton.Enabled = false;
                StartGameButton.SetBackgroundResource(Resource.Drawable.buttonDisabled);
            }
            if (!AddPlayerButton.Enabled)
            {
                AddPlayerButton.Enabled = true;
                AddPlayerButton.SetBackgroundResource(Resource.Drawable.buttonOrange);
            }

        }

        private void AddPlayerButtonOnClick(object sender, EventArgs eventArgs)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            //  dialog_AddPlayer dialogAddPlayer = new dialog_AddPlayer();
            //   dialogAddPlayer.Show(transaction, "add player");
            dialog_AddPlayer dialogPoruka = new dialog_AddPlayer();
            dialogPoruka.InputHandler += AddNewPlayerToList;
            dialogPoruka.Show(transaction, "ok");
        }

        private void AddNewPlayerToList(object sender, EventArgs eventArgs)
        {
            string text = sender.ToString();
            if (text.Length < 1 || text.Length > 15)
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_poruka dialogPoruka = new dialog_poruka();
                dialogPoruka.Show(transaction, "Duljina imena mora biti izmeðu 1 do 15 znakova!");
            }
            else if (PlayerList.Contains(text))
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_poruka dialogPoruka = new dialog_poruka();
                dialogPoruka.Show(transaction, "Igraè s takvim imenom veæ postoji!");
            }
            else
            {
                PlayerList.Add(text);
                if (PlayerList.Count >= 2)
                {
                    StartGameButton.Enabled = true;
                    StartGameButton.SetBackgroundResource(Resource.Drawable.buttonGreen);
                }
                if (PlayerList.Count >= 6)
                {
                    AddPlayerButton.Enabled = false;
                    AddPlayerButton.SetBackgroundResource(Resource.Drawable.buttonDisabled);
                }
            }
        }
    }
}