using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderProductDTO
    {
        public long Code { get; set; }
        public long orderCode { get; set; }
        public long productCode { get; set; }
        public int amount { get; set; }
    }
}
