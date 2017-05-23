using System;
using System.Collections.Specialized;
using System.Net;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using RankingForms;
using Encoding = System.Text.Encoding;

namespace Clash_of_brains
{
    [Activity(Label = "Clash_of_brains", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.ButtonRankLocal);

            WebClient clinet = new WebClient();
            Uri uri = new Uri("http://ottoservice.cloudapp.net/PPIJCloudService.svc");
            clinet.DownloadDataAsync(uri);
            clinet.DownloadDataCompleted += ClinetOnDownloadDataCompleted;
                

            button.Click += delegate { StartActivity(typeof(RankLocalActivity)); };

        }

        private void ClinetOnDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs downloadDataCompletedEventArgs)
        {
            string json = Encoding.UTF8.GetString(downloadDataCompletedEventArgs.Result);

        }
    }
}

