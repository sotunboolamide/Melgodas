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
using Melgodas.Core.Model;

namespace MelgodasAndroid.Adapters
{
    class NewsListAdapters : BaseAdapter<NewsModel>
    {
        List<NewsModel> newsList;
        Activity activity;

        public NewsListAdapters(Activity act, List<NewsModel> items)
        {
            activity = act;
            newsList = items;
        }
        public override NewsModel this[int position] => newsList[position];

        public override int Count => newsList.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var news = newsList[position];
            if (convertView == null)
            {
                convertView = activity.LayoutInflater.Inflate(Resource.Layout.newsFeedRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.newsTitle).Text = news.Title;
            convertView.FindViewById<TextView>(Resource.Id.newsDescription).Text = news.Description.Substring(0, 25) + "...";
            //image

            return convertView;
        }
    }
}