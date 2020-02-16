using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BLL;
using DAL;
using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GetCoffeeAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrdersController : ApiController
    {

        // GET: api/Orders
        public IHttpActionResult GetOrders()
        {
            return Ok(OrderBLL.GetOrders());
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult GetOrder(long id)
        {
            List<OrderDTO> order = OrderBLL.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrder(long id, OrderDTO order)
        {
            try
            {
                OrderBLL.updateOrder(order);
                sendEmailViaWebApi();
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != order.code)
            //{
            //    return BadRequest();
            //}

            //OrderBLL.updateShopProducts(order);

            //try
            //{
            //    Global.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!OrderExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return StatusCode(HttpStatusCode.NoContent);
        }

        private void sendEmailViaWebApi()
        {

            new SmtpClient
            {
                Host = "Smtp.Gmail.com",
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("feigyfroilich@Gmail.com", "30121998f"),
                
                
        }.Send(new MailMessage { From = new MailAddress("feigyfroilich@Gmail.com", "feigy"), To = { "rachelfroilich@gmail.com" }, Subject = "Get Coffee", Body = "you order is ready", BodyEncoding = Encoding.UTF8 });

        }
        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public IHttpActionResult PostOrder(OrderDTO order)
        {
            //DateTime dt = DateTime.ParseExact(order.date.ToString(), "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

            //string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
            //DateTime result;
            //DateTime.TryParse(s,  out result);
            DateTime today = DateTime.Today;
            //var parsedObject = JObject.Parse(today.ToString());
            //var resultingRequestJson = parsedObject["ResultingRequest"].ToString();
            //var responseData = JsonConvert.DeserializeObject<DateTime>(resultingRequestJson);
            order.date = today.ToString();
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OrderDTO o = OrderBLL.Add(order);
            return Ok(o);

            //try
            //{
            //    Global.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (OrderExists(order.code))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtRoute("DefaultApi", new { id = order.code }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(long id)
        {
            if (OrderBLL.DeleteOrder(id) == false)
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

        private bool OrderExists(long id)
        {
            return OrderBLL.OrderExists(id);
        }
    }
}
