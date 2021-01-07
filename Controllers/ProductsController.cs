using CoreWebApi.Data;
using CoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoPets.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ContosoPetsContext _context;

        public ProductsController(ContosoPetsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.Products.ToList();
        }

        // GET by ID action
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _context.FindAsync<Product>(id);
            if (product is null)
            {
                return NotFound();
            }
            return product;
        }

        //POST action
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            //if we just use Ok(product) we will not receive a Location prop in http header
            //which indicates  how we can access the newly created product 
            //also the result http code will be 200 HTTP(ok). Instead what we want is 201 HTTP(created)
            //return Ok(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);

        }

        // PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}