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
using Melgodas.Core.Services;
using MelgodasAndroid.Adapters;

namespace MelgodasAndroid
{
    [Activity(Label = "NewsActivity", MainLauncher = false)]
    public class NewsActivity : Activity
    {
        ListView newsList;
        List<NewsModel> allNews;
        NewsDataService newsdataservice;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.newsMenu);
            newsList = FindViewById<ListView>(Resource.Id.newsListView);
            newsdataservice = new NewsDataService();
            allNews = newsdataservice.GetAllNews();
          
            newsList.Adapter = new NewsListAdapters(this, allNews);
            newsList.FastScrollEnabled = true;
            newsList.ItemClick += NewsList_ItemClick;


        }

        private void NewsList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var news = allNews[e.Position];
            var intent = new Intent(this, typeof(NewsDetailActivity));
            intent.PutExtra("newsID", news.NewsId);
            StartActivityForResult(intent, 100);
        }
    }
}