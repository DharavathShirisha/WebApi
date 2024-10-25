using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MycoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        // how to display data
        [HttpGet]
        [Route("heros")]
        public string[] GetHeros()
        {
            string[] st = { "prabas", "Allu Arjun", "ntr" };
            return st;
        }
        [HttpGet]
        [Route("herosbyid")]
        public IEnumerable<string> GetHerosnyid(string id)
        {
            string[] st = { "prabas", "Allu Arjun", "ntr" };
            var res= from t  in st
                     where t== id
                     select t;
            return res;
        }
        [HttpGet]
        [Route("heroins")]
        public string[] GetHeroins()
        {
            string[] st = { "Madhuri", "Aliya", "jhanvi Kappor" };
            return st;
        }
        [HttpGet]
        [Route("willans")]
        public string[] GetWillans()
        {
            string[] st = {"Girija", "girisha","ravalika fro ever"};
            return st;
        }
    }
}
