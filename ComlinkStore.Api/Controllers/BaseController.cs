using ComlinkStore.Api.Helpers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ComlinkStore.Api.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseMessage ResponseMessage;

        public BaseController()
        {
            ResponseMessage = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            ResponseMessage = Request.CreateResponse(code, result);
            return Task.FromResult(ResponseMessage);
        }

        public Task<HttpResponseMessage> CreateErrorResponse(HttpStatusCode code, string title, string message)
        {
            ResponseMessage = Request.CreateResponse(code, new ErrorMessage(title, message));
            return Task.FromResult(ResponseMessage);
        }
    }
}