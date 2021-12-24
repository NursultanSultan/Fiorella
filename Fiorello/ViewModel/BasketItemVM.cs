using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.ViewModel
{
    public class BasketItemVM
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int StockCount { get; set; }
        
    }
}
