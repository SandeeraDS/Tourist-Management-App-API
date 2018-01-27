using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using PrabodaApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{

    [Route("api/[Controller]")]
    public class RoomBookingController:Controller
    {

        private TouristManagerContext db = new TouristManagerContext();



        //------------------------with foreign key-------------------------------------
        ////by torist id
        //[Route("GetRoomBookingDetails/{id}")]
        //[HttpGet("{id}")]
        //public IActionResult GetRoomBookingDetails(int id)
        //{

        //    if (db.RoomBooking.Where(t => t.TouristId == id).Any())
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        //mekata hotel eke foreignkey.name eka ganin
        //        return Json(db.RoomBooking.Where(t=>t.TouristId==id).Select(t=>new {t.BookingId,t.Booking.TotalAmount,t.Date,t.NoOfRooms,t.Hotel.RoomTypeName }));
        //    }

        //}


        //without Foreign key - make a model class;

        [Route("GetRoomBookingDetails/{id}")]
        [HttpGet("{id}")]
        public IEnumerable<BookingDetails> GetAll(int id)
        {

            if (db.RoomBooking.Where(t => t.TouristId == id).Any())
            {
               return null;
            }
            else
            {
                List<BookingDetails> bookingList = new List<BookingDetails>();

                var details = db.RoomBooking.Where(t => t.TouristId == id).Select(t => new { t.BookingId, t.Booking.TotalAmount, t.Date, t.NoOfRooms, t.Hotel.RoomTypeName,t.HotelId });

                foreach (var T in details)
                {
                    string hotelName = db.Hotel.FirstOrDefault(t=> t.HotelId == T.HotelId).UserName;

                    BookingDetails newItem = new BookingDetails
                    {
                        BookingId = T.BookingId,
                        PayamentAmount = T.TotalAmount,
                        RoomTypeName = T.RoomTypeName,
                        HotelName = hotelName,
                        NoOfRooms = T.NoOfRooms,
                        Date = T.Date
                    };
                    bookingList.Add(newItem);
                }

                return bookingList;
            }
        }



    }
}
