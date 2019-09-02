using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDTO
    {
        public long code { get; set; }
        public string name { get; set; }
        public Nullable<long> parentCode { get; set; }
    }
}
