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

namespace MelgodasAndroid.Model
{
    class Crop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double PreviousPrice { get; set; }
        public double CurrentPrice { get; set; }
        public double NetChange
        {
            get
            {
                return ((CurrentPrice - PreviousPrice) / CurrentPrice) * 100;
            }
        }
    }
}