using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ShopDTO
    {
        public long code { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string loginCode { get; set; }
        public bool shipment { get; set; }
        public long lat { get; set; }
        public long longi { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> rank { get; set; }
        public Nullable<long> numOfCustomer { get; set; }
        public Nullable<long> accountNumber { get; set; }
    }
}
