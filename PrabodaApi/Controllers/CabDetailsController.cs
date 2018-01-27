using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{
    [Route("Api/CabDetails")]
    public class CabDetailsController : Controller
    {

        private TouristManagerContext db = new TouristManagerContext();

        //get all cabs
        [HttpGet]
        public IEnumerable<CabDetails> GetAll()
        {
            return db.CabDetails;
        }
        //get by cab Id
        [HttpGet("{id}")]
        public IQueryable GetById(int id)
        {
            return db.CabDetails.Where(t=>t.CabId==id);
        }

        [HttpPost]
        public IActionResult AddCabCmmt([FromBody]CabComment item)
        {
            if (item == null)
            {
                return NotFound();
            }
            else if (item.CabComment1 == null)
            {
                return NotFound();
            }
            else
            {
                db.CabComment.Add(item);
                db.SaveChanges();
                return Ok();
            }
           

        }



    }
}
