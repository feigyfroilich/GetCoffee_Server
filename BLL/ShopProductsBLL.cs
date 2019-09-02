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
        public static ShopProductsDTO GetShopProductsById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ShopProductsConverter.DALToDTO(db.Shop_sProduct.Find(id));
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
        public static void Add(Shop_sProduct shopProducts)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Shop_sProduct.Add(shopProducts);
            }
        }
    }
}
