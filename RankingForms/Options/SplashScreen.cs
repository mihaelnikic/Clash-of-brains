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
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using RankingForms.MenuActivities;

namespace RankingForms.Options
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        private TextView title;
        private ImageView image;
        private Themer.Themer themer = Themer.Themer.Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.splash);
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            title = FindViewById<TextView>(Resource.Id.textSplashTitle);
            image = FindViewById<ImageView>(Resource.Id.imageViewSplash);

            var imageBitmap = WebImageUtils.GetImageBitmapFromUrl(
                "http://www.deviantpics.com/images/2016/05/24/logo.gif");
            image.SetImageBitmap(imageBitmap);

            //tema
            title.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            // Create your application here
            
            new LoadQuestionTask(themer, this).Execute(1, 2, 3);
        }

        private class LoadQuestionTask : AsyncTask<int,int,int>
        {
            public Themer.Themer themer;
            public Activity activity;

            public LoadQuestionTask(Themer.Themer themer, Activity activity)
            {
                this.themer = themer;
                this.activity = activity;
            }

            protected override int RunInBackground(params int[] @params)
            {
                Thread.Sleep(4000);
                themer.gamer = new PracticeGame(10);
                Intent intent = new Intent(activity, typeof(MainMenu));
                activity.StartActivity(intent);
                activity.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
                activity.Finish();
                return 0;
            }
        }

        
    }
}