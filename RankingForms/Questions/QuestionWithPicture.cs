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

namespace RankingForms
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class QuestionWithPicture : Activity
    {
        public TextView TextTimer;
        public Button TitleButton;
        public ImageView Picture;

        public Button Choice1Button;
        public Button Choice2Button;
        public Button Choice3Button;
        public Button Choice4Button;

        public TextView TextCategory;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //OVAJ THEMER MIJENJANJE TEKSTA KASNIJE POBRISATI
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.QuestionPicture);
            // Create your application here
            TextTimer = FindViewById<TextView>(Resource.Id.textQuestionPictureTimer);
            TitleButton = FindViewById<Button>(Resource.Id.buttonQuestionPictureTitle);
            Picture = FindViewById<ImageView>(Resource.Id.imageViewQuestionPicture);
            Choice1Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureA);
            Choice2Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureB);
            Choice3Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureC);
            Choice4Button = FindViewById<Button>(Resource.Id.buttonQuestionPictureD);
            TextCategory = FindViewById<TextView>(Resource.Id.textQuestionPictureCategory);

            //teme
            TextTimer.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            TitleButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice1Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice2Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice3Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            Choice4Button.SetTypeface(themer.NavButtonText, TypefaceStyle.Bold);
            TextCategory.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
        }
    }
}