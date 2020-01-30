using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UsersDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public long? shopId { get; set; }
    }
}
