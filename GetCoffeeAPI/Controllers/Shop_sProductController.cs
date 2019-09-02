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
using BLL;
using DAL;
using DTO;

namespace GetCoffeeAPI.Controllers
{
    public class Shop_sProductController : ApiController
    {

        // GET: api/Shop_sProduct
        public IHttpActionResult GetShop_sProduct()
        {
            return Ok(ShopProductsBLL.GetAllShopProducts());
        }

        // GET: api/Shop_sProduct/5
        [ResponseType(typeof(Shop_sProduct))]
        public IHttpActionResult GetShop_sProduct(long id)
        {
            ShopProductsDTO shop = ShopProductsBLL.GetShopProductsById(id);
            if (shop == null)
            {
                return NotFound();
            }

            return Ok(shop);
        }

        // PUT: api/Shop_sProduct/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop_sProduct(long id, Shop_sProduct shop_sProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shop_sProduct.productCode)
            {
                return BadRequest();
            }

            ShopProductsBLL.Entry(shop_sProduct);

            try
            {
                Global.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Shop_sProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Shop_sProduct
        [ResponseType(typeof(Shop_sProduct))]
        public IHttpActionResult PostShop_sProduct(Shop_sProduct shop_sProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ShopProductsBLL.Add(shop_sProduct);

            try
            {
                Global.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Shop_sProductExists(shop_sProduct.productCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = shop_sProduct.productCode }, shop_sProduct);
        }

        // DELETE: api/Shop_sProduct/5
        [ResponseType(typeof(Shop_sProduct))]
        public IHttpActionResult DeleteShop_sProduct(long id)
        {
            if (ShopProductsBLL.DeleteShopProducts(id) == false)
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

        private bool Shop_sProductExists(long id)
        {
            return ShopProductsBLL.ShopProductsExists(id);
        }
    }
}