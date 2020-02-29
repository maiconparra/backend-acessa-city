using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcessaCity.Business.Models
{
    public class City : Entity
    {
        public Guid StateId { get; set; }
        public int IBGECode { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [ForeignKey("StateId")]
        public virtual State CityState {get; set; }
    }
}