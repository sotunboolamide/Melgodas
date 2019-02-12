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
using Melgodas.Core.Model;
using Melgodas.Core.Services;
using MelgodasAndroid.Adapters;

namespace MelgodasAndroid.Fragments
{
    public class NewsFragment : Fragment
    {
         private ListView listView;
        private NewsDataService dataService;
        private List<NewsModel> allNewsModels;

        public NewsFragment()
        {
            dataService = new NewsDataService();
        }
        protected void HandleEvents()
        {
            listView.ItemClick += ListView_ItemClick;
        }
        protected void FindViews()
        {
            listView = this.View.FindViewById<ListView>(Resource.Id.newsListView);
        }
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var news = allNewsModels[e.Position];
            var intent = new Intent(this.Activity, typeof(NewsDetailActivity));
            intent.PutExtra("newsID", news.NewsId);
            StartActivityForResult(intent, 100);
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
            HandleEvents();
            allNewsModels = dataService.GetAllNews();
            listView.Adapter = new NewsListAdapters(this.Activity, allNewsModels);




            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.newsMenu, container, false);

          //  return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}