using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class City : Entity
    {
        public Guid StateId { get; set; }
        public int IBGECode { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [ForeignKey("CategoryId")]
        public virtual State CityState {get; set; }
    }
}