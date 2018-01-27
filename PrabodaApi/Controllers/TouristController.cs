using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{
    [Route("api/[controller]")]
    public class TouristController:Controller
    {

        private TouristManagerContext db = new TouristManagerContext();



        //get all tourist list
        [HttpGet]
        public IEnumerable<Tourist> Get()
        {
          
            return db.Tourist;

            
        }
        //get details by touristid
        [Route("GetDetailsOfATourist/{id}")]
        [HttpGet("{id}")]
        public Tourist GetDetailsOfATourist(int id)
        {
            return db.Tourist.FirstOrDefault(t=>t.TouristId==id);
        }

    }

}
