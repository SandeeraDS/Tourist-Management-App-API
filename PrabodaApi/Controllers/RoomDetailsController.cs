using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{

    [Route("api/[controller]")]
    public class RoomDetailsController:Controller
    {
        private TouristManagerContext db = new TouristManagerContext();

        //get by hotel id
        [Route("GetAllRoomTypes/{id}")]
        [HttpGet("{id}")]
        public IQueryable<RoomDetails> GetAllRoomTypes(int id)
        {

            return db.RoomDetails.Where(t => t.HotelId == id);
        }
    }
}
