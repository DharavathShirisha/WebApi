using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MycoreWebAPI.Controllers
{
    // Route is not required
    [ApiController]

    public class MathController : ControllerBase
    {

        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/mymethod")]
        [Route("api/{ver:apiVersion}/mymethod")]
        public string Method1()
        {
            return "First Version Called";
        }
        [HttpGet]
        [ApiVersion("1.0")]
        [Route("api/sum")]
        public string Add(int a, int b)
        {
            return "the sum is" + (a + b);
        }
    }
    [ApiController]
    public class MathController1 : ControllerBase
    {
        [HttpGet]
        [ApiVersion("2.0")]
        [Route("api/mymethod")]
        [Route("api/{ver:apiVersion}/mymethod")]
        public string method1()
        {
                return "Second Version called";
        }
   
        [HttpGet]
        [ApiVersion("2.0")]
        [Route("api/sum")]
        public string Add(int a, int b)
        {
            return "the sum is"+(a + b);
        }

        [HttpGet]
        [ApiVersion("3.0")]
        [Route("api/kudu")]
        [Route("api/{ver:apiVersion}kudu")]
        public string third(int a, int b)
        {
            return "the sum is" + (a + b);
        }
    }

}
