using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{

    [Route("api/[controller]")]
    public class HotelController:Controller
    {
        private TouristManagerContext db = new TouristManagerContext();



        //get all the hotels
        [HttpGet]
        public IEnumerable<Hotel> Get()
        {
            return db.Hotel;
        }

        //get details by hotelid
        [Route("GetDetailsOfAHotel/{id}")]
        [HttpGet("{id}")]
        public Hotel GetDetailsOfAHotel(int id)
        {
            return db.Hotel.FirstOrDefault(t => t.HotelId == id);
        }



    }
}
