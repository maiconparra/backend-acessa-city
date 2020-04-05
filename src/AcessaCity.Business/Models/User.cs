using System;
using System.Collections.Generic;

namespace AcessaCity.Business.Models
{
    public class User : Entity
    {
        public string FirebaseUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string ProfileUrl { get; set; }

        public virtual IEnumerable<CityHallRelatedUser> RelatedCityHalls { get; set; }
    }
}