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
    public class ProductBLL
    {
        public static List<ProductDTO> GetProducts()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return ProductConverter.DALListToDTO(db.Products.ToList());
            }
        }
        public static ProductDTO GetProductById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return ProductConverter.DALToDTO(db.Products.Find(id));
            }
        }
        public static bool DeleteProduct(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                Product product = db.Products.Find(id);
                if (product == null)
                    return false;
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return true;
        }
        public static bool ProductExists(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                return db.Products.Count(e => e.code == id) > 0;
            }
        }
        public static void Entry(Product product)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(product).State = EntityState.Modified;
            }
        }
        public static void Add(ProductDTO product)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Products.Add(ProductConverter.DTOToDAL(product));
                db.SaveChanges();
            }
        }

    }
}
