using Android.App;
using Android.OS;

using Android.Runtime;
using Android.Widget;

namespace MelgodasAndroid
{
    [Activity(Label = "Hello Page", MainLauncher = false)]
    public class MainActivity : Activity
    {
        Button button1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            button1 = FindViewById<Button>(Resource.Id.button1);
        }
    }
}