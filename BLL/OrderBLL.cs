using BLL.convertions;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderBLL
    {
        public static List<OrderDTO> GetOrders()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return OrderConverter.DALListToDTO(db.Orders.ToList());

            }
        }
        public static OrderDTO GetOrderById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return OrderConverter.DALToDTO(db.Orders.Find(id));
            }
        }



        public static bool DeleteOrder(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                Order order = db.Orders.Find(id);
                if (order == null)
                    return false;
                db.Orders.Remove(order);
                db.SaveChanges();
            }
            return true;
        }
        public static bool OrderExists(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return db.Orders.Count(e => e.code == id) > 0;
            }
        }
        public static void Entry(Order order)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(order).State = EntityState.Modified;
            }
        }
        public static void Add(Order order)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Orders.Add(order);
            }
        }
    }
}
