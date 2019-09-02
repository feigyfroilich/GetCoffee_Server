using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        public long code { get; set; }
        public long shopCode { get; set; }
        public System.DateTime date { get; set; }
        public System.TimeSpan deadline { get; set; }
        public System.TimeSpan takeTime { get; set; }
        public bool ready { get; set; }
        public Nullable<bool> status { get; set; }
    }
}
