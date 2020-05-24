using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class CityHall : Entity
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string ZIPCode { get; set; }
        public string Email { get; set; }
        public bool Verified { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
    }
}