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
using MelgodasAndroid.Model;

namespace MelgodasAndroid.Adapters
{
    class priceListAdapter : BaseAdapter<Crop>
    {
        List<Crop> crops;
        Activity activity;

         public priceListAdapter(Activity context, List<Crop> cr)
        {
            activity = context;
            crops = cr;
        }

        public override Crop this[int position] => crops[position];

        public override int Count => crops.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var crop = crops[position];
            if (convertView==null)
            {
                convertView = activity.LayoutInflater.Inflate(Resource.Layout.cropRowView, null);
            }
            convertView.FindViewById<TextView>(Resource.Id.cropName).Text = crop.Name;
            convertView.FindViewById<TextView>(Resource.Id.cropPreviousPrice).Text = "N" + crop.PreviousPrice;
            convertView.FindViewById<TextView>(Resource.Id.cropCurrentPrice).Text = "N" + crop.CurrentPrice;
            convertView.FindViewById<TextView>(Resource.Id.netChange).Text = Math.Round(crop.NetChange,2) + "%";
            //image

            return convertView;
        }
    }
}