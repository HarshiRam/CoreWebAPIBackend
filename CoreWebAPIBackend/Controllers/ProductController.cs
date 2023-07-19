using CoreWebAPIBackend.Core;
using CoreWebAPIBackend.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAPIBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
 
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;

        }


        [HttpGet]
        [Route("GetProducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            if (_productRepo.GetAll == null)
            {
                return (IEnumerable<Product>)NotFound();
            }
            return await _productRepo.GetAll();
        }

        [HttpPut]
        [Route("UpdateProduct/{id}")]
        public async Task<ActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                await _productRepo.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpPost]
        [Route("PostProducts")]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {

            await _productRepo.Add(product);

            return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
        }



        [HttpDelete]
        [Route("DeleteProducts/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productRepo.GetById(id);
            if (product != null)
            {
                await _productRepo.DeleteById(id);
            }
            else
            {
                return NotFound();
            }
            return Ok();

        }


        [HttpGet]
        [Route("GetProductsById/{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            if (_productRepo.GetAll == null)
            {
                return NotFound();
            }
            var product = await _productRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;

        }
    }
}
