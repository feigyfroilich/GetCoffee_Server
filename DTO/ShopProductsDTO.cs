using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShopProductsDTO
    {
        public long productCode { get; set; }
        public long shopCode { get; set; }
        public decimal price { get; set; }
        public System.TimeSpan duration { get; set; }
        public bool status { get; set; }
        public string name { get; set; }
        public string categoryName { get; set; }
    }
}
