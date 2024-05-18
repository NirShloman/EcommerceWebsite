using EcommerceWebsite.Server.Data;
using EcommerceWebsite.Server.Models;
using EcommerceWebsite.Server.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcommerceWebsite.Server.Controllers
{
    [Route("api/EcommerceWebSiteApi")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            _logger.LogInformation("Getting all products");
            return Ok(_db.Products.ToList());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Get Product Error with id" + id);
                return BadRequest();
            }
            var product = _db.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] Product product)
        {
            if (_db.Products.FirstOrDefault(p => p.ProductName.ToLower() == product.ProductName.ToLower()) != null)
            {
                ModelState.AddModelError("ProductError", "Product already Exists!");
                return BadRequest();
            }
            if (product == null)
            {
                return BadRequest(product);
            }
            if (product.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _db.Products.Add(product);
            _db.SaveChanges();
            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var product = _db.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            _db.Products.Remove(product);
            _db.SaveChanges();
            return NoContent();
        }
    }
}