using ComlinkStore.Api.Helpers;
using ComlinkStore.Domain.Entities;
using ComlinkStore.Domain.Repositories;
using ComlinkStore.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComlinkStore.Api.Controllers
{
    [RoutePrefix("api")]
    public class CategoryController : BaseController
    {
        private ICategoryRepository _repository;
        private IUnitOfWork _uow;

        public CategoryController(ICategoryRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        [HttpGet]
        [Route("v1/categories")]
        public Task<HttpResponseMessage> GetAll()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK, _repository.GetAll());
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar categorias");
            }
        }

        [HttpGet]
        [Route("v1/categories/{id:int}")]
        public Task<HttpResponseMessage> Get(int id)
        {
            try
            {
                var category = _repository.Get(id);
                return CreateResponse(HttpStatusCode.OK, category);
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar categoria");
            }
        }

        [HttpPost]
        [Route("v1/categories")]
        public Task<HttpResponseMessage> Post([FromBody]Category category)
        {
            try
            {
                _repository.Save(category);
                _uow.Commit();
                return CreateResponse(HttpStatusCode.Created, category);
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao cadastrar categoria");
            }
        }

        [HttpPut]
        [Route("v1/categories/{id:int}")]
        public Task<HttpResponseMessage> Put(int id, [FromBody]Category category)
        {
            try
            {
                var cat = _repository.Get(id);
                cat.ChangeName(category.Name);

                _repository.Update(cat);
                _uow.Commit();
                return CreateResponse(HttpStatusCode.OK, category);
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao atualizar categoria");
            }
        }

        [HttpDelete]
        [Route("v1/categories/{id:int}")]
        public Task<HttpResponseMessage> Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                _uow.Commit();
                return CreateResponse(HttpStatusCode.OK, 
                    new { message = "Categoria excluida com sucesso" });
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao atualizar categoria");
            }
        }
    }
}