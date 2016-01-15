using ComlinkStore.Domain.Entities;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Data;
using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using ComlinkStore.Domain.Specs;

namespace ComlinkStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ComlinkStoreDataContext _context;

        public ProductRepository(ComlinkStoreDataContext context)
        {
            _context = context;
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
