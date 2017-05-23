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

namespace RankingForms.Options
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class About : Activity
    {

        private TextView titleAboutUs;
        private TextView textAboutUs;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.about);

            titleAboutUs = FindViewById<TextView>(Resource.Id.textAboutTitle);
            textAboutUs = FindViewById<TextView>(Resource.Id.textAboutUs);

            //teme
            titleAboutUs.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            textAboutUs.SetTypeface(themer.NormalText, TypefaceStyle.Italic);

            textAboutUs.Text = "";
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
        }
    }
}