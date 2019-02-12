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
using MelgodasAndroid.Services;
using static MelgodasAndroid.Fragments.CameraFragment;

namespace MelgodasAndroid
{
    [Activity(Label = "ImageProcessActivity")]
    public class ImageProcessActivity : Activity
    {
        TextView pestName, pestAbout, pestCause, pestRemedy;
        ImageView pestImage;
        pestDieseaseDataService dataService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Title = "Processed Image Result";
     
            SetContentView(Resource.Layout.imageProcessingView);
            FindViews();

            dataService = new pestDieseaseDataService();

            var pestDiseaseId = Intent.Extras.GetInt("pestId");
            var pest = dataService.GetPestDiesease_By_ID(pestDiseaseId);
            pestName.Text = pest.Name;
            pestAbout.Text = pest.About;
            pestCause.Text = pest.Causes;
            pestRemedy.Text = pest.Remedy;
            if(pest.Imagepath!=null)
            { var bmp = ImageHelper.GetImageFromFilePath(pest.Imagepath, pestImage.Width, pestImage.Height);
                pestImage.SetImageBitmap(bmp);
            }

        }
        private void FindViews()
        {
            pestName = FindViewById<TextView>(Resource.Id.pestName);
            pestAbout = FindViewById<TextView>(Resource.Id.pestAbout);
            pestCause = FindViewById<TextView>(Resource.Id.pestCause);
            pestRemedy = FindViewById<TextView>(Resource.Id.pestRemedy);
            pestImage = FindViewById<ImageView>(Resource.Id.pestImage);
        }
    }
}