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

namespace MelgodasAndroid
{
    [Activity(Label = "News Detail", MainLauncher = false, Icon ="@drawable/tv")]
    public class NewsDetailActivity : Activity
    {
        TextView newsTitleTextView, newsDescriptionTextView;
        ImageView newsImageView;

        NewsModel news;
        NewsDataService dataservice;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.newsDetailView);

            Title = "News Detail Page";
            TitleColor = Android.Graphics.Color.DarkGray;
           

            //FIndViews
            newsDescriptionTextView = FindViewById<TextView>(Resource.Id.newsDescriptionTextView);
            newsTitleTextView = FindViewById<TextView>(Resource.Id.newsTitleTextView);
            newsImageView = FindViewById<ImageView>(Resource.Id.newsImageView);

            //get from the previous page
            dataservice = new NewsDataService();
            var newsId = Intent.Extras.GetInt("newsID");
            news = dataservice.GetNewsByID(newsId);

            //bind the data received
            newsDescriptionTextView.Text = news.Description;
            newsTitleTextView.Text = news.Title;
            newsImageView.SetImageResource(Resource.Drawable.logo);
        }
    }
}