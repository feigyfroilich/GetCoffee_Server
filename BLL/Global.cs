using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Global
    {
        public static void Dispose()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Dispose();
            }
        }
        public static void SaveChanges()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.SaveChanges();
            }
        }
    }
}
