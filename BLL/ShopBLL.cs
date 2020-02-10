using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BLL.convertions;
using System.Data.Entity;
namespace BLL
{
    public class ShopBLL
    {
        public static List<ShopDTO> GetShops()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ShopConverter.DALListToDTO(db.Shops.ToList());


            }
        }
        public static ShopDTO GetShopById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ShopConverter.DALToDTO(db.Shops.Find(id));
            }
        }
        public static bool DeleteShop(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                Shop shop = db.Shops.Find(id);
                if (shop == null)
                    return false;
                db.Shops.Remove(shop);
                db.SaveChanges();
            }
            return true;
        }
        public static bool ShopExists(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return db.Shops.Count(e => e.code == id) > 0;
            }
        }
        public static void Entry(Shop shop)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(shop).State = EntityState.Modified;
                
            }
        }
        public static void Add(Shop shop)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Shops.Add(shop);
                db.SaveChanges();
            }
        }
    }
}
