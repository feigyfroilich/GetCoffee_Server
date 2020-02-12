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
  public  class usersBLL
    {
        public static List<UsersDTO> GetUsers()
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return UsersConverter.DALListToDTO(db.Users.ToList());


            }
        }
        public static UsersDTO GetUsersById(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {

                return UsersConverter.DALToDTO(db.Users.Find(id));
            }
        }
        public static bool DeleteUser(long id)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                User user = db.Users.Find(id);
                if (user == null)
                    return false;
                db.Users.Remove(user);
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
        public static void Entry(User user)
        {
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Entry(user).State = EntityState.Modified;
            }
        }
        public static UsersDTO Add(UsersDTO userD)
        {
            User user = UsersConverter.DTOToDAL(userD);
            using (GetCoffeeDBEntities db = new GetCoffeeDBEntities())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return UsersConverter.DALToDTO(user);
        }
    }
}
