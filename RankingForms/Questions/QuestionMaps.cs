using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using RankingForms.ImplIgre;
using RankingForms.ImplIgre.Answers;
using RankingForms.MenuActivities;
using RankingForms.Options;
using Uri = Android.Net.Uri;

namespace RankingForms.Questions
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class QuestionMaps : Activity
    {
        public TextView TextTimer;
        public Button TitleButton;

        public Button OpenMapButton;
        public Button CloseAnswerButton;

        public TextView TextCategory;
        public ImageView questionPicture;

        private Question question;
        private MapaAnswer answer;
        private Intent intent;
        private Thread timerThread;
        private int Counter;
        private bool result;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            

            base.OnCreate(savedInstanceState);
            //question-ucitavanje
            question = JsonConvert.DeserializeObject<Question>(Intent.GetStringExtra("Pitanje"));
            answer = JsonConvert.DeserializeObject<MapaAnswer>(Intent.GetStringExtra("Odgovori"));

            if (question.SlikaPitanja == null)
            {
                SetContentView(Resource.Layout.QuestionMaps);
                // Create your application here
                TextTimer = FindViewById<TextView>(Resource.Id.textQuestionMapsTimer);
                TitleButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsTitle);
                OpenMapButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsOtvori);
                CloseAnswerButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsZakljucaj);
                TextCategory = FindViewById<TextView>(Resource.Id.textQuestionMapsCategory);
                
            }
            else
            {
                SetContentView(Resource.Layout.QuestionMapPicture);
                // Create your application here
                TextTimer = FindViewById<TextView>(Resource.Id.textQuestionMapsPictureTimer);
                TitleButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsPictureTitle);
                OpenMapButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsPicturePictureOtvori);
                CloseAnswerButton = FindViewById<Button>(Resource.Id.buttonQuestionMapsPictureZakljucaj);
                TextCategory = FindViewById<TextView>(Resource.Id.textQuestionMapsPictureCategory);
                questionPicture = FindViewById<ImageView>(Resource.Id.imageViewQuestionMapsPicture);
                questionPicture.SetImageBitmap(WebImageUtils.GetImageBitmapFromUrl(question.SlikaPitanja));
            }

            //teme
            TextTimer.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            TitleButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            OpenMapButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            CloseAnswerButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            TextCategory.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);

            
         
            //dodavanje boja buttonima
            TitleButton.SetBackgroundResource(themer[question.Kategorija]);
            OpenMapButton.SetBackgroundResource(themer[question.Kategorija]);
            CloseAnswerButton.SetBackgroundResource(themer[question.Kategorija]);
            //dodavanje opisa pitanja buttoninam
            TitleButton.Text = question.TextPitanja;
            TextCategory.Text = question.Kategorija.ToString();

            OpenMapButton.Click += OpenMapButtonOnClick;
            CloseAnswerButton.Click += CloseAnswerButtonOnClick;

            result = false;
            timerThread = new Thread(new ThreadStart(() =>
            {
                TextTimer.Text = "Spremi se!".ToString();
                Counter = 30;
                Thread.Sleep(2000);
                for (int i = 30; i > 0; i--)
                {
                    RunOnUiThread(() => TextTimer.Text = i.ToString());
                    Thread.Sleep(1000);
                    this.Counter--;
                }
                RunOnUiThread(() => TextTimer.Text = 0.ToString());
                FinishMapActivity();
            }));
            timerThread.Start();
        }

        private void CloseAnswerButtonOnClick(object sender, EventArgs eventArgs)
        {
            timerThread.Abort();
            ProcessAnswer(result);
        }

        private void FinishMapActivity()
        {
            this.FinishActivity(ConstantActivityResult.GOOGLE_MAP_ACTIVITY);
            ProcessAnswer(false);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (data == null) return;
            if (requestCode == ConstantActivityResult.GOOGLE_MAP_ACTIVITY)
            {
                result = answer.Country.Equals(data.DataString);
            }
        }


        private void OpenMapButtonOnClick(object sender, EventArgs eventArgs)
        {
            //ovdje trebaju biti mape...
            intent = new Intent(this, typeof(GoogleMaps));
            this.StartActivityForResult(intent, ConstantActivityResult.GOOGLE_MAP_ACTIVITY);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);;
        }

        public void ProcessAnswer(bool isTrue)
        {
            Intent data = new Intent();

            string poruka;
            int score = 0;
            if (Counter == 0)
            {
                poruka = "Vrijeme isteklo!";
            }
            else if (isTrue)
            {
                score = (int)((double)Counter * 7.5);
                poruka = "Tocan Odgovor!\nOsvojili ste " + score + " bodova!";
            }
            else
            {
                poruka = "Netoèan odgovor!";
            }
            data.SetData(Uri.Parse(score.ToString()));
            SetResult(Result.Ok, data);
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_poruka dialogPoruka = new dialog_poruka();
            dialogPoruka.Show(transaction, poruka);
            dialogPoruka.OnDismissAction += (sender, args) =>
            {
                this.Finish();
                this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            };
        }
    }
}