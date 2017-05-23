using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RankingForms.MenuActivities
{
    public static class ConstantActivityResult
    {
        public static readonly int PRACTICE_NEXT_CATEGORY = 0;
        public static readonly int PRACTICE_NEXT_QUESTION = 1;
        public static readonly int PRACTICE_END = 2;
        public static readonly int MULTIPLAYER_SELECT_LIST = 3;
        public static readonly int MULTIPLAYER_NEXT_CATEGORY = 4;
        public static readonly int MULTIPLAYER_NEXT_QUESTION = 5;
        public static readonly int MULTIPLAYER_NEXT_PLAYER = 6;
        public static readonly int MULTIPLAYER_END = 7;
        public static readonly int GOOGLE_MAP_ACTIVITY = 8;
        public static readonly int SINGLEPLAYER_NEXT_CATEGORY = 9;
        public static readonly int SINGLEPLAYER_NEXT_QUESTION = 10;
        public static readonly int SINGLEPLAYER_END = 11;
    }
}