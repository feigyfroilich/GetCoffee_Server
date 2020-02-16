using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.convertions;
using DAL;
using DTO;
namespace BLL
{
    public class OrderProductBLL
    {
        public static OrderProductDTO Add(OrderProductDTO orderProducts)
        {
            OrderProduct op = OrderProductConverter.DTOToDAL(orderProducts);
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.OrderProducts.Add(op);
                db.SaveChanges();
            }
            return OrderProductConverter.DALToDTO(op);
        }

        public static List<OrderProductDTO> GetOrderProductsById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return OrderProductConverter.DALListToDTO(db.OrderProducts.Where(order => order.orderCode == id).ToList());
            }
        }
    }
}
