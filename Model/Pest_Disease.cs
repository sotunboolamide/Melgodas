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
    class Pest_Disease
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Imagepath { get; set; }
        public string About { get; set; }
        public string Causes { get; set; }
        public string Remedy { get; set; }
    }
}