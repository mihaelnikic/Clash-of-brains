using System;
using System.Collections.Generic;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RankingForms.Dialogs;
using RankingForms.ImplIgre;
using RankingForms.MatchEnd;
using RankingForms.MatchStart;

namespace RankingForms.MenuActivities
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PlayerChooseMenu : Activity
    {
        private TextView playerMenuTitle;
        public Button SinglePlayerButton;
        public Button MultiPlayerButton;
        public Button PracticeButton;
        private List<Question> questions;

        private TextView loadTextView;

        private static PracticeGame gamer;
        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //OVAJ THEMER MIJENJANJE TEKSTA KASNIJE POBRISATI
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.playgame_menu);
            // Create your application here
            playerMenuTitle = FindViewById<TextView>(Resource.Id.textSinMultPrac);
            SinglePlayerButton = FindViewById<Button>(Resource.Id.buttonSinglePlayerChoose);
            MultiPlayerButton = FindViewById<Button>(Resource.Id.buttonMultiplayerChoose);
            PracticeButton = FindViewById<Button>(Resource.Id.buttonPracticeChoose);

            loadTextView = FindViewById<TextView>(Resource.Id.textViewProgressBar);
            loadTextView.Visibility = ViewStates.Gone;
            gamer = themer.gamer;

            //themes
            playerMenuTitle.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            SinglePlayerButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            MultiPlayerButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            PracticeButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            loadTextView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);

            //Akcije
            PracticeButton.Click += ResetGamePractice;
            PracticeButton.Click += PracticeButtonOnClick;

            MultiPlayerButton.Click += ResetGameMultiplayer;

            SinglePlayerButton.Click += ResetGameSinglePlayer;
            SinglePlayerButton.Click += (sender, args) => SinglePlayerButtonOnClick(true, args);
        }

        //
        //MULTI_PLAYER
        //
        private void ResetGameMultiplayer(object sender, EventArgs e)
        {
            loadMode(true);
            gamer.ResetQuestionAcitivity();
            Intent intent = new Intent(this, typeof(PlayerChooseList));
            this.StartActivityForResult(intent, ConstantActivityResult.MULTIPLAYER_SELECT_LIST);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        private void MultiplayerPlayGame(object sender, EventArgs eventArgs)
        {
            if (gamer.HasNextQuestion())
            {
                questions = gamer.GetNextQuestion();
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_poruka dialogPoruka = new dialog_poruka();
                dialogPoruka.OnDismissAction += (o, args) => multiPlayerSelectQuestion();
                dialogPoruka.Show(transaction, "Jedan od igraèa s najmanje bodova bira kategoriju:\n>\t" 
                + gamer.getLowestScorePlayer().PlayerName);
                gamer.EnterNextMultiplayerQuestion();
            }
            else
            {
                Intent intent = new Intent(this, typeof(RankLocalActivity));
                intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
                this.StartActivityForResult(intent, ConstantActivityResult.PRACTICE_END);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
                loadMode(false);
            }
        }

        private void multiPlayerSelectQuestion()
        {
            Intent intent = new Intent(this, typeof(ChoiceMenu));
            intent.PutExtra("Pitanja", JsonConvert.SerializeObject(questions));
            intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
            intent.PutExtra("NoOfPitanje", gamer.getCurrentQuestionIndex() + "/" + gamer.getNoOfQuestions());
            this.StartActivityForResult(intent, ConstantActivityResult.MULTIPLAYER_NEXT_CATEGORY);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }

        private void multiPlayerNextPlayer(Question q)
        {
            Intent intent = new Intent(this, q.GetAnswerType());
            intent.PutExtra("Pitanje", JsonConvert.SerializeObject(q));
            intent.PutExtra("Odgovori", JsonConvert.SerializeObject(q.Odgovor));
            this.StartActivityForResult(intent, ConstantActivityResult.MULTIPLAYER_NEXT_PLAYER);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
        //
        //SINGLE_PLAYER
        //
        private void ResetGameSinglePlayer(object sender, EventArgs eventArgs)
        {
            gamer.ResetQuestionAcitivity();
            gamer.AddPlayer("IGRAÈ");
            loadMode(true);
        }

        private void SinglePlayerButtonOnClick(object sender, EventArgs eventArgs)
        {
            if ((bool)sender)
            {
                questions = gamer.GetNextQuestion();
                Intent intent = new Intent(this, typeof(ChoiceMenu));
                intent.PutExtra("Pitanja", JsonConvert.SerializeObject(questions));
                intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
                intent.PutExtra("NoOfPitanje", gamer.getCurrentQuestionIndex() + "/" + "-");
                this.StartActivityForResult(intent, ConstantActivityResult.SINGLEPLAYER_NEXT_CATEGORY);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
                // break;
            }
            else
            {
                loadMode(false);
                Intent intent = new Intent(this, typeof(RankSinglePlayerActivity));
                intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
                this.StartActivityForResult(intent, ConstantActivityResult.SINGLEPLAYER_END);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            }
        }
        //
        //PRACTICE
        //
        private void ResetGamePractice(object sender, EventArgs eventArgs)
        {
            gamer.ResetQuestionAcitivity();
            gamer.AddPlayer("IGRAÈ");
            loadMode(true);
        }

        private void PracticeButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (gamer.HasNextQuestion())
            {
                
                questions = gamer.GetNextQuestion();
                Intent intent = new Intent(this, typeof(ChoiceMenu));
                intent.PutExtra("Pitanja", JsonConvert.SerializeObject(questions));
                intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
                intent.PutExtra("NoOfPitanje", gamer.getCurrentQuestionIndex() + "/" + gamer.getNoOfQuestions());
                this.StartActivityForResult(intent, ConstantActivityResult.PRACTICE_NEXT_CATEGORY);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
                // break;
            }
            else
            {
                loadMode(false);
                Intent intent = new Intent(this, typeof(RankLocalActivity));
                intent.PutExtra("Lista", JsonConvert.SerializeObject(gamer.GetPlayerStatsList()));
                this.StartActivityForResult(intent, ConstantActivityResult.PRACTICE_END);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            }
        }

        //
        //ZAJEDNICKO - povratak iz activity-a
        //
        private int currentQuestionIndex = 0;
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Canceled)
            {
                loadMode(false);
                return;
            }
            if (data == null) return;
            if (requestCode == ConstantActivityResult.PRACTICE_NEXT_CATEGORY)
            {
                int result = int.Parse(data.Data.ToString());
                Question q = questions[result];
                Intent intent = new Intent(this, q.GetAnswerType());
                intent.PutExtra("Pitanje", JsonConvert.SerializeObject(q));
                intent.PutExtra("Odgovori", JsonConvert.SerializeObject(q.Odgovor));
                this.StartActivityForResult(intent, ConstantActivityResult.PRACTICE_NEXT_QUESTION);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            }
            else if (requestCode == ConstantActivityResult.PRACTICE_NEXT_QUESTION)
            {
                int result = int.Parse(data.Data.ToString());
                gamer.PlayerUpdateScore("IGRAÈ", result);
                //continue
                PracticeButtonOnClick(null, null);
                
            }
            else if (requestCode == ConstantActivityResult.PRACTICE_END)
            {
                bool result = bool.Parse(data.Data.ToString());
                if (result)
                {
                    this.Finish();
                    this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

                }
            }
            else if (requestCode == ConstantActivityResult.MULTIPLAYER_SELECT_LIST)
            {
                List<string> player = JsonConvert.DeserializeObject<List<string>>(data.DataString);
                player.ForEach(p => gamer.AddPlayer(p));
                MultiplayerPlayGame(null, null);
            }
            else if (requestCode == ConstantActivityResult.MULTIPLAYER_NEXT_CATEGORY)
            {
                currentQuestionIndex = int.Parse(data.Data.ToString());
                Question q = questions[currentQuestionIndex];

                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_poruka dialogPoruka = new dialog_poruka();
                dialogPoruka.OnDismissAction += (o, args) => multiPlayerNextPlayer(q);
                Thread.Sleep(600);
                dialogPoruka.Show(transaction, "Na redu je igraè:\n>\t"
                + gamer.GetCurrentPlayer().PlayerName);
            }
            else if (requestCode == ConstantActivityResult.MULTIPLAYER_NEXT_PLAYER)
            {
                int result = int.Parse(data.Data.ToString());
                gamer.PlayerUpdateScore(gamer.GetNextPlayer().PlayerName, result);
                if (!gamer.HasNextPlayer())
                {
                    MultiplayerPlayGame(null, null);
                }
                else
                {
                    Question q = questions[currentQuestionIndex];
                    FragmentTransaction transaction = FragmentManager.BeginTransaction();
                    dialog_poruka dialogPoruka = new dialog_poruka();
                    dialogPoruka.OnDismissAction += (o, args) => multiPlayerNextPlayer(q);
                    Thread.Sleep(600);
                    dialogPoruka.Show(transaction, "Na redu je igraè:\n>\t"
                    + gamer.GetCurrentPlayer().PlayerName);
                }
            }
            else if (requestCode == ConstantActivityResult.SINGLEPLAYER_NEXT_CATEGORY)
            {
                int result = int.Parse(data.Data.ToString());
                Question q = questions[result];
                Intent intent = new Intent(this, q.GetAnswerType());
                intent.PutExtra("Pitanje", JsonConvert.SerializeObject(q));
                intent.PutExtra("Odgovori", JsonConvert.SerializeObject(q.Odgovor));
                this.StartActivityForResult(intent, ConstantActivityResult.SINGLEPLAYER_NEXT_QUESTION);
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            }
            else if (requestCode == ConstantActivityResult.SINGLEPLAYER_NEXT_QUESTION)
            {
                int result = int.Parse(data.Data.ToString());
                gamer.PlayerUpdateScore("IGRAÈ", result);
                //continue
                SinglePlayerButtonOnClick(result != 0, null);

            }
            else if (requestCode == ConstantActivityResult.SINGLEPLAYER_END)
            {
                bool result = bool.Parse(data.Data.ToString());
                if (result)
                {
                    this.Finish();
                    this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);

                }
            }
            
        }

        //Loading...
        private void loadMode(bool visible)
        {
            var visibleViewNegate = !visible ? ViewStates.Visible : ViewStates.Invisible;
            var visibileView = visible ? ViewStates.Visible : ViewStates.Invisible;
            playerMenuTitle.Visibility = visibleViewNegate;
            SinglePlayerButton.Visibility = visibleViewNegate;
            MultiPlayerButton.Visibility = visibleViewNegate;
            PracticeButton.Visibility = visibleViewNegate;

            loadTextView.Visibility = visibileView;
        }   
    }
}