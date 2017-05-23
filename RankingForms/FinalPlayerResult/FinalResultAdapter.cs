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
    class FinalResultAdapter : BaseAdapter<int>
    {
        private List<int> playerScore;
        private Context mContext;
        private Themer.Themer themer = Themer.Themer.Instance;

        public FinalResultAdapter(Context mContext, List<int> playerScore)
        {
            this.playerScore = playerScore;
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
            txtPosition.Text = (position + 1).ToString();

            TextView txtPlayerName = row.FindViewById<TextView>(Resource.Id.textPlayerName);
            txtPlayerName.Text = playerScore[position].ToString();

            TextView txtTotalScore = row.FindViewById<TextView>(Resource.Id.textTotalScore);
            txtTotalScore.Text = playerScore[position] == 0 ? "NE" : "DA";

            //theme postavljanje
            txtPosition.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            txtPlayerName.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            txtTotalScore.SetTypeface(themer.NormalText, TypefaceStyle.Italic);

            return row;
        }

        public override int Count => playerScore.Count;

        public override int this[int position] => playerScore[position];
    }
}