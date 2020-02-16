using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL.convertions
{
    class OrderProductConverter
    {

        public static OrderProductDTO DALToDTO(OrderProduct order_product)
        {
            return new OrderProductDTO
            {
                Code = order_product.code,
                orderCode = order_product.orderCode,
                productCode = order_product.productCode,
                amount = order_product.amount.Value
            };
        }
        public static List<OrderProductDTO> DALListToDTO(List<OrderProduct> orderProducts)
        {
            List<OrderProductDTO> orderProductDTOList = new List<OrderProductDTO>();
            orderProducts.ForEach(order => orderProductDTOList.Add(OrderProductConverter.DALToDTO(order)));
            return orderProductDTOList;
        }

        public static OrderProduct DTOToDAL(OrderProductDTO order)
        {
            return new OrderProduct
            {
                code = order.Code,
                orderCode = order.orderCode,
                productCode = order.productCode,
                amount = order.amount
            };
        }
    }
}
