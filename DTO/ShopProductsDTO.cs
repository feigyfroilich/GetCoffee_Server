using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShopProductsDTO
    {
        public int Code { get; set; }
        public long productCode { get; set; }
        public long shopCode { get; set; }
        public int price { get; set; }
        public int duration { get; set; }
        public bool status { get; set; }
        public string name { get; set; }
        public string categoryName { get; set; }
    }
}
