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
    class dialog_poruka : DialogFragment
    {
        public TextView TextPoruka;
        public Button ButtonOK;
        public EventHandler OnDismissAction;

        private Themer.Themer themer = Themer.Themer.Instance;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_poruka, container, false);

            TextPoruka = view.FindViewById<TextView>(Resource.Id.txtPoruka);
            ButtonOK = view.FindViewById<Button>(Resource.Id.btnPoruka);
            TextPoruka.Text = this.Tag;
           /* OnDismissAction += (sender, args) =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                dialog_AddPlayer dialogAddPlayer = new dialog_AddPlayer();
                dialogAddPlayer.Show(transaction, "add player");
            };*/

            //theme
            TextPoruka.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            ButtonOK.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);
            ButtonOK.Click += (object sender, EventArgs args) =>
            {
                this.Dismiss();
            };

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Bez title bara
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);
            OnDismissAction?.Invoke(null, null);
        }
    }
}