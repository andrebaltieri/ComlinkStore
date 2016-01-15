using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComlinkStore.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using ComlinkStore.Domain.Specs;

namespace ComlinkStore.Domain.Tests.Specs
{
    [TestClass]
    public class ProductSpecsTests
    {
        private List<Product> _products;

        public ProductSpecsTests()
        {
            _products = new List<Product>();
            _products.Add(new Product("Produto 1", 19, 5, null));
            _products.Add(new Product("Produto 2", 19, 4, null));
            _products.Add(new Product("Produto 3", 19, 3, null));
            _products.Add(new Product("Produto 4", 19, 2, null));
            _products.Add(new Product("Produto 5", 19, 0, null));
        }

        [TestMethod]
        [TestCategory("Produtos - Estoque")]
        public void DeveRetornarQuatroProdutosEmEstoque()
        {
            var result = _products
                .AsQueryable()
                .Where(ProductSpecs.GetProductsInStock())
                .Count();

            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        [TestCategory("Produtos - Estoque")]
        public void DeveRetornarUmProdutoForaDeEstoque()
        {
            var result = _products
                .AsQueryable()
                .Where(ProductSpecs.GetProductsOutOfStock())
                .Count();

            Assert.AreEqual(result, 1);
        }
    }
}
