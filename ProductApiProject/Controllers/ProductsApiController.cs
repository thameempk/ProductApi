using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApiProject.Models;
using System.Reflection.Metadata.Ecma335;

namespace ProductApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProducts? _items = null;

        public ProductsApiController(IProducts items)
        {
            _items = items;
        }

        [HttpGet]

        public ActionResult GetProducts()
        {
            List<Products> allProducts = _items.GetProducts();
            return Ok(allProducts);
        }

        [HttpGet("{id}" , Name = "getItem")]

        public ActionResult GetProductById(int id)
        {
            if( id == 0)
            {
                return BadRequest();
            }
            Products product = _items.GetProductById(id);
            return Ok(product);
        }

        [HttpPost] 

        public IActionResult CreateProduct([FromBody] Products product)
        {

            if (product == null || product.Id > 0)
            {
                return BadRequest();
            }
            product.Id = _items.GetProducts().OrderByDescending(s => s.Id).FirstOrDefault().Id + 1;
            _items.AddProduct(product);
            return CreatedAtAction("GetProductById", new {id = product.Id} , product);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProductById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            Products product = _items.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            _items.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateProduct (int id, [FromBody] Products product)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var prd = _items.GetProductById(id);
            if(prd == null)
            {
                return NotFound();
            }
            _items.UpdateProduct(id, product);
            return NoContent();

        }
        


    }
}
