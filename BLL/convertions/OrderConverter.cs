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
                date = order.date,
                deadline = order.deadline,
                takeTime = order.takeTime,
                ready = order.ready,
                status = order.status
            };
        }
        public static List<OrderDTO> DALListToDTO(List<Order> orders)
        {
            List<OrderDTO> orderDTOList = new List<OrderDTO>();
            orders.ForEach(order => orderDTOList.Add(OrderConverter.DALToDTO(order)));
            return orderDTOList;
        }
    }
}
