using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.convertions
{
    public class ShopProductsConverter
    {
        public static ShopProductsDTO DALToDTO(Shop_sProduct shopProducts)
        {
            return new ShopProductsDTO
            {
                productCode = shopProducts.productCode,
                shopCode = shopProducts.shopCode,
                price = shopProducts.price,
                duration = shopProducts.duration,
                status = shopProducts.status
            };
        }
        public static List<ShopProductsDTO> DALListToDTO(List<Shop_sProduct> shopProductslist)
        {
            List<ShopProductsDTO> shopProductsDTOList = new List<ShopProductsDTO>();
            shopProductslist.ForEach(shopProducts => shopProductsDTOList.Add(ShopProductsConverter.DALToDTO(shopProducts)));
            return shopProductsDTOList;
        }
        public static Shop_sProduct DTOToDAL(ShopProductsDTO shopProduct)
        {
            return new Shop_sProduct
            {
                productCode = shopProduct.productCode,
                shopCode = shopProduct.shopCode,
                price = shopProduct.price,
                duration = shopProduct.duration,
                status = shopProduct.status
            };
        }



    }
}
