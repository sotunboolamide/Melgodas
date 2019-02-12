using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MelgodasAndroid.Adapters;
using MelgodasAndroid.Model;
using MelgodasAndroid.Services;

namespace MelgodasAndroid.Fragments
{
    public class marketPriceFragment : Fragment
    {
        private ListView croplistView;
        private cropDataService dataService;
        private List<Crop> allCrops;

        public marketPriceFragment()
        {
            dataService = new cropDataService();
        }

        protected void FindViews()
        {
            croplistView = this.View.FindViewById<ListView>(Resource.Id.cropPriceList);
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            allCrops = dataService.GetCrops();
            croplistView.Adapter = new priceListAdapter(this.Activity, allCrops);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.priceView, container, false);

         //   return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}