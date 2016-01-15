using ComlinkStore.Domain.Entities;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ComlinkStore.Api.Controllers
{
    [RoutePrefix("api")]
    public class ProductController : BaseController
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _uow;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _uow = uow;
        }

        [HttpGet]
        [Route("v1/products/instock")]
        public Task<HttpResponseMessage> GetInStock()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _productRepository.GetProductsInStock());
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar produtos");
            }
        }

        [HttpGet]
        [Route("v1/products/outofstock")]
        public Task<HttpResponseMessage> GetOutOfStock()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _productRepository.GetProductsOutOfStock());
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar produtos");
            }
        }

        [HttpGet]
        [Route("v1/products/{id:int}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _productRepository.GetById(id));
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar produtos");
            }
        }

        [HttpPost]
        [Route("v1/products")]
        [Authorize]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            try
            {
                var category = _categoryRepository.Get((int)body.category);
                var product = new Product((string)body.name, (decimal)body.price, (int)body.quantity, category);

                _productRepository.Save(product);
                _uow.Commit();
                return CreateResponse(HttpStatusCode.OK, product);
            }
            catch(InvalidOperationException ex)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    ex.Message);
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao cadastrar produtos");
            }
        }

        [HttpPut]
        [Route("v1/products/sale")]
        public Task<HttpResponseMessage> Sale([FromBody]dynamic body)
        {
            try
            {
                var productId = (int)body.product; // Id do Produto a ser vendido
                var quantity = (int)body.quantity; // Quantidade vendida

                var product = _productRepository.GetById(productId);
                product.UpdateInventory(quantity);

                _productRepository.Update(product);
                _uow.Commit();
                return CreateResponse(HttpStatusCode.OK, product);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    ex.Message);
            }
            catch(Exception ex)
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao cadastrar produtos");
            }
        }
    }
}