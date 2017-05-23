using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace RankingForms
{
    class TitleListViewAdapter : BaseAdapter<string>
    {
        private Context mContext;
        private Themer.Themer themer = Themer.Themer.Instance;

        public TitleListViewAdapter(Context mContext)
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
            txtPosition.Text = themer.Translate("POZICIJA");

            TextView txtPlayerName = row.FindViewById<TextView>(Resource.Id.textPlayerName);
            txtPlayerName.Text = themer.Translate("IGRAC");

            TextView txtTotalScore = row.FindViewById<TextView>(Resource.Id.textTotalScore);
            txtTotalScore.Text = themer.Translate("BODOVI");

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