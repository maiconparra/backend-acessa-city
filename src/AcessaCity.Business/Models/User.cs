using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual IEnumerable<UserRoles> UserRoles { get; set; }
        public virtual IEnumerable<string> Roles { get => RolesArray(); }

        IEnumerable<string> RolesArray()
        {
            var claims = new List<string>();
            foreach (var item in UserRoles)
            {
                claims.Add(item.Role.Name);                
            }
            return claims;
        }
    }
}