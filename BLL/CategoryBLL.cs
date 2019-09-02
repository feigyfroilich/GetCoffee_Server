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
    public class CategoryBLL
    {
        public static List<CategoryDTO> GetCategories()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return CategoryConverter.DALListToDTO(db.Categories.ToList());

            }
        }
        public static CategoryDTO GetCategoryById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return CategoryConverter.DALToDTO(db.Categories.Find(id));
            }
        }



        public static bool DeleteCategory(long id)
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
        public static bool CategoryExists(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return db.Categories.Count(e => e.code == id) > 0;
            }
        }
        public static void Entry(Category category)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(category).State = EntityState.Modified;
            }
        }
        public static void Add(Category category)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Categories.Add(category);
            }
        }
    }
}
