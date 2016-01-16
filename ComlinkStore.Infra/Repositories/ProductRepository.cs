using ComlinkStore.Domain.Entities;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Domain.Specs;
using ComlinkStore.Infra.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ComlinkStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ComlinkStoreDataContext _context;

        public ProductRepository(ComlinkStoreDataContext context)
        {
            _context = context;
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<Product> GetProductsInStock()
        {
            return _context
                .Products
                .Include(x => x.Category)
                .Where(ProductSpecs.GetProductsInStock())
                .ToList();
        }

        public List<Product> GetProductsOutOfStock()
        {
            return _context
                .Products
                .Include(x => x.Category)
                .Where(ProductSpecs.GetProductsOutOfStock())
                .ToList();
        }

        public List<Product> GetByCategory(int id)
        {
            return _context.Products.Where(x => x.CategoryId == id).ToList();
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = 
                EntityState.Modified;
        }
    }
}
