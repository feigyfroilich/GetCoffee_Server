using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.convertions
{
    public class ShopConverter
    {
        public static ShopDTO DALToDTO(Shop shop)
        {
            return new ShopDTO
            {
                code = shop.code,
                name = shop.name,
                location = shop.location,
                loginCode = shop.loginCode,
                shipment = shop.shipment,
                status = shop.status,
                rank = shop.rank,
                numOfCustomer = shop.numOfCustomer,
                accountNumber = shop.accountNumber,
                lat = (long)shop.lat,
                longi = (long)shop.@long
            };
        }
        public static List<ShopDTO> DALListToDTO(List<Shop> shops)
        {
            List<ShopDTO> shopDTOList = new List<ShopDTO>();
            shops.ForEach(shop => shopDTOList.Add(ShopConverter.DALToDTO(shop)));
            return shopDTOList;
        }

        public static Shop DTOToDAL(ShopDTO shop)
        {
            return new Shop
            {
                code = shop.code,
                name = shop.name,
                location = shop.location,
                loginCode = shop.loginCode,
                shipment = shop.shipment,
                status = shop.status,
                rank = shop.rank,
                numOfCustomer = shop.numOfCustomer,
                accountNumber = shop.accountNumber,
                lat = shop.lat,
                @long = shop.longi
            };
        }

    }

}

