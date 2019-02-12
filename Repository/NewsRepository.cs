using Melgodas.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Melgodas.Core.Repository
{
    class NewsRepository
    {
        private static List<NewsModel> newsList = new List<NewsModel>
        {
            new NewsModel
            {NewsId=0,
                Title="Farming in Nigeria",
                Description="Farming in Nigeria is getting hotter and more competitive by the day. The younger generation have developed interest to be part of the agricultural ecosystem",
                 ImagePath=""
            },
                new NewsModel
            {NewsId=1,
                Title="Farmers recover from Loss",
                Description="Farmers recover from the loss experienced during the tomato ebola crises. Looking back at what happened, Nigerian Farmers have taken precautionary moves by subscribing the using the Melgodas app.",
                 ImagePath=""
            },
            new NewsModel
            {NewsId=2,
                Title="Weather Conditions",
                Description="The weather condition for the month of January looks promising as metereolgist have predicted that there will be rain although not often, but its a good way to enter the year.",
           ImagePath=""
            },
            new NewsModel
            {NewsId=3,
                Title="Farming in Nigeria",
                Description="Farming in Nigeria is getting hotter and more competitive by the day. The younger generation have developed interest to be part of the agricultural ecosystem",
                 ImagePath=""
            },
                new NewsModel
            {NewsId=4,
                Title="Farming in Nigeria",
                Description="Farming in Nigeria is getting hotter and more competitive by the day. The younger generation have developed interest to be part of the agricultural ecosystem",
                 ImagePath=""
            },
                new NewsModel
            {NewsId=5,
                Title="MELGODAS",
                Description="MELGODAS, A MOBILE APP WHICH MAXIMIZES THE TOOLS OF IMAGE PROCESSING AND DATA SCIENCE TO MITIGATE THE MENACE OF PEST AND  DISEASE OUTBREAK IN NIGERIA AND ALSO GIVES LIFE UPDATE OF MARKET PRICES OF LOCAL CONSUMABLES VIA WEB, APP AND MOBILE (USSD) . ",
     ImagePath=""
            },
            new NewsModel
            {NewsId=6,
                Title="Farming in Nigeria",
                Description="Farming in Nigeria is getting hotter and more competitive by the day. The younger generation have developed interest to be part of the agricultural ecosystem",
                 ImagePath=""
            }
        };

        public List<NewsModel> GetAllNews()
        {
            return newsList;
        }
        public NewsModel getNewsbyID(int id)
        {
            return newsList[id];
        }
    }
}