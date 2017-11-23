using Akka.Actor;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AkkaIntro
{
    [RoutePrefix("api/counters")]
    public class CountersController : ApiController
    {
        [Route("{counterId}")]
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string counterId)
        {
            var request = new GetValue.Request(counterId);
            var response = await ActorsEnvironment.Gateway.Ask<GetValue.Response>(request);

            return Request.CreateResponse(HttpStatusCode.OK, new { value = response.Value });
        }
    }
}
