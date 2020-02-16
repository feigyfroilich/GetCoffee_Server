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
    public class OrderProductsController : ApiController
    {
        private GetCoffeeDBEntities db = new GetCoffeeDBEntities();

        // GET: api/OrderProducts
        public IQueryable<OrderProduct> GetOrderProducts()
        {
            return db.OrderProducts;
        }

        // GET: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult GetOrderProduct(long id)
        {

            //{
            //    List<ShopProductsDTO> shop = ShopProductsBLL.GetShopProductsById(id);
            //    if (shop == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(shop);
            //}
            List<OrderProductDTO> orderProducts = OrderProductBLL.GetOrderProductsById(id);
            //OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProducts == null)
            {
                return NotFound();
            }

            return Ok(orderProducts);
        }

        // PUT: api/OrderProducts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderProduct(long id, OrderProduct orderProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderProduct.code)
            {
                return BadRequest();
            }

            db.Entry(orderProduct).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderProductExists(id))
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

        // POST: api/OrderProducts
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult PostOrderProduct(OrderProductDTO orderProduct)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderProductDTO op = OrderProductBLL.Add(orderProduct);
            return Ok(op);

        }

        // DELETE: api/OrderProducts/5
        [ResponseType(typeof(OrderProduct))]
        public IHttpActionResult DeleteOrderProduct(long id)
        {
            OrderProduct orderProduct = db.OrderProducts.Find(id);
            if (orderProduct == null)
            {
                return NotFound();
            }

            db.OrderProducts.Remove(orderProduct);
            db.SaveChanges();

            return Ok(orderProduct);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderProductExists(long id)
        {
            return db.OrderProducts.Count(e => e.code == id) > 0;
        }
    }
}