using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AkkaIntro
{
    [RoutePrefix("api/echo")]
    public class EchoController : ApiController
    {
        [Route]
        [HttpGet]
        public HttpResponseMessage Get(string message)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { text = message });
        }
    }
}
