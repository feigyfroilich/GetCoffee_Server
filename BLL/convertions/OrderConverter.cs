using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.convertions
{
    class OrderConverter
    {
        public static OrderDTO DALToDTO(Order order)
        {
            return new OrderDTO
            {
                code = order.code,
                shopCode = order.shopCode,
                date = order.date.ToString(),
                deadline = order.deadline,
                ready = order.ready,
                taken = order.taken
            };
        }
        public static List<OrderDTO> DALListToDTO(List<Order> orders)
        {
            List<OrderDTO> orderDTOList = new List<OrderDTO>();
            orders.ForEach(order => orderDTOList.Add(OrderConverter.DALToDTO(order)));
            return orderDTOList;
        }
        
        public static Order DTOToDAL(OrderDTO order)
        {
            DateTime myDate = DateTime.Parse(order.date);
            return new Order
            {

                shopCode = order.shopCode, 
                date = myDate,
                deadline = order.deadline,
                ready = order.ready,
                taken = order.taken,
                code = order.code
            };
        }

    }
}
