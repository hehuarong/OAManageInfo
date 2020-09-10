using System.Web.Http;

namespace OAManageApi.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

    }
}