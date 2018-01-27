using System;
using System.Collections.Generic;

namespace PrabodaApi.Entities
{
    public partial class CabDetails
    {
        public CabDetails()
        {
            CabComment = new HashSet<CabComment>();
            CabRating = new HashSet<CabRating>();
        }

        public int CabId { get; set; }
        public string CurrentLocation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string UserName { get; set; }
        public byte[] Picture { get; set; }
        public string Discription { get; set; }
        public int? Preference { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<CabComment> CabComment { get; set; }
        public virtual ICollection<CabRating> CabRating { get; set; }
    }
}
