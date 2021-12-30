using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.ViewModel
{
    public class Paginate<T>
    {
        public Paginate(List<T> models ,int currentPage ,int pageCount)
        {
            Models = models;
            CurrentPage = currentPage;
            PageCount = pageCount;
        }

        public List<T> Models { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
}
