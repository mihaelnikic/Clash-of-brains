using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RankingForms.Dialogs
{
    class DialogLoading : DialogFragment
    {
        private TextView TextLoading;
        private Themer.Themer themer = Themer.Themer.Instance;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_loading, container, false);

            TextLoading = view.FindViewById<TextView>(Resource.Id.txtLoading);

            TextLoading.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Bez title bara
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}