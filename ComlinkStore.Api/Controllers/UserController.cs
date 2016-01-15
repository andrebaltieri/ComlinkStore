using ComlinkStore.Domain.Repositories;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComlinkStore.Api.Controllers
{
    [RoutePrefix("api")]
    public class UserController : BaseController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/users")]
        [Authorize(Roles = "admin")]
        public Task<HttpResponseMessage> Get()
        {
            try
            {
                return CreateResponse(HttpStatusCode.OK,
                    _repository.GetByUsername(User.Identity.Name));
            }
            catch
            {
                return CreateErrorResponse(HttpStatusCode.InternalServerError,
                    "Ops, algo deu errado",
                    "Falha ao carregar usuário");
            }
        }
    }
}