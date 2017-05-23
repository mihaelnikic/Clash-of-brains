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
using RankingForms.Options;

namespace RankingForms.MenuActivities
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainMenu : Activity
    {
        private TextView mainMenuTitle;
        public Button MainMenuNewGameButton;
        public Button MainMenuOptionsButton;
        public Button MainMenuAboutButton;

        private Themer.Themer themer = Themer.Themer.Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_menu);

            // Create your application here
            mainMenuTitle = FindViewById<TextView>(Resource.Id.textGameTitle);
            MainMenuNewGameButton = FindViewById<Button>(Resource.Id.buttonMenuNewGame);
            MainMenuOptionsButton = FindViewById<Button>(Resource.Id.buttonMenuOptions);
            MainMenuAboutButton = FindViewById<Button>(Resource.Id.buttonMenuAbout);

            //ucitaj temu osnovnu
            setCoolBlackTheme();

            //TEME
            mainMenuTitle.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            MainMenuNewGameButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            MainMenuOptionsButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            MainMenuAboutButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);

            //AKCIJE
            MainMenuNewGameButton.Click += MainMenuNewGameButtonOnClick;
            MainMenuAboutButton.Click += MainMenuAboutButtonOnClick;
            MainMenuOptionsButton.Click += MainMenuOptionsButtonOnClick;
        }

        private void MainMenuOptionsButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(HighScore));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            //this.Finish();
        }

        private void MainMenuAboutButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(About));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            //this.Finish();
        }

        private void MainMenuNewGameButtonOnClick(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(this, typeof(PlayerChooseMenu));
            this.StartActivity(intent);
            this.OverridePendingTransition(Resource.Animation.slide_in_top, Resource.Animation.slide_out_bottom);
            //this.Finish();
        }

        public void setCoolBlackTheme()
        {
            themer.NormalText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCM_____.TTF");
            themer.NavButtonText = Typeface.CreateFromAsset(Application.Assets, "fonts/TCCM____.TTF");
            themer.BlueButtonColor = Resource.Drawable.buttonBlue;
            themer.GreenButtonColor = Resource.Drawable.buttonGreen;
            themer.OrangeButtonColor = Resource.Drawable.buttonOrange;
            themer.PurpleButtonColor = Resource.Drawable.buttonPurple;
            themer.RedButtonColor = Resource.Drawable.buttonRed;
            themer.YellowButtonColor = Resource.Drawable.buttonYellow;
            themer.NormalBackground = Resource.Drawable.FORME;
            themer.QuestionBackground = Resource.Drawable.PITANJA;
        }
    }
}