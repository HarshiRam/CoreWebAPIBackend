using CoreWebAPIBackend.Core;
using CoreWebAPIBackend.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPIBackend.Infrastructure.Implementation
{
    public class ProductRepository : IProductRepository
    {
        //initilize appdbcontext
        private readonly MyAppDBContext _context;

        public ProductRepository(MyAppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Product model)
        {
            // _context.Entry(model).State = EntityState.Modified;
            var product = await _context.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.Update(product);
                await Save();
            }
        }

        public async Task Add(Product model)
        {
            await _context.Products.AddAsync(model);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await Save();
            }
        }

      
    }
}
