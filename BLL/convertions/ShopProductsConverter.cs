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
        public static ShopProductsDTO DALToDTO(Shop_sProduct shopProduct)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities()) {
                Product p = db.Products.FirstOrDefault(pr => pr.code == shopProduct.productCode);
                Category c = db.Categories.FirstOrDefault(ct => ct.code == p.categoryCode);
            return new ShopProductsDTO
            {
                productCode = shopProduct.productCode,
                shopCode = shopProduct.shopCode,
                price = shopProduct.price,
                duration = shopProduct.duration,
                status = shopProduct.status,
                name = p.name,
                categoryName = c.name
            };
        }
        }
        public static List<ShopProductsDTO> DALsToDTOs(List<Shop_sProduct> shopProducts)
        {
            List<ShopProductsDTO> newList = new List<ShopProductsDTO>();
            shopProducts.ForEach(sp => { newList.Add(DALToDTO(sp)); });
            return newList;
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
