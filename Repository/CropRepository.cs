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

namespace MelgodasAndroid.Repository
{
    class CropRepository
    {
        private static List<Crop> Crops = new List<Crop>
        {
            new Crop
            {
                 ID=0,
                 Name="Tomato",
                 PreviousPrice=130,
                 CurrentPrice=200
            },
                   new Crop
            {
                 ID=1,
                 Name="Cocoa",
                 PreviousPrice=2002,
                 CurrentPrice = 2321
            },
                   new Crop
            {
                 ID=2,
                 Name="Potato",
                 PreviousPrice=200,
                 CurrentPrice = 200
            }          , new Crop
            {
                 ID=3,
                 Name="Yam",
                 PreviousPrice=130,
                 CurrentPrice=120
            },
                   new Crop
            {
                 ID=4,
                 Name="Maize",
                 PreviousPrice=1500,
                 CurrentPrice = 1500
            }          , new Crop
            {
                 ID=5,
                 Name="Beans",
                 PreviousPrice=2000,
                 CurrentPrice=2300
            },
                   new Crop
            {
                 ID=6,
                 Name="Rice",
                 PreviousPrice=10000,
                 CurrentPrice = 8000
            }
        };

        public List<Crop> GetCrops()
        {
            return Crops;
        }
    }
}