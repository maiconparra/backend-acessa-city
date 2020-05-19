using System;
using AcessaCity.Business.Models;

namespace AcessaCity.API.Dtos.CityHall
{
    public class CityHallDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public Guid CityId { get; set; }        
        public City City { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string ZIPCode { get; set; }
        public string Neighborhood { get; set; }

        public bool Verified { get; set; }
    }
}