using ComlinkStore.Domain.Entities;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Repositories;

namespace ComlinkStore.Api.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        public List<Product> ObterTodos()
        {
            return _repository.GetProductsInStock();
        }

        [HttpGet]
        [Route("v1/products/{name}")]
        public List<Product> Obter(string name)
        {
            var products = new List<Product>();
            products.Add(new Product("Produto 1", 19, 5, null));
            products.Add(new Product("Produto 2", 19, 4, null));
            products.Add(new Product("Produto 3", 19, 3, null));
            products.Add(new Product("Produto 4", 19, 2, null));
            products.Add(new Product("Produto 5", 19, 0, null));

            return products.Where(x => x.Name == name).ToList();
        }

        [HttpPost]
        [Route("v1/products")]
        public Product Salvar([FromBody]Product product)
        {
            return product;
        }

        [HttpPut]
        [Route("v1/products/{name}")]
        public Product Atualizar([FromBody]Product product, string name)
        {
            var products = new List<Product>();
            products.Add(new Product("Produto 1", 19, 5, null));
            products.Add(new Product("Produto 2", 19, 4, null));
            products.Add(new Product("Produto 3", 19, 3, null));
            products.Add(new Product("Produto 4", 19, 2, null));
            products.Add(new Product("Produto 5", 19, 0, null));

            var prod = products.Where(x => x.Name == name).FirstOrDefault();
            return prod;
        }

        [HttpDelete]
        [Route("v1/products/{name}")]
        public Product Excluir(string name)
        {
            var products = new List<Product>();
            products.Add(new Product("Produto 1", 19, 5, null));
            products.Add(new Product("Produto 2", 19, 4, null));
            products.Add(new Product("Produto 3", 19, 3, null));
            products.Add(new Product("Produto 4", 19, 2, null));
            products.Add(new Product("Produto 5", 19, 0, null));

            var prod = products.Where(x => x.Name == name).FirstOrDefault();
            return prod;
        }
    }
}