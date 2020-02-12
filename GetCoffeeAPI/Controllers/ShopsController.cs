using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DAL;
using DTO;
using BLL;
using System.Web.Http.Cors;

namespace GetCoffeeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShopsController : ApiController
    {

        // GET: api/Shops
        public IHttpActionResult GetShops()
        {
            return Ok(ShopBLL.GetShops());
        }

        // GET: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult GetShop(long id)
        {
            ShopDTO shop = ShopBLL.GetShopById(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shops/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop(long id, ShopDTO shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop.code)
            {
                return BadRequest();
            }

           ShopDTO updatedUser =  ShopBLL.Entry(shop);

            return Ok(updatedUser);
        }
        
        // POST: api/Shops
        [ResponseType(typeof(ShopDTO))]
        public IHttpActionResult PostShop(ShopDTO shop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShopBLL.Add(shop);

            return CreatedAtRoute("DefaultApi", new { id = shop.code }, shop);
        }

        // DELETE: api/Shops/5
        [ResponseType(typeof(Shop))]
        public IHttpActionResult DeleteShop(long id)
        { 
            if (ShopBLL.DeleteShop(id) == false)
            {
                return NotFound();
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Global.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShopExists(long id)
        {
            return ShopBLL.ShopExists(id);
        }
    }
}