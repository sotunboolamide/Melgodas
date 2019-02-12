using Melgodas.Core.Model;
using Melgodas.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Melgodas.Core.Services
{
    class NewsDataService
    {
        private NewsRepository newsRepository = new NewsRepository();

        public List<NewsModel> GetAllNews()
        {
            return newsRepository.GetAllNews();
        }
        public NewsModel GetNewsByID(int id)
        {
            return newsRepository.getNewsbyID(id);
        }
    }
}
