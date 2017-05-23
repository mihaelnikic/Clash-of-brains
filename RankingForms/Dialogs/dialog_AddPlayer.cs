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
    class dialog_AddPlayer : DialogFragment
    {
        public EditText InputEditText;
        public Button AddnewPlayerButton;
        public EventHandler InputHandler;

        private Themer.Themer themer = Themer.Themer.Instance;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_enterPlayerName, container, false);

            InputEditText = view.FindViewById<EditText>(Resource.Id.txtEnterPlayerName);
            AddnewPlayerButton = view.FindViewById<Button>(Resource.Id.btnEnterPlayerNameSumbit);

            //theme
            InputEditText.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            AddnewPlayerButton.SetTypeface(themer.NavButtonText, TypefaceStyle.Normal);

            //akciej
            AddnewPlayerButton.Click += (sender, args) => buttonAction();

            return view;
        }

        public void buttonAction()
        {
            var text = InputEditText.Text;
            InputHandler.Invoke(InputEditText.Text, null);
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Bez title bara
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }

    }
}