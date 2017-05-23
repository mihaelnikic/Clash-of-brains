using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RankingForms.MatchStart
{
    class PlayerChooseAdapterList : BaseAdapter<String>
    {
        private Context mContext;
        private ObservableCollection<string> playersList;
        private Themer.Themer themer = Themer.Themer.Instance;

        public PlayerChooseAdapterList(Context mContext, ObservableCollection<string> playerList)
        {
            this.mContext = mContext;
            this.playersList = playerList;
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
                    Resource.Layout.playerChoose_row, null, false);
            }


            TextView txtPlayerName = row.FindViewById<TextView>(Resource.Id.textPlayerChoosePlayer);
            txtPlayerName.Text = playersList[position].ToString();


            //theme postavljanja
            txtPlayerName.SetTypeface(themer.NormalText, TypefaceStyle.Normal);

            return row;
        }

        public override int Count => playersList.Count;

        public override string this[int position] => playersList[position];
    }
}