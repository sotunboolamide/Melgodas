using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Nio;
using MelgodasAndroid.Services;
using Plugin.CurrentActivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xam.Plugins.OnDeviceCustomVision;
using static Android.Graphics.Bitmap;

namespace MelgodasAndroid.Fragments
{
    public class CameraFragment : Fragment
    {
        ImageView pictureImageView;
        Button takePictureButton, analysePictureButton, selectImageButton;
        Java.IO.File imageDirectory;
        Java.IO.File imageFile;
        Bitmap image;
        private int PICK_IMAGE_REQUEST = 50;
        pestDieseaseDataService dataservice;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.cameraView, container, false);

           // return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            FindViews();
            HandleEvents();


  
            AndroidImageClassifier.Init("model.pb", "labels.txt", ModelType.General);


            imageDirectory = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),
                "Melgodas");

            if (!imageDirectory.Exists())
            {
                imageDirectory.Mkdirs();
            }

        }

        private void FindViews()
        {
            pictureImageView = this.View.FindViewById<ImageView>(Resource.Id.pictureImageView);
            takePictureButton = this.View.FindViewById<Button>(Resource.Id.takePictureButton);
            analysePictureButton = View.FindViewById<Button>(Resource.Id.analysePictureButton);
            selectImageButton = View.FindViewById<Button>(Resource.Id.selectImage);
        }

        private void HandleEvents()
        {
            takePictureButton.Click += TakePictureButton_Click;
            Toast.MakeText(View.Context, "Use your camera or select an image from your device", ToastLength.Short).Show();
            analysePictureButton.Click += AnalysePictureButton_Click;
            selectImageButton.Click += SelectImageButton_Click;
        }

        private void SelectImageButton_Click(object sender, EventArgs e)
        {


            var intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select a Photo"), PICK_IMAGE_REQUEST);



        //MediaFile file = null;
        //    await CrossMedia.Current.Initialize();
        //    if (!CrossMedia.Current.IsPickPhotoSupported)
        //    {
        //        Toast.MakeText(View.Context,"Alert, Cannot Select Photo", ToastLength.Short).Show();
        //        return;
        //    }
        //    file = await CrossMedia.Current.PickPhotoAsync();

        //    if (file == null) return;
            
        //    Toast.MakeText(View.Context,"Photo Path: " + file.Path,ToastLength.Short).Show();
        //    pictureImageView.SetImageBitmap(ImageHelper.GetImageFromFilePath(file.Path, pictureImageView.Width,pictureImageView.Height));
        }

        private async void AnalysePictureButton_Click(object sender, EventArgs e)
        {

            //convert to stream
            // Your Bitmap.
            if (imageFile == null)
                return;
            System.IO.StreamReader bos = new System.IO.StreamReader(imageFile.Path);

            var tag = await CrossImageClassifier.Current.ClassifyImage(bos.BaseStream);
            var ans = tag.OrderByDescending(x => x.Probability);
            var firstItem = ans.FirstOrDefault();
            if (firstItem.Probability >= 0.5)
            {
                //   Toast.MakeText(View.Context, "objects detected with percentage accuracy is " + get_text(ans), ToastLength.Long).Show();
                Toast.MakeText(View.Context, firstItem.Tag + " has an accuracy of " + firstItem.Probability * 100 + "%", ToastLength.Short).Show();
                dataservice = new pestDieseaseDataService();
                //get the pest
                var pestList = from p in dataservice.GetPest_Disease() where p.Name.ToLower() == firstItem.Tag.ToLower() select p;
                var pest = pestList.FirstOrDefault();
                pest.Imagepath = imageFile.Path;
                //analyse image and send to processPage
                var intent = new Intent(this.Activity, typeof(ImageProcessActivity));
                intent.PutExtra("pestId", pest.ID);
                StartActivityForResult(intent, 10);
            }
            bos.Dispose();

        }

        string get_text(IOrderedEnumerable<ImageClassification> elements)
        {
            string a = "";
            foreach (var item in elements)
            {
                a += $"{item.Tag} has {item.Probability * 100}% \n";
            }
            return a;
        }
        private void TakePictureButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            imageFile = new Java.IO.File(imageDirectory, string.Format("melgodasCapture", new Guid()));
            System.Console.WriteLine(imageFile.Path);
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile((imageFile)));
            
            StartActivityForResult(intent, 0);
        }

        System.IO.Stream stream = null;

        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {

            base.OnActivityResult(requestCode, resultCode, data);
            analysePictureButton.Enabled = true;

            int width = pictureImageView.Width;
            int height = pictureImageView.Height;
            if (requestCode == PICK_IMAGE_REQUEST && resultCode == Result.Ok)
            {
                stream = Activity.ContentResolver.OpenInputStream(data.Data);
                var bmp = BitmapFactory.DecodeStream(stream);
                pictureImageView.SetImageBitmap(bmp);

                var sdCardPath = Android.OS.Environment.DirectoryPictures;
                var filePath = System.IO.Path.Combine(imageDirectory.Path, "melgodas.png");
                var st = new FileStream(filePath, FileMode.Create);
                bmp.Compress(Bitmap.CompressFormat.Png, 100, st);
                st.Dispose();
                stream.Dispose();

                imageFile = new Java.IO.File(filePath);
            }
            else if (requestCode == 0)
            {
               // Toast.MakeText(View.Context, imageFile.Path, ToastLength.Short).Show();
                image = ImageHelper.GetImageFromFilePath(imageFile.Path, width, height);
                if (image != null)
                {
                    pictureImageView.SetImageBitmap(image);
                    image = null;
                }
            }
            else { analysePictureButton.Enabled = false; }
            //prevent memory leaks
            GC.Collect();

        }
        public class ImageHelper
        {
            public static Bitmap GetImageFromFilePath(string imagePath, int width, int height)
            {
                //Get the dimension first
                BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
                BitmapFactory.DecodeFile(imagePath, options);

                //calculate ratio to resize  image
                int outHeight = options.OutHeight;
                int outWidth = options.OutWidth;
                int sampleSize = 1;
                if (outHeight > height || outWidth > width)
                {
                    //tenary operation
                    sampleSize = outHeight > outWidth ? outWidth / outHeight : outHeight / outWidth;
                }
                //resize the image
                options.InSampleSize = sampleSize;
                options.InJustDecodeBounds = false;
                Bitmap resizedImage = BitmapFactory.DecodeFile(imagePath, options);
                return resizedImage;
            }
        }
    }
}