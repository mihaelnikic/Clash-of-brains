using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using Uri = Android.Net.Uri;

namespace RankingForms.Questions
{
    [Activity(MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.Wallpaper.NoTitleBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class GoogleMaps : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;
        private Button CloseButton;
        private string odgovor;
        public EventHandler closeHanlder;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.dialog_maps);
            CloseButton = FindViewById<Button>(Resource.Id.buttonMapsClose);
            SetUpMap();
            CloseButton.Click += (sender, args) =>
            {
                Intent data = new Intent();
                data.SetData(Uri.Parse(odgovor));
                SetResult(Result.Ok, data);
                this.Finish();
            };
            closeHanlder += (sender, args) => this.Finish();
        }

        private void SetUpMap()
        {
            if (mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            mMap.MapType = GoogleMap.MapTypeSatellite;
            MarkerOptions options = new MarkerOptions()
                .SetPosition(new LatLng(58.968951, -17.662340))
                .Draggable(false);

            mMap.AddMarker(options);
            odgovor = "";


            mMap.MapClick += (Object o, GoogleMap.MapClickEventArgs s) =>
            {
                mMap.Clear();
                options.SetPosition(s.Point);
                mMap.AddMarker(options);
                Geocoder gcd = new Geocoder(this, Locale.English);
                IList<Address> addresses = gcd.GetFromLocation(s.Point.Latitude, s.Point.Longitude, 1);

                if (addresses.Count > 0)
                {
                    odgovor = addresses[0].CountryName;
                }
            };
        }
    }
}