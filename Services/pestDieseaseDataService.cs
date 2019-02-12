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
using MelgodasAndroid.Repository;

namespace MelgodasAndroid.Services
{
    class pestDieseaseDataService
    {
        private PestDiseaseRepository repo = new PestDiseaseRepository();

        public Pest_Disease GetPestDiesease_By_ID(int id)
        {
            return repo.GetPest_Disease_by_ID(id);
        }
        public List<Pest_Disease> GetPest_Disease()
        {
            return repo.GetPest_Disease();
        }
    }
}