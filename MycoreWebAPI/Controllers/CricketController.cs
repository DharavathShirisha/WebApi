using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using MycoreWebAPI.Models;
namespace MycoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CricketController : ControllerBase
    {
       

        [EnableQuery]
        [HttpGet]
        [Route("allget")]
        public List<Ipl> Getall() { return dc.Ipls.ToList(); }

        apidbContext dc = new apidbContext();
        [Produces("application/xml")]
        [HttpGet]
        [Route("getallteams")]
        public IEnumerable<Ipl> GetAllTeams()
        {
            var res = from t in dc.Ipls
                      select t;
            return res.ToList();
        }

        [HttpGet]
        [Route("Getbyid")]
        public IEnumerable<Ipl> Getbyid(int id)
        {
            var res = from t in dc.Ipls
                      where t.Teamno == id
                      select t;
            return res.ToList();
        }

        [HttpGet]
        [Route("Getbyid1")]
        public IActionResult Getbyid1(int id)
        {
            var res = from t in dc.Ipls
                      where t.Teamno == id
                      select t;
            if (id == 2)
            {
                return Unauthorized();
            }
            if (res.Count() > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



        // print all teamsname startwith paramerer and budjext is >parameter
        [HttpGet]
        [Route("getallteamsbynames")]
        public IEnumerable<Ipl> GetAllTeamsbyname(string name, int budjet)
        {
            var res = from t in dc.Ipls
                      where t.Teamname.StartsWith(name) && t.Totalbudget > budjet
                      select t;
            return res.ToList();
        }

        //
        [HttpPost]
        [Route("insertdata")]
        public IActionResult Post([FromQuery] Ipl p)
        {
            dc.Ipls.Add(p);
            int i = dc.SaveChanges();
            if (i > 0)
            {
                return Created();

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Deletedata")]
        public int Delete(int id)
        {

            var res = (from t in dc.Ipls
                        where t.Teamno == id
                        select t).FirstOrDefault();
            dc.Ipls.Remove(res);
            int i = dc.SaveChanges();
            return i;
        }

        [HttpPut]
        [Route("updatedata")]
        public int Put(Ipl u)
        {
            dc.Ipls.Update(u);
            int i = dc.SaveChanges();
            return i;
        }
       

    }
}
