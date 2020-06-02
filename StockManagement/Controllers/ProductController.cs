using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using StockManagement.Business.IManager;
using StockManagement.Models;

namespace StockManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ProductModel>> Get()
        {
            var response = _productManager.GetAll();

            if (!response.Any())
            {
                return NotFound();
            }

            return Ok(_productManager.GetAll());
        }

        // GET api/<ProductController>/5
        [HttpGet("{productId}")]
        public ActionResult<ProductModel> Get(int productId)
        {
            var response = _productManager.GetById(productId);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductModel request)
        {
            var response = _productManager.AddToStock(request);

            return CreatedAtAction(nameof(Get), new { productId = response.ProductId }, response);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{productId}")]
        public ActionResult Put(int productId, [FromBody] ProductModel request)
        {
            if (!_productManager.IsProductInStock(productId))
            {
                return NotFound();
            }

            _productManager.UpdateItem(request, productId);
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            if(!_productManager.IsProductInStock(productId))
            {
                return NotFound();
            }

            _productManager.Delete(productId);
            return NoContent();
        }
    }
}
