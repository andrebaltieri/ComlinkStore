using ComlinkStore.Domain.Entities;
using System.Collections.Generic;

namespace ComlinkStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetProductsInStock();
        List<Product> GetProductsOutOfStock();
        void Save(Product product);
        void Update(Product product);
    }
}
