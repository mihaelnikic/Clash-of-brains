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
    public class OptionsMenu : Activity
    {
        private TextView titleOptionView;
        private TextView titleTemaView;

        private RadioGroup temaGroup;

        private TextView titleBrPitanjaView;

        private RadioGroup brPitanjaGroup;

        private Button ApplyButton;
        private Button GoBackButton;

        private Themer.Themer themer = Themer.Themer.Instance;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OptionsMenu);

            //Ucitavanje komponenata
            titleOptionView = FindViewById<TextView>(Resource.Id.textOptionTitle);
            titleTemaView = FindViewById<TextView>(Resource.Id.textOptionTema);
            temaGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupTema);
            titleBrPitanjaView = FindViewById<TextView>(Resource.Id.textOptionBrojPitanja);
            brPitanjaGroup = FindViewById<RadioGroup>(Resource.Id.radioGroupBrojPitanja);
            ApplyButton = FindViewById<Button>(Resource.Id.buttonOptionAzuriraj);
            GoBackButton = FindViewById<Button>(Resource.Id.buttonOptionBackMenu);

            //teme
            //font
            titleOptionView.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            titleTemaView.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            titleBrPitanjaView.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            ApplyButton.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            GoBackButton.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            //buttoni
            ApplyButton.SetBackgroundResource(themer.GreenButtonColor);
            GoBackButton.SetBackgroundResource(themer.RedButtonColor);
            // Create your application here
        }
    }
}