using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Models;

namespace Order_Management.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly AppDBContext _appContext;
        public ProductController(AppDBContext appContext)
        {
            _appContext = appContext;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            List<Product> Items = await _appContext.Product.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        // POST: api/product/insert
        [HttpPost("insert")]
        public IActionResult Insert([FromBody] Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appContext.Product.Add(product);
            _appContext.SaveChanges();
            return Ok(product);
        }

        // POST: api/product/update
        [HttpPost("update")]
        public IActionResult Update([FromBody] Product product)
        {
            if (product == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appContext.Product.Update(product);
            _appContext.SaveChanges();
            return Ok(product);
        }

        // POST: api/product/remove
        [HttpPost("remove")]
        public IActionResult Remove([FromBody] int productId)
        {
            Product product = _appContext.Product
                .Where(x => x.ProductId == productId)
                .FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            _appContext.Product.Remove(product);
            _appContext.SaveChanges();
            return Ok(product);
        }
    }
}
