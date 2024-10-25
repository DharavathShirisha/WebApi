using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MycoreWebAPI.Models;

namespace MycoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinningController : ControllerBase
    {

        apidbContext dc = new apidbContext();


        [Produces("application/xml")]
        [HttpGet]
        [Route("getallteams")]
        public IEnumerable<Winner> GetAllTeams()
        {
            var res = from t in dc.Winners
                      select t;
            return res.ToList();
        }
        [HttpPost]
        [Route("insertdata")]
        public int Post([FromQuery] Winner p)
        {
            dc.Winners.Add(p);
            int i = dc.SaveChanges();
            return i;
        }

        [HttpGet]
        [Route("getallteamsbyname")]
        public IEnumerable<Winner> GetAllTeams(string name, string stad)
        {
            var res = from t in dc.Winners
                      where( t.Winningteam =="RCB" || t.Winningteam == "CSK" && t.Stadium == "MAC")
                      select t;
            return res.ToList();
        }

        //4.
        [HttpGet]
        [Route("winningrecordsindesc")]
        public IEnumerable<Winner> GetAllTeamsrecords()
        {
            var res = dc.Winners.OrderByDescending(c => c.Winningteam);
            return res.ToList();
        }
        //5.

    }
}
