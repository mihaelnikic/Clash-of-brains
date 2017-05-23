using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace RankingForms
{
    class PlayerListViewAdapter : BaseAdapter<PlayerStat>
    {
        private List<PlayerStat> playerStats;
        private Context mContext;
        private Themer.Themer themer = Themer.Themer.Instance;

        public PlayerListViewAdapter(Context mContext, List<PlayerStat> playerStats)
        {
            this.playerStats = playerStats;
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
            txtPlayerName.Text = playerStats[position].PlayerName;

            TextView txtTotalScore = row.FindViewById<TextView>(Resource.Id.textTotalScore);
            txtTotalScore.Text = playerStats[position].PerQuestionScore.Sum().ToString();

            //theme postavljanje
            txtPosition.SetTypeface(themer.NormalText, TypefaceStyle.Bold);
            txtPlayerName.SetTypeface(themer.NormalText, TypefaceStyle.Normal);
            txtTotalScore.SetTypeface(themer.NormalText, TypefaceStyle.Italic);

            return row;
        }

        public override int Count => playerStats.Count;

        public override PlayerStat this[int position] => playerStats[position];
    }
}