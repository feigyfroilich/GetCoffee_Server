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
    public class ShopProductsBLL
    {
        public static List<ShopProductsDTO> GetAllShopProducts()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ShopProductsConverter.DALListToDTO(db.Shop_sProduct.ToList());

            }
        }
        public static List<ShopProductsDTO>  GetShopProductsById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ShopProductsConverter.DALsToDTOs(db.Shop_sProduct.Where(Shop =>  Shop.shopCode == id).ToList());
            }
        }

        public static void updateShopProducts( List<ShopProductsDTO> shop_sProducts)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                List<Shop_sProduct> products = ShopProductsConverter.DTOsToDALs(shop_sProducts);
                products.ForEach(item =>
                {
                    db.Entry(item).State = EntityState.Modified;
                });
                db.SaveChanges();
            }
        }


        public static bool DeleteShopProducts(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                Shop_sProduct shop = db.Shop_sProduct.Find(id);
                if (shop == null)
                    return false;
                db.Shop_sProduct.Remove(shop);
                db.SaveChanges();
            }
            return true;
        }
        public static bool ShopProductsExists(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return db.Shop_sProduct.Count(e => e.shopCode == id) > 0;
            }
        }
        public static void Entry(Shop_sProduct shopProducts)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(shopProducts).State = EntityState.Modified;
            }
        }
        public static ShopProductsDTO Add(ShopProductsDTO shopProducts)
        {
            Shop_sProduct ss = ShopProductsConverter.DTOToDAL(shopProducts);
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Shop_sProduct.Add(ss);
                db.SaveChanges();
            }
            return ShopProductsConverter.DALToDTO(ss);
        }
    }
}
