using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComlinkStore.Domain.Entities;

namespace ComlinkStore.Domain.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        [TestCategory("Compra")]
        [ExpectedException(typeof(Exception))]
        public void DeveRetornarErroQuandoCompraForMaiorQueEstoque()
        {
            var product = new Product("Produto 1", 19.90M, 5, new Category("Categoria 1"));
            product.UpdateInventory(35);
        }
    }
}
