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
            List<ShopProductsDTO> shop = ShopProductsBLL.GetShopProductsById(id);
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

        // PUT: api/Shop_sProduct
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShop_sProduct([FromBody] List<ShopProductsDTO> shop_sProducts)
        {
            try
            {
                ShopProductsBLL.updateShopProducts(shop_sProducts);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: api/Shop_sProduct
        [ResponseType(typeof(Shop_sProduct))]
        public IHttpActionResult PostShop_sProduct(ShopProductsDTO shop_sProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //TimeSpan time = TimeSpan.Parse(shop_sProduct.duration.ToString());

            ////string ts = TimeSpan.fromMinutes(this.prepareTime);
            //shop_sProduct.duration = time;
            ShopProductsDTO sRes = ShopProductsBLL.Add(shop_sProduct);

            return Ok(sRes);
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