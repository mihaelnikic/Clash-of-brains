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

namespace RankingForms.FinalPlayerResult
{
    class FinalResultTitleAdapter : BaseAdapter<string>
    {
        private Context mContext;
        private Themer.Themer themer = Themer.Themer.Instance;

        public FinalResultTitleAdapter(Context mContext)
        {
            this.mContext = mContext;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(
                    Resource.Layout.listview_row, null, false);
            }

            TextView txtPosition = row.FindViewById<TextView>(Resource.Id.textPosition);
            txtPosition.Text = "#Pitanje";

            TextView txtPlayerName = row.FindViewById<TextView>(Resource.Id.textPlayerName);
            txtPlayerName.Text = "Bodovi";

            TextView txtTotalScore = row.FindViewById<TextView>(Resource.Id.textTotalScore);
            txtTotalScore.Text = "Toèan?";

            //theme postavljanje
            txtPosition.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            txtPlayerName.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            txtTotalScore.SetTypeface(themer.NormalText, TypefaceStyle.Bold);

            return row;
        }

        public override int Count => 1;

        public override string this[int position] => null;
    }
}