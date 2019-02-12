using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using MelgodasAndroid.Fragments;

namespace MelgodasAndroid
{
    [Activity(Label = "Melgodas", MainLauncher =true, Theme = "@android:style/Theme.Holo.Light.DarkActionBar", Icon ="@drawable/logo")]
    public class TabActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //check for permission
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Camera) != Android.Content.PM.Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.Camera },1);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.ReadExternalStorage }, 9);
            }
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Android.Content.PM.Permission.Granted)
            {
                RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, 8);
            }
 
            // Create your application here
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.tabView);

            Title = "Melgodas";
            TitleColor = Android.Graphics.Color.DarkGray;



            //Tab 1
            var tab = ActionBar.NewTab();
            tab.SetText("News Updates");
            tab.SetIcon(Resource.Drawable.notification_bg_low_normal);
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer,new NewsFragment());
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(new NewsFragment());
            };

            ActionBar.AddTab(tab);


            //Tab 2
            tab = ActionBar.NewTab();
            tab.SetText("Capture");
            tab.SetIcon(Resource.Drawable.notification_bg_low_normal);
            //tab.TabSelected += (sender, args) => {
            //    // Do something when tab is selected
            //};

            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, new CameraFragment());
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(new CameraFragment());
            };
            ActionBar.AddTab(tab);


            //Tab 3
            tab = ActionBar.NewTab();
            tab.SetText("Market Price");
            tab.SetIcon(Resource.Drawable.notification_bg_low_normal);
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }
                e.FragmentTransaction.Add(Resource.Id.fragmentContainer, new marketPriceFragment());
            };

            tab.TabUnselected += delegate (object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(new marketPriceFragment());
            };
            ActionBar.AddTab(tab);

        }
    }
}