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
using BLL.convertions;
using DAL;
using DTO;

namespace GetCoffeeAPI.Controllers
{
    public class CategoriesController : ApiController
    {
       

        // GET: api/Categories
        public IHttpActionResult GetCategories()
        {
            return Ok(CategoryBLL.GetCategories());
        }

        // GET: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategory(long id)
        {
            CategoryDTO category = CategoryBLL.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(long id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.code)
            {
                return BadRequest();
            }

            CategoryBLL.Entry(category);

            try
            {
                Global.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        [ResponseType(typeof(Category))]
        public IHttpActionResult PostCategory(CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category c = CategoryConverter.DTOToDAL(category);
            CategoryBLL.Add(c);

            try
            {
                Global.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = category.code }, category);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(Category))]
        public IHttpActionResult DeleteCategory(long id)
        {
            if (CategoryBLL.DeleteCategory(id) == false)
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

        private bool CategoryExists(long id)
        {
            return ShopBLL.ShopExists(id);
        }
    }
}