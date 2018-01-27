using Microsoft.AspNetCore.Mvc;
using PrabodaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrabodaApi.Controllers
{
    [Route("api/[controller]")]
    public class TourGuideController : Controller
    {

        private TouristManagerContext db = new TouristManagerContext();



        //get all tourist list
        [HttpGet]
        public IEnumerable<TourGuide> Get()
        {

            return db.TourGuide;
        }

        [Route("GetTourGuideDetails/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetTourGuideDetails(int id)
        {
            return db.TourGuide.Where(t=>t.GuideId==id);
        }

        [Route("AddTourGuideRating")]
        [HttpPost]
        public IActionResult AddRating([FromBody]TourGuideRating item)
        {
            if (item == null)
            {
                return NotFound();
            }
            else if(db.TourGuideRating.Where(t=>t.TourGuideId==item.TourGuideId && item.TouristId == item.TouristId).Any())
            {
                TourGuideRating newItem = db.TourGuideRating.FirstOrDefault(t => t.TourGuideId == item.TourGuideId && item.TouristId == item.TouristId);

                newItem.RatingValue = item.RatingValue;

                db.TourGuideRating.Update(newItem);
                db.SaveChanges();
                return Ok();
            }
            else
            {
                db.TourGuideRating.Add(item);
                db.SaveChanges();
                return Ok();
            }

        }
        [Route("GetAllRating")]
        [HttpGet]
        public IEnumerable<TourGuideRating> GetAllRating()
        {
            return db.TourGuideRating;
        }

        [Route("GetRateValuesById/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetRatingValues(int id)
        {

            if (db.TourGuideRating.Where(t => t.TourGuideId == id).Any())
            {

                var rating = db.TourGuideRating.Where(t => t.TourGuideId == id).Select(t => t.RatingValue);

                float value = 0;
                int count = 0;
                foreach (int T in rating)
                {
                    value = value + T;
                    count = count + 1;
                }

                return Json((value / count).ToString("0.00"));

            }
            else
            {
                return NotFound();
            }

        }

        [Route("AddComment")]
        [HttpPost]
        public IActionResult AddComment([FromBody]TourGuideComment item)
        {
            if (item == null)
            {
                return NotFound();
            }
            else if (item.GuideComment == null)
            {
                return NotFound();
            }
            else
            {
                db.TourGuideComment.Add(item);
                db.SaveChanges();
                return Ok();
            }

        }
    }
}
