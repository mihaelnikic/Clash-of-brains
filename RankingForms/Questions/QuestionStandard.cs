using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
using RankingForms.Options;
using Uri = Android.Net.Uri;

namespace RankingForms.Questions
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class QuestionStandard : Activity
    {
        public TextView TextTimer;
        public Button TitleButton;

        public Button Choice1Button;
        public Button Choice2Button;
        public Button Choice3Button;
        public Button Choice4Button;

        public TextView TextCategory;
        private ImageView questionPicture;

        private Question question;
        private ZaokruzivanjeAnswer answer;
        private Thread timerThread;
        private int Counter;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //question-ucitavanje
            question = JsonConvert.DeserializeObject<Question>(Intent.GetStringExtra("Pitanje"));
            answer = JsonConvert.DeserializeObject<ZaokruzivanjeAnswer>(Intent.GetStringExtra("Odgovori"));
            if (question.SlikaPitanja == null)
            {
                SetContentView(Resource.Layout.QuestionStandard);
                // Create your application here
                TextTimer = FindViewById<TextView>(Resource.Id.textQuestionStandardTimer);
                TitleButton = FindViewById<Button>(Resource.Id.buttonQuestionStandardTitle);
                Choice1Button = FindViewById<Button>(Resource.Id.buttonQuestionStandardA);
                Choice2Button = FindViewById<Button>(Resource.Id.buttonQuestionStandardB);
                Choice3Button = FindViewById<Button>(Resource.Id.buttonQuestionStandardC);
                Choice4Button = FindViewById<Button>(Resource.Id.buttonQuestionStandardD);
                TextCategory = FindViewById<TextView>(Resource.Id.textQuestionStandardCategory);
            }
            else
            {
                SetContentView(Resource.Layout.QuestionPicture);
                // Create your application here
                TextTimer = FindViewById<TextView>(Resource.Id.textQuestionPictureTimer);
                TitleButton = FindViewById<Button>(Resource.Id.buttonQuestionPictureTitle);
                Choice1Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureA);
                Choice2Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureB);
                Choice3Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureC);
                Choice4Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureD);
                TextCategory = FindViewById<TextView>(Resource.Id.textQuestionPictureCategory);
                questionPicture = FindViewById<ImageView>(Resource.Id.imageViewQuestionPicture);
                questionPicture.SetImageBitmap(WebImageUtils.GetImageBitmapFromUrl(question.SlikaPitanja));

            }
            //teme
            TextTimer.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            TitleButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice1Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice2Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice3Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice4Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            TextCategory.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);

            

            //dodavanje boja buttonima
            TitleButton.SetBackgroundResource(themer[question.Kategorija]);
            Choice1Button.SetBackgroundResource(themer[question.Kategorija]);
            Choice2Button.SetBackgroundResource(themer[question.Kategorija]);
            Choice3Button.SetBackgroundResource(themer[question.Kategorija]);
            Choice4Button.SetBackgroundResource(themer[question.Kategorija]);
            //dodavanje opisa pitanja buttoninam
            TitleButton.Text = question.TextPitanja;
            Choice1Button.Text = answer.Prvi;
            Choice2Button.Text = answer.Drugi;
            Choice3Button.Text = answer.Treci;
            Choice4Button.Text = answer.Cetvrti;
            TextCategory.Text = question.Kategorija.ToString();

            //akcije
            Choice1Button.Click += (sender, args) => ButtonClickIndex(answer.Prvi);
            Choice2Button.Click += (sender, args) => ButtonClickIndex(answer.Drugi);
            Choice3Button.Click += (sender, args) => ButtonClickIndex(answer.Treci);
            Choice4Button.Click += (sender, args) => ButtonClickIndex(answer.Cetvrti);
            timerThread = new Thread(new ThreadStart(() =>
            {
                TextTimer.Text = "Spremi se!".ToString();
                Counter = 15;
                Thread.Sleep(2000);
                for (int i = 15; i > 0; i--)
                {
                    RunOnUiThread(() => TextTimer.Text = i.ToString());
                    Thread.Sleep(1000);
                    this.Counter--;
                }
                RunOnUiThread(() => TextTimer.Text = 0.ToString());
                ProcessAnswer(false);
            }));
            timerThread.Start();
        }

        private void ButtonClickIndex(string inputAnswer)
        {
            timerThread.Abort();
            bool isTrue = answer.TocanOdgovor.Equals(inputAnswer);
            ProcessAnswer(isTrue);
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
                score = Counter * 15;
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